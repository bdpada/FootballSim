using System;
using System.Collections.Generic;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class WeekSimulationService
    {
        private readonly IGameSimulator _gameSimulator;
        private readonly Random _random = new();
        private readonly PlayoffService _playoffService = new();

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
                if (franchise.SeasonPhase == SeasonPhase.RegularSeason)
                {
                    _playoffService.GeneratePlayoffSeeds(franchise.League);
                    _playoffService.GenerateSemifinalMatchups(franchise.League);
                    franchise.SeasonPhase = SeasonPhase.Playoffs;
                }

                return null;
            }

            var weekResult = new WeekResult
            {
                WeekNumber = currentWeek
            };

            foreach (var scheduledGame in scheduledGames)
            {
                var result = _gameSimulator.SimulateGame(franchise.League, scheduledGame);
                weekResult.Games.Add(result);

                ApplyResultToRecords(franchise.League, result);
            }

            // Players who were already injured recover by one week
            AdvancePlayerRecovery(franchise);

            // Apply a few new injuries from the simulated week
            ApplyWeeklyInjuries(franchise, scheduledGames);

            franchise.League.CompletedWeeks.Add(weekResult);
            franchise.CurrentWeek++;

            if (franchise.SeasonPhase == SeasonPhase.RegularSeason)
            {
                bool hasNextRegularSeasonWeek =
                    franchise.League.Schedule.GetGamesForWeek(franchise.CurrentWeek).Count > 0;

                if (!hasNextRegularSeasonWeek)
                {
                    _playoffService.GeneratePlayoffSeeds(franchise.League);
                    _playoffService.GenerateSemifinalMatchups(franchise.League);
                    franchise.SeasonPhase = SeasonPhase.Playoffs;
                }
            }

            return weekResult;
        }

        private void ApplyResultToRecords(League league, GameResult result)
        {
            var home = league.GetTeamById(result.HomeTeamId);
            var away = league.GetTeamById(result.AwayTeamId);

            if (home == null)
            {
                throw new InvalidOperationException(
                    $"Home team '{result.HomeTeamId}' was not found in the league.");
            }

            if (away == null)
            {
                throw new InvalidOperationException(
                    $"Away team '{result.AwayTeamId}' was not found in the league.");
            }

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
                var homeTeam = franchise.League.GetTeamById(game.HomeTeamId);
                var awayTeam = franchise.League.GetTeamById(game.AwayTeamId);

                if (homeTeam == null)
                {
                    throw new InvalidOperationException(
                        $"Home team '{game.HomeTeamId}' was not found in the league.");
                }

                if (awayTeam == null)
                {
                    throw new InvalidOperationException(
                        $"Away team '{game.AwayTeamId}' was not found in the league.");
                }

                ApplyInjuriesToTeam(homeTeam);
                ApplyInjuriesToTeam(awayTeam);
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

        public List<GameResult> SimulatePlayoffRound(FranchiseState franchise)
        {
            if (franchise.SeasonPhase != SeasonPhase.Playoffs)
            {
                throw new InvalidOperationException("Cannot simulate playoff round unless franchise is in Playoffs phase.");
            }

            var results = _playoffService.SimulateCurrentPlayoffRound(
                franchise.League,
                _gameSimulator);

            if (!string.IsNullOrWhiteSpace(franchise.League.ChampionTeamId))
            {
                franchise.SeasonPhase = SeasonPhase.SeasonComplete;
            }

            return results;
        }
    }
}