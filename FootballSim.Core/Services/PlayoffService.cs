using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class PlayoffService
    {
        public void GeneratePlayoffSeeds(League league, int playoffTeamCount = 4)
        {
            league.PlayoffSeeds.Clear();

            var seededTeams = league.Teams
                .OrderByDescending(t => t.Record.Wins)
                .ThenBy(t => t.Record.Losses)
                .ThenByDescending(t => t.Record.PointsFor - t.Record.PointsAgainst)
                .ThenBy(t => t.Id)
                .Take(playoffTeamCount)
                .ToList();

            for (int i = 0; i < seededTeams.Count; i++)
            {
                league.PlayoffSeeds.Add(new PlayoffSeed
                {
                    SeedNumber = i + 1,
                    TeamId = seededTeams[i].Id
                });
            }
        }
    }
}