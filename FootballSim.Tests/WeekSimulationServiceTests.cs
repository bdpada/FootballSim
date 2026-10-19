using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class WeekSimulationServiceTests
{
    [Theory]
    [InlineData(24, 10, 1, 0)]
    [InlineData(10, 24, 0, 1)]
    public void SimulateWeek_RecordsResultsAdvancesWeekAndUpdatesStandings(
        int homePoints, int awayPoints, int homeWins, int awayWins)
    {
        var franchise = new FranchiseState(TestData.League(), "A");
        var simulator = new FixedGameSimulator(homePoints, awayPoints);
        var service = new WeekSimulationService(simulator);

        var result = service.SimulateWeek(franchise);

        Assert.NotNull(result);
        Assert.Equal(1, result.WeekNumber);
        Assert.Equal(2, franchise.CurrentWeek);
        Assert.Equal(SeasonPhase.RegularSeason, franchise.SeasonPhase);
        Assert.Same(result, Assert.Single(franchise.League.CompletedWeeks));
        var game = Assert.Single(result.Games);
        Assert.Equal((1, "A", "B"), (game.WeekNumber, game.HomeTeamId, game.AwayTeamId));
        Assert.Single(simulator.Calls);
        var home = franchise.League.Teams[0].Record;
        var away = franchise.League.Teams[1].Record;
        Assert.Equal((homeWins, awayWins, homePoints, awayPoints),
            (home.Wins, home.Losses, home.PointsFor, home.PointsAgainst));
        Assert.Equal((awayWins, homeWins, awayPoints, homePoints),
            (away.Wins, away.Losses, away.PointsFor, away.PointsAgainst));
        Assert.Equal(0, home.Ties + away.Ties);
        Assert.All(franchise.League.Teams.Skip(2), t => Assert.Equal(0, t.Record.Wins + t.Record.Losses));
    }

    [Fact]
    public void SimulateWeek_RecoversExistingInjuriesIncludingTeamsOnBye()
    {
        var franchise = new FranchiseState(TestData.League(), "A");
        var injured = TestData.Player();
        injured.ApplyInjury(3); // Remains injured, so weekly random injuries cannot affect this assertion.
        franchise.League.Teams[0].Roster.Add(injured);
        var recovering = TestData.Player("bye", teamId: "C");
        recovering.ApplyInjury(1);
        var healthy = TestData.Player("healthy", teamId: "C");
        franchise.League.Teams[2].Roster.AddRange([recovering, healthy]);

        new WeekSimulationService(new FixedGameSimulator()).SimulateWeek(franchise);

        Assert.Equal(2, injured.InjuryWeeksRemaining);
        Assert.Equal(0, recovering.InjuryWeeksRemaining);
        Assert.False(recovering.IsInjured);
        Assert.Equal(0, healthy.InjuryWeeksRemaining);
    }

    [Fact]
    public void SimulateWeek_FinalRegularWeekCreatesPlayoffsAfterUpdatingRecords()
    {
        var franchise = new FranchiseState(TestData.League(), "A") { CurrentWeek = 2 };

        var result = new WeekSimulationService(new FixedGameSimulator()).SimulateWeek(franchise);

        Assert.NotNull(result);
        Assert.Equal(3, franchise.CurrentWeek);
        Assert.Equal(SeasonPhase.Playoffs, franchise.SeasonPhase);
        Assert.Equal("A", franchise.League.PlayoffSeeds[0].TeamId);
        Assert.Equal(4, franchise.League.PlayoffSeeds.Count);
        Assert.Equal(2, franchise.League.PlayoffMatchups.Count);
    }

    [Fact]
    public void SimulateWeek_NoScheduledGamesTransitionsToPlayoffsWithoutAdvancingWeek()
    {
        var franchise = new FranchiseState(TestData.League(), "A") { CurrentWeek = 9 };
        var simulator = new FixedGameSimulator();

        var result = new WeekSimulationService(simulator).SimulateWeek(franchise);

        Assert.Null(result);
        Assert.Empty(simulator.Calls);
        Assert.Empty(franchise.League.CompletedWeeks);
        Assert.Equal(9, franchise.CurrentWeek);
        Assert.Equal(SeasonPhase.Playoffs, franchise.SeasonPhase);
        Assert.Equal(2, franchise.League.PlayoffMatchups.Count);
    }

    [Fact]
    public void SimulatePlayoffRound_RejectsRegularSeason()
    {
        var franchise = new FranchiseState(TestData.League(), "A");
        var simulator = new FixedGameSimulator();

        Assert.Throws<InvalidOperationException>(() =>
            new WeekSimulationService(simulator).SimulatePlayoffRound(franchise));

        Assert.Empty(simulator.Calls);
    }

    [Fact]
    public void SimulatePlayoffRound_ChampionshipCompletesSeason()
    {
        var franchise = new FranchiseState(TestData.League(), "A") { SeasonPhase = SeasonPhase.Playoffs };
        var playoffs = new PlayoffService();
        playoffs.GeneratePlayoffSeeds(franchise.League);
        playoffs.GenerateSemifinalMatchups(franchise.League);
        var service = new WeekSimulationService(new FixedGameSimulator());

        service.SimulatePlayoffRound(franchise);
        Assert.Equal(SeasonPhase.Playoffs, franchise.SeasonPhase);
        service.SimulatePlayoffRound(franchise);

        Assert.Equal(SeasonPhase.SeasonComplete, franchise.SeasonPhase);
        Assert.Equal("A", franchise.League.ChampionTeamId);
    }
}
