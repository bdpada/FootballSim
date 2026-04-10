using FootballSim.Core.Models;
using System;

namespace FootballSim.Core.Services
{
    public sealed class SimpleGameSimulatorV0 : IGameSimulator
    {
        private readonly Random _random;

        public SimpleGameSimulatorV0(Random? random = null)
        {
            _random = random ?? new Random();
        }

        public GameResult SimulateGame(League league, ScheduledGame scheduledGame)
        {
            var homeTeam = league.GetTeamById(scheduledGame.HomeTeamId);
            var awayTeam = league.GetTeamById(scheduledGame.AwayTeamId);

            if (homeTeam == null)
            {
                throw new InvalidOperationException(
                    $"Home team '{scheduledGame.HomeTeamId}' was not found in the league.");
            }

            if (awayTeam == null)
            {
                throw new InvalidOperationException(
                    $"Away team '{scheduledGame.AwayTeamId}' was not found in the league.");
            }

            int homeBase = CalculateBaseScore(
                homeTeam.OffenseRating,
                awayTeam.DefenseRating);

            int awayBase = CalculateBaseScore(
                awayTeam.OffenseRating,
                homeTeam.DefenseRating);

            int homeScore = ClampScore(homeBase + _random.Next(-7, 8));
            int awayScore = ClampScore(awayBase + _random.Next(-7, 8));

            // Prevent ties for MVP simplicity
            if (homeScore == awayScore)
            {
                homeScore += 3;
            }

            var homeStats = BuildStats(homeScore);
            var awayStats = BuildStats(awayScore);

            return new GameResult
            {
                WeekNumber = scheduledGame.WeekNumber,
                HomeTeamId = homeTeam.Id,
                AwayTeamId = awayTeam.Id,
                HomeStats = homeStats,
                AwayStats = awayStats
            };
        }

        private int CalculateBaseScore(int offenseRating, int opposingDefenseRating)
        {
            int offenseImpact = offenseRating / 3;
            int defenseImpact = opposingDefenseRating / 4;

            return 14 + offenseImpact - defenseImpact;
        }

        private int ClampScore(int score)
        {
            return Math.Max(6, Math.Min(score, 45));
        }

        private TeamGameStats BuildStats(int points)
        {
            int passYards = _random.Next(160, 341);
            int rushYards = _random.Next(70, 181);
            int turnovers = _random.Next(0, 4);

            return new TeamGameStats
            {
                Points = points,
                PassYards = passYards,
                RushYards = rushYards,
                Turnovers = turnovers
            };
        }
    }
}