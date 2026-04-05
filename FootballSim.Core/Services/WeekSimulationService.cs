using System;
using System.Collections.Generic;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class WeekSimulationService
    {
        private readonly IGameSimulator _gameSimulator;
        private readonly Random _random = new();

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

            // Players who were already injured recover by one week
            AdvancePlayerRecovery(franchise);

            // Apply a few new injuries from the simulated week
            ApplyWeeklyInjuries(franchise, scheduledGames);

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

        private void AdvancePlayerRecovery(FranchiseState franchise)
        {
            foreach (var team in franchise.League.Teams)
            {
                foreach (var player in team.Roster)
                {
                    player.AdvanceWeek();
                }
            }
        }

        private void ApplyWeeklyInjuries(FranchiseState franchise, List<ScheduledGame> scheduledGames)
        {
            foreach (var game in scheduledGames)
            {
                ApplyInjuriesToTeam(game.HomeTeam);
                ApplyInjuriesToTeam(game.AwayTeam);
            }
        }

        private void ApplyInjuriesToTeam(Team team)
        {
            foreach (var player in team.Roster)
            {
                if (player.IsInjured)
                {
                    continue;
                }

                // MVP injury chance: about 3% per healthy player per simulated week
                int injuryRoll = _random.Next(1, 101);

                if (injuryRoll <= 3)
                {
                    int injuryLength = _random.Next(1, 5); // 1 to 4 weeks
                    player.ApplyInjury(injuryLength);
                }
            }
        }
    }
}