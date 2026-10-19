using System.Text.Json;
using FootballSim.Core.Models;
using FootballSim.Core.Services;
using FootballSim.Persistence.Services;

namespace FootballSim.Tests;

public class JsonSaveServiceTests : IDisposable
{
    private readonly string _directory = Path.Combine(Path.GetTempPath(), "FootballSim.Tests", Guid.NewGuid().ToString("N"));
    private JsonSaveService CreateService() => new(_directory);

    [Theory]
    [InlineData(SeasonPhase.RegularSeason)]
    [InlineData(SeasonPhase.Playoffs)]
    [InlineData(SeasonPhase.SeasonComplete)]
    public void SaveAndLoad_PreservesFranchiseTeamsRostersResultsAndSummary(SeasonPhase phase)
    {
        var service = CreateService();
        var franchise = new FranchiseFactory().CreateNewFranchise("ARI");
        franchise.CurrentWeek = 9;
        franchise.SeasonPhase = phase;
        franchise.LastSummaryText = "Week 8 results\nArizona won 24–10.\nPlayoffs next!";
        franchise.WeeklyGameplan = new() { OffenseFocus = OffenseFocus.PassFocus, DefenseFocus = DefenseFocus.StopRun };
        franchise.League.Teams[0].Roster[0].ApplyInjury(3);
        franchise.League.Teams[0].Record = new() { Wins = 6, Losses = 2, PointsFor = 200, PointsAgainst = 150 };
        var result = new FixedGameSimulator().SimulateGame(franchise.League,
            new() { WeekNumber = 8, HomeTeamId = "ARI", AwayTeamId = "LAR" });
        franchise.League.CompletedWeeks.Add(new() { WeekNumber = 8, Games = [result] });
        var playoffs = new PlayoffService();
        playoffs.GeneratePlayoffSeeds(franchise.League);
        playoffs.GenerateSemifinalMatchups(franchise.League);
        playoffs.SimulateCurrentPlayoffRound(franchise.League, new FixedGameSimulator());
        if (phase == SeasonPhase.SeasonComplete)
            playoffs.SimulateCurrentPlayoffRound(franchise.League, new FixedGameSimulator());

        service.Save("roundtrip", franchise);
        var loaded = service.Load("roundtrip");

        Assert.True(service.SaveExists("roundtrip"));
        Assert.NotSame(franchise, loaded);
        Assert.Equal(9, loaded.CurrentWeek);
        Assert.Equal(phase, loaded.SeasonPhase);
        Assert.Equal(franchise.LastSummaryText, loaded.LastSummaryText);
        Assert.Equal("ARI", loaded.UserTeamId);
        Assert.Same(loaded.League.Teams[0], loaded.UserTeam);
        Assert.Equal(8, loaded.League.Teams.Count);
        Assert.All(loaded.League.Teams, t => Assert.Equal(53, t.Roster.Count));
        Assert.Equal(100, loaded.League.FreeAgents.Count);
        Assert.Equal(32, loaded.League.Schedule.Games.Count);
        Assert.Equal(3, loaded.League.Teams[0].Roster[0].InjuryWeeksRemaining);
        var loadedResult = Assert.Single(Assert.Single(loaded.League.CompletedWeeks).Games);
        Assert.Equal((8, "ARI", "LAR", 24, 10), (loadedResult.WeekNumber, loadedResult.HomeTeamId,
            loadedResult.AwayTeamId, loadedResult.HomeStats.Points, loadedResult.AwayStats.Points));
        // Also compare the entire public graph: attributes, depth charts, records, gameplans and playoffs.
        Assert.Equal(JsonSerializer.Serialize(franchise), JsonSerializer.Serialize(loaded));
    }

    [Fact]
    public void Save_OverwritesExistingSlotAndListsMetadata()
    {
        var service = CreateService();
        var franchise = new FranchiseState(TestData.League(), "A");
        service.Save("slot", franchise);
        franchise.CurrentWeek = 4;

        service.Save("slot", franchise);

        Assert.Equal(4, service.Load("slot").CurrentWeek);
        var info = Assert.Single(service.GetAvailableSaves());
        Assert.Equal("slot", info.FileName);
        Assert.Equal("Alpha", info.UserTeamName);
        Assert.Equal(4, info.CurrentWeek);
        Assert.Equal(Path.Combine(_directory, "slot.json"), info.FullPath);
        Assert.True(File.Exists(info.FullPath));
    }

    [Fact]
    public void Delete_RemovesOnlyRequestedSave()
    {
        var service = CreateService();
        var franchise = new FranchiseState(TestData.League(), "A");
        service.Save("remove", franchise);
        service.Save("keep", franchise);

        service.Delete("remove");

        Assert.False(service.SaveExists("remove"));
        Assert.True(service.SaveExists("keep"));
        Assert.Equal("keep", Assert.Single(service.GetAvailableSaves()).FileName);
        Assert.Throws<FileNotFoundException>(() => service.Load("remove"));
        Assert.Throws<FileNotFoundException>(() => service.Delete("remove"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void SaveLoadDelete_RejectBlankNames(string? name)
    {
        var service = CreateService();
        var franchise = new FranchiseState(TestData.League(), "A");

        Assert.Throws<ArgumentException>(() => service.Save(name!, franchise));
        Assert.Throws<ArgumentException>(() => service.Load(name!));
        Assert.Throws<ArgumentException>(() => service.Delete(name!));

        Assert.Empty(service.GetAvailableSaves());
    }

    [Fact]
    public void Save_RejectsNullFranchiseWithoutWritingFile()
    {
        var service = CreateService();

        Assert.Throws<ArgumentNullException>(() => service.Save("invalid", null!));

        Assert.False(service.SaveExists("invalid"));
    }

    [Fact]
    public void LoadAndDelete_MissingSaveThrowFileNotFound()
    {
        var service = CreateService();

        Assert.Throws<FileNotFoundException>(() => service.Load("missing"));
        Assert.Throws<FileNotFoundException>(() => service.Delete("missing"));

        Assert.Empty(service.GetAvailableSaves());
    }

    [Fact]
    public void Load_MalformedJsonThrowsAndListingMarksUnreadableSave()
    {
        var service = CreateService();
        File.WriteAllText(Path.Combine(_directory, "broken.json"), "{ invalid json");

        Assert.Throws<JsonException>(() => service.Load("broken"));

        var info = Assert.Single(service.GetAvailableSaves());
        Assert.Equal("Unreadable Save", info.UserTeamName);
        Assert.Equal(0, info.CurrentWeek);
    }

    [Fact]
    public void Load_JsonNullThrowsDeserializationError()
    {
        var service = CreateService();
        File.WriteAllText(Path.Combine(_directory, "null.json"), "null");

        Assert.Throws<InvalidOperationException>(() => service.Load("null"));
    }

    public void Dispose()
    {
        if (Directory.Exists(_directory)) Directory.Delete(_directory, recursive: true);
    }
}
