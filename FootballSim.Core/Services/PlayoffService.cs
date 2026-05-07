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

        public void GenerateSemifinalMatchups(League league)
        {
            league.PlayoffMatchups.Clear();
            league.CurrentPlayoffRound = PlayoffRound.Semifinal;
            league.ChampionTeamId = string.Empty;

            var seeds = league.PlayoffSeeds
                .OrderBy(s => s.SeedNumber)
                .ToList();

            if (seeds.Count < 4)
            {
                throw new InvalidOperationException("At least 4 playoff seeds are required to generate semifinal matchups.");
            }

            league.PlayoffMatchups.Add(new PlayoffMatchup
            {
                Round = PlayoffRound.Semifinal,
                MatchupNumber = 1,
                HomeTeamId = seeds[0].TeamId, // 1 seed
                AwayTeamId = seeds[3].TeamId  // 4 seed
            });

            league.PlayoffMatchups.Add(new PlayoffMatchup
            {
                Round = PlayoffRound.Semifinal,
                MatchupNumber = 2,
                HomeTeamId = seeds[1].TeamId, // 2 seed
                AwayTeamId = seeds[2].TeamId  // 3 seed
            });
        }
    }
}