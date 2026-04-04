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

        public GameResult SimulateGame(ScheduledGame scheduledGame)
        {
            int homeBase = CalculateBaseScore(
                scheduledGame.HomeTeam.OffenseRating,
                scheduledGame.AwayTeam.DefenseRating);

            int awayBase = CalculateBaseScore(
                scheduledGame.AwayTeam.OffenseRating,
                scheduledGame.HomeTeam.DefenseRating);

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
                HomeTeam = scheduledGame.HomeTeam,
                AwayTeam = scheduledGame.AwayTeam,
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