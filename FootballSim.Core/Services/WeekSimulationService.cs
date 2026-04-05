using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class WeekSimulationService
    {
        private readonly IGameSimulator _gameSimulator;

        public WeekSimulationService(IGameSimulator gameSimulator)
        {
            _gameSimulator = gameSimulator;
        }

        public WeekResult? SimulateWeek(FranchiseState franchise)
        {
            int currentWeek = franchise.CurrentWeek;
            var scheduledGames = franchise.League.Schedule.GetGamesForWeek(currentWeek);

            if (scheduledGames.Count == 0)
            {
                return null;
            }

            var weekResult = new WeekResult
            {
                WeekNumber = currentWeek
            };

            foreach (var scheduledGame in scheduledGames)
            {
                var result = _gameSimulator.SimulateGame(scheduledGame);
                weekResult.Games.Add(result);

                ApplyResultToRecords(result);
            }

            franchise.League.CompletedWeeks.Add(weekResult);
            franchise.CurrentWeek++;

            return weekResult;
        }

        private void ApplyResultToRecords(GameResult result)
        {
            var home = result.HomeTeam;
            var away = result.AwayTeam;

            home.Record.PointsFor += result.HomeStats.Points;
            home.Record.PointsAgainst += result.AwayStats.Points;

            away.Record.PointsFor += result.AwayStats.Points;
            away.Record.PointsAgainst += result.HomeStats.Points;

            if (result.HomeStats.Points > result.AwayStats.Points)
            {
                home.Record.Wins++;
                away.Record.Losses++;
            }
            else
            {
                away.Record.Wins++;
                home.Record.Losses++;
            }
        }
    }
}