using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

internal static class TestData
{
    public static Player Player(string id = "player", PlayerPosition position = PlayerPosition.QB,
        int overall = 70, string teamId = "A") => new(id, "Test", id, position, 25, 3, teamId)
        {
            Overall = overall, Speed = 40, Strength = 50, Awareness = 60,
            Stamina = 70, Durability = 80, ThrowAccuracy = 90, ThrowPower = 100,
            Catching = 30, RouteRunning = 20, Blocking = 10, Tackling = 85,
            Coverage = 75, Kicking = 95
        };

    public static League League() => new()
    {
        Teams = [new(new("A", "Alpha")), new(new("B", "Bravo")),
                 new(new("C", "Charlie")), new(new("D", "Delta"))],
        Schedule = new() { Games = [Game(1), Game(2)] }
    };

    public static ScheduledGame Game(int week = 1) => new()
        { WeekNumber = week, HomeTeamId = "A", AwayTeamId = "B" };
}

// Controls scores and captures delegation without invoking random gameplay or injuries.
internal sealed class FixedGameSimulator(int homePoints = 24, int awayPoints = 10) : IGameSimulator
{
    public List<ScheduledGame> Calls { get; } = [];

    public GameResult SimulateGame(League league, ScheduledGame game)
    {
        Calls.Add(game);
        return new()
        {
            WeekNumber = game.WeekNumber, HomeTeamId = game.HomeTeamId, AwayTeamId = game.AwayTeamId,
            HomeStats = new() { Points = homePoints, PassYards = 200, RushYards = 100, Turnovers = 1 },
            AwayStats = new() { Points = awayPoints, PassYards = 150, RushYards = 80, Turnovers = 2 }
        };
    }
}
