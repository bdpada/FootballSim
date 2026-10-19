using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class PlayoffServiceTests
{
    [Fact]
    public void GeneratePlayoffSeeds_OrdersByWinsLossesPointDifferentialThenIdentifier()
    {
        var league = TestData.League();
        league.Teams.Add(new(new("E", "Echo")));
        league.Teams[0].Record = new() { Wins = 5, Losses = 3, PointsFor = 100, PointsAgainst = 80 };
        league.Teams[1].Record = new() { Wins = 5, Losses = 2, PointsFor = 90, PointsAgainst = 80 };
        league.Teams[2].Record = new() { Wins = 5, Losses = 2, PointsFor = 100, PointsAgainst = 80 };
        league.Teams[3].Record = new() { Wins = 6, Losses = 4 };
        league.Teams[4].Record = new() { Wins = 5, Losses = 2, PointsFor = 100, PointsAgainst = 80 };
        league.PlayoffSeeds.Add(new() { SeedNumber = 99, TeamId = "stale" });

        new PlayoffService().GeneratePlayoffSeeds(league);

        Assert.Equal(new[] { "D", "C", "E", "B" }, league.PlayoffSeeds.Select(s => s.TeamId));
        Assert.Equal(new[] { 1, 2, 3, 4 }, league.PlayoffSeeds.Select(s => s.SeedNumber));
    }

    [Fact]
    public void GenerateSemifinalMatchups_PairsFirstWithFourthAndSecondWithThird()
    {
        var league = TestData.League();
        var service = new PlayoffService();
        service.GeneratePlayoffSeeds(league);
        league.ChampionTeamId = "old";
        league.PlayoffMatchups.Add(new());

        service.GenerateSemifinalMatchups(league);

        Assert.Equal(PlayoffRound.Semifinal, league.CurrentPlayoffRound);
        Assert.Empty(league.ChampionTeamId);
        Assert.Collection(league.PlayoffMatchups,
            m => Assert.Equal((1, "A", "D"), (m.MatchupNumber, m.HomeTeamId, m.AwayTeamId)),
            m => Assert.Equal((2, "B", "C"), (m.MatchupNumber, m.HomeTeamId, m.AwayTeamId)));
        Assert.All(league.PlayoffMatchups, m =>
        {
            Assert.Equal(PlayoffRound.Semifinal, m.Round);
            Assert.False(m.IsCompleted);
            Assert.Null(m.Result);
        });
    }

    [Fact]
    public void GenerateSemifinalMatchups_RejectsFewerThanFourSeeds()
    {
        var league = TestData.League();
        var service = new PlayoffService();
        service.GeneratePlayoffSeeds(league, 3);

        Assert.Throws<InvalidOperationException>(() => service.GenerateSemifinalMatchups(league));

        Assert.Empty(league.PlayoffMatchups);
    }

    [Theory]
    [InlineData(24, 10, "A", "B")]
    [InlineData(10, 24, "D", "C")]
    public void SimulateCurrentPlayoffRound_AdvancesWinnersAndDeterminesChampion(
        int homePoints, int awayPoints, string firstWinner, string secondWinner)
    {
        var league = TestData.League();
        var service = new PlayoffService();
        service.GeneratePlayoffSeeds(league);
        service.GenerateSemifinalMatchups(league);
        var simulator = new FixedGameSimulator(homePoints, awayPoints);

        var semifinalResults = service.SimulateCurrentPlayoffRound(league, simulator);

        Assert.Equal(2, semifinalResults.Count);
        Assert.All(league.PlayoffMatchups.Where(m => m.Round == PlayoffRound.Semifinal), m =>
        {
            Assert.True(m.IsCompleted);
            Assert.Contains(m.Result, semifinalResults);
        });
        Assert.Equal(PlayoffRound.Championship, league.CurrentPlayoffRound);
        Assert.Empty(league.ChampionTeamId);
        var championship = Assert.Single(league.PlayoffMatchups, m => m.Round == PlayoffRound.Championship);
        Assert.Equal((firstWinner, secondWinner), (championship.HomeTeamId, championship.AwayTeamId));

        var finalResults = service.SimulateCurrentPlayoffRound(league, simulator);

        Assert.Same(championship.Result, Assert.Single(finalResults));
        Assert.Equal(homePoints > awayPoints ? firstWinner : secondWinner, league.ChampionTeamId);
        Assert.True(championship.IsCompleted);
        Assert.Equal(3, simulator.Calls.Count);
        Assert.All(simulator.Calls, g => Assert.Equal(0, g.WeekNumber));
        Assert.Empty(service.SimulateCurrentPlayoffRound(league, simulator));
        Assert.Equal(3, simulator.Calls.Count);
        Assert.Equal(3, league.PlayoffMatchups.Count);
        Assert.All(league.Teams, t => Assert.Equal(0, t.Record.Wins + t.Record.Losses));
    }
}
