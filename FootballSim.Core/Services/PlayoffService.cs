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

        private void GenerateChampionshipMatchup(League league)
        {
            var semifinalWinners = league.PlayoffMatchups
                .Where(m => m.Round == PlayoffRound.Semifinal)
                .OrderBy(m => m.MatchupNumber)
                .Select(m => m.WinnerTeamId)
                .ToList();

            if (semifinalWinners.Count < 2)
            {
                throw new InvalidOperationException("Two semifinal winners are required to generate the championship matchup.");
            }

            league.PlayoffMatchups.Add(new PlayoffMatchup
            {
                Round = PlayoffRound.Championship,
                MatchupNumber = 1,
                HomeTeamId = semifinalWinners[0],
                AwayTeamId = semifinalWinners[1]
            });
        }

        private void AdvancePlayoffRoundIfNeeded(League league)
        {
            bool currentRoundComplete = league.PlayoffMatchups
                .Where(m => m.Round == league.CurrentPlayoffRound)
                .All(m => m.IsCompleted);

            if (!currentRoundComplete)
                return;

            if (league.CurrentPlayoffRound == PlayoffRound.Semifinal)
            {
                GenerateChampionshipMatchup(league);
                league.CurrentPlayoffRound = PlayoffRound.Championship;
            }
            else if (league.CurrentPlayoffRound == PlayoffRound.Championship)
            {
                var championship = league.PlayoffMatchups
                    .FirstOrDefault(m => m.Round == PlayoffRound.Championship);

                if (championship != null)
                {
                    league.ChampionTeamId = championship.WinnerTeamId;
                }
            }
        }

        public List<GameResult> SimulateCurrentPlayoffRound(
            League league,
            IGameSimulator gameSimulator)
        {
            var currentMatchups = league.PlayoffMatchups
                .Where(m => m.Round == league.CurrentPlayoffRound && !m.IsCompleted)
                .OrderBy(m => m.MatchupNumber)
                .ToList();

            var results = new List<GameResult>();

            foreach (var matchup in currentMatchups)
            {
                var scheduledGame = new ScheduledGame
                {
                    WeekNumber = 0,
                    HomeTeamId = matchup.HomeTeamId,
                    AwayTeamId = matchup.AwayTeamId
                };

                var result = gameSimulator.SimulateGame(league, scheduledGame);

                matchup.Result = result;
                matchup.WinnerTeamId =
                    result.HomeStats.Points > result.AwayStats.Points
                        ? result.HomeTeamId
                        : result.AwayTeamId;

                results.Add(result);
            }

            AdvancePlayoffRoundIfNeeded(league);

            return results;
        }
    }
}