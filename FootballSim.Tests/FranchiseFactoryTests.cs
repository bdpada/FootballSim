using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class FranchiseFactoryTests
{
    [Fact]
    public void CreateNewFranchise_InitializesLeagueAndUserTeam()
    {
        var factory = new FranchiseFactory();

        var franchise = factory.CreateNewFranchise("ARI");

        Assert.Equal(1, franchise.CurrentWeek);
        Assert.Equal(SeasonPhase.RegularSeason, franchise.SeasonPhase);
        Assert.Same(franchise.League.GetTeamById("ARI"), franchise.UserTeam);
        Assert.Equal(new[] { "ARI", "DAL", "LAR", "NYG", "PHI", "SEA", "SF", "WAS" },
            franchise.League.Teams.Select(t => t.Id).OrderBy(id => id));
        Assert.Empty(franchise.League.CompletedWeeks);
        Assert.Empty(franchise.League.PlayoffSeeds);
        Assert.Empty(franchise.League.ChampionTeamId);
    }

    [Fact]
    public void CreateDefaultLeague_GeneratesFullRostersAndUniquePlayerIdentifiers()
    {
        int[] positionCounts = [3, 4, 6, 3, 2, 4, 4, 4, 4, 4, 4, 6, 4, 1];

        var league = new FranchiseFactory().CreateDefaultLeague();

        Assert.All(league.Teams, team =>
        {
            Assert.False(string.IsNullOrWhiteSpace(team.Name));
            Assert.Equal(53, team.Roster.Count);
            Assert.NotNull(team.DepthChart);
            foreach (var position in Enum.GetValues<PlayerPosition>())
                Assert.Equal(positionCounts[(int)position], team.Roster.Count(p => p.Position == position));
            Assert.All(team.Roster, player =>
            {
                Assert.Equal(team.Id, player.TeamId);
                Assert.InRange(player.Overall, 0, 99);
                Assert.Equal(PlayerOverallCalculator.Calculate(player), player.Overall);
            });
        });
        var players = league.Teams.SelectMany(t => t.Roster).Concat(league.FreeAgents).ToList();
        Assert.All(players, p => Assert.True(Guid.TryParse(p.Id, out _)));
        Assert.Equal(players.Count, players.Select(p => p.Id).Distinct().Count());
    }

    [Fact]
    public void CreateDefaultLeague_InitializesScheduleAndUnownedFreeAgents()
    {
        var factory = new FranchiseFactory();

        var league = factory.CreateDefaultLeague();

        Assert.Equal(100, league.FreeAgents.Count);
        Assert.All(league.FreeAgents, p => Assert.Equal(string.Empty, p.TeamId));
        Assert.Equal(32, league.Schedule.Games.Count);
        for (int week = 1; week <= 8; week++)
        {
            var games = league.Schedule.GetGamesForWeek(week);
            Assert.Equal(4, games.Count);
            Assert.Equal(8, games.SelectMany(g => new[] { g.HomeTeamId, g.AwayTeamId }).Distinct().Count());
            Assert.All(games, g =>
            {
                Assert.NotNull(league.GetTeamById(g.HomeTeamId));
                Assert.NotNull(league.GetTeamById(g.AwayTeamId));
                Assert.NotEqual(g.HomeTeamId, g.AwayTeamId);
            });
        }
    }
}
