using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class SimpleGameSimulatorV1Tests
{
    [Theory]
    [InlineData(1)]
    [InlineData(42)]
    [InlineData(2026)]
    public void SimulateGame_SeededGamesHaveValidIdentifiersScoresAndStatistics(int seed)
    {
        var league = TestData.League();
        var game = TestData.Game(5);
        var simulator = new SimpleGameSimulatorV1(random: new Random(seed));

        var result = simulator.SimulateGame(league, game);

        Assert.Equal((5, "A", "B"), (result.WeekNumber, result.HomeTeamId, result.AwayTeamId));
        Assert.NotEqual(result.HomeStats.Points, result.AwayStats.Points);
        Assert.NotNull(league.GetTeamById(result.WinnerTeamId));
        Assert.Equal(result.HomeStats.Points > result.AwayStats.Points ? "A" : "B", result.WinnerTeamId);
        foreach (var stats in new[] { result.HomeStats, result.AwayStats })
        {
            Assert.InRange(stats.Points, 6, 48); // Home tie breaker can add 3 after the 45-point clamp.
            Assert.InRange(stats.PassYards, 160, 340);
            Assert.InRange(stats.RushYards, 70, 180);
            Assert.InRange(stats.Turnovers, 0, 3);
            Assert.Equal(stats.PassYards + stats.RushYards, stats.TotalYards);
        }
        Assert.Empty(league.CompletedWeeks);
        Assert.All(league.Teams, t => Assert.Equal(0, t.Record.Wins + t.Record.Losses));
    }

    [Fact]
    public void SimulateGame_IdenticalSeedAndInputsProduceIdenticalStatistics()
    {
        var league = TestData.League();
        var game = TestData.Game();

        var first = new SimpleGameSimulatorV1(random: new Random(42)).SimulateGame(league, game);
        var second = new SimpleGameSimulatorV1(random: new Random(42)).SimulateGame(league, game);

        Assert.Equal(System.Text.Json.JsonSerializer.Serialize(first), System.Text.Json.JsonSerializer.Serialize(second));
    }

    [Theory]
    [InlineData(OffenseFocus.Balanced, 20, 160, 70, 0)]
    [InlineData(OffenseFocus.RunFocus, 21, 145, 90, 0)]
    [InlineData(OffenseFocus.PassFocus, 21, 185, 55, 0)]
    [InlineData(OffenseFocus.Conservative, 18, 155, 70, 0)]
    [InlineData(OffenseFocus.Aggressive, 23, 170, 70, 0)]
    public void SimulateGame_ControlledRandomAppliesOffenseGameplan(
        OffenseFocus focus, int points, int passYards, int rushYards, int turnovers)
    {
        var league = TestData.League();
        league.Teams[0].OffenseRating = 90; // Avoid score ties and clamping masking modifiers.
        var simulator = new SimpleGameSimulatorV1(
            t => t.Id == "A" ? new() { OffenseFocus = focus } : null, new MinimumRandom());

        var result = simulator.SimulateGame(league, TestData.Game());

        Assert.Equal((points, passYards, rushYards, turnovers),
            (result.HomeStats.Points, result.HomeStats.PassYards, result.HomeStats.RushYards, result.HomeStats.Turnovers));
        Assert.Equal(13, result.AwayStats.Points);
    }

    [Theory]
    [InlineData(DefenseFocus.Balanced, 20, 160, 70)]
    [InlineData(DefenseFocus.StopRun, 19, 160, 58)]
    [InlineData(DefenseFocus.StopPass, 19, 145, 70)]
    [InlineData(DefenseFocus.Conservative, 19, 155, 65)]
    [InlineData(DefenseFocus.Aggressive, 19, 160, 70)]
    public void SimulateGame_ControlledRandomAppliesOpposingDefenseGameplan(
        DefenseFocus focus, int points, int passYards, int rushYards)
    {
        var league = TestData.League();
        league.Teams[0].OffenseRating = 90;
        var simulator = new SimpleGameSimulatorV1(
            t => t.Id == "B" ? new() { DefenseFocus = focus } : null, new MinimumRandom());

        var result = simulator.SimulateGame(league, TestData.Game());

        Assert.Equal((points, passYards, rushYards),
            (result.HomeStats.Points, result.HomeStats.PassYards, result.HomeStats.RushYards));
    }

    [Theory]
    [InlineData(0, 99, 9, 6)]
    [InlineData(99, 0, 48, 45)]
    public void SimulateGame_ClampsScoresAndBreaksTiesForHomeTeam(
        int offense, int defense, int homePoints, int awayPoints)
    {
        var league = TestData.League();
        foreach (var team in league.Teams)
        {
            team.OffenseRating = offense;
            team.DefenseRating = defense;
        }
        var simulator = new SimpleGameSimulatorV1(random: new MaximumRandom());

        var result = simulator.SimulateGame(league, TestData.Game());

        Assert.Equal(homePoints, result.HomeStats.Points);
        Assert.Equal(awayPoints, result.AwayStats.Points);
        Assert.Equal("A", result.WinnerTeamId);
    }

    [Theory]
    [InlineData("missing", "B")]
    [InlineData("A", "missing")]
    public void SimulateGame_RejectsMissingTeam(string home, string away)
    {
        var league = TestData.League();
        var game = new ScheduledGame { HomeTeamId = home, AwayTeamId = away };
        var simulator = new SimpleGameSimulatorV1(random: new Random(42));

        Assert.Throws<InvalidOperationException>(() => simulator.SimulateGame(league, game));
    }

    // Each draw returns its lower bound, making effects independent of Random's sequence implementation.
    private sealed class MinimumRandom : Random
    {
        public override int Next(int minValue, int maxValue) => minValue;
    }

    private sealed class MaximumRandom : Random
    {
        public override int Next(int minValue, int maxValue) => maxValue - 1;
    }
}
