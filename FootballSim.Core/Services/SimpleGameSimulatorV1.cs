using FootballSim.Core.Models;
using System;

namespace FootballSim.Core.Services
{
    public sealed class SimpleGameSimulatorV1 : IGameSimulator
    {
        private readonly Random _random;
        private readonly Func<Team, WeeklyGameplan?>? _gameplanProvider;

        public SimpleGameSimulatorV1(
            Func<Team, WeeklyGameplan?>? gameplanProvider = null,
            Random? random = null)
        {
            _gameplanProvider = gameplanProvider;
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

            WeeklyGameplan? homeGameplan = _gameplanProvider?.Invoke(homeTeam);
            WeeklyGameplan? awayGameplan = _gameplanProvider?.Invoke(awayTeam);

            int homeBase = CalculateBaseScore(
                homeTeam.OffenseRating,
                awayTeam.DefenseRating);

            int awayBase = CalculateBaseScore(
                awayTeam.OffenseRating,
                homeTeam.DefenseRating);

            homeBase += GetOffensePointModifier(homeGameplan?.OffenseFocus ?? OffenseFocus.Balanced);
            awayBase += GetOffensePointModifier(awayGameplan?.OffenseFocus ?? OffenseFocus.Balanced);

            homeBase += GetDefensePointModifierAgainst(awayGameplan?.DefenseFocus ?? DefenseFocus.Balanced);
            awayBase += GetDefensePointModifierAgainst(homeGameplan?.DefenseFocus ?? DefenseFocus.Balanced);

            int homeScore = ClampScore(homeBase + _random.Next(-7, 8));
            int awayScore = ClampScore(awayBase + _random.Next(-7, 8));

            if (homeGameplan?.OffenseFocus == OffenseFocus.Conservative)
                homeScore = ClampScore(homeScore - 1);
            else if (homeGameplan?.OffenseFocus == OffenseFocus.Aggressive)
                homeScore = ClampScore(homeScore + 1);

            if (awayGameplan?.OffenseFocus == OffenseFocus.Conservative)
                awayScore = ClampScore(awayScore - 1);
            else if (awayGameplan?.OffenseFocus == OffenseFocus.Aggressive)
                awayScore = ClampScore(awayScore + 1);

            if (homeScore == awayScore)
            {
                homeScore += 3;
            }

            var homeStats = BuildStats(
                homeScore,
                homeGameplan?.OffenseFocus ?? OffenseFocus.Balanced,
                awayGameplan?.DefenseFocus ?? DefenseFocus.Balanced);

            var awayStats = BuildStats(
                awayScore,
                awayGameplan?.OffenseFocus ?? OffenseFocus.Balanced,
                homeGameplan?.DefenseFocus ?? DefenseFocus.Balanced);

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

        private int GetOffensePointModifier(OffenseFocus offenseFocus)
        {
            return offenseFocus switch
            {
                OffenseFocus.RunFocus => 1,
                OffenseFocus.PassFocus => 1,
                OffenseFocus.Conservative => -1,
                OffenseFocus.Aggressive => 2,
                _ => 0
            };
        }

        private int GetDefensePointModifierAgainst(DefenseFocus defenseFocus)
        {
            return defenseFocus switch
            {
                DefenseFocus.Conservative => -1,
                DefenseFocus.Aggressive => -1,
                DefenseFocus.StopRun => -1,
                DefenseFocus.StopPass => -1,
                _ => 0
            };
        }

        private int ClampScore(int score)
        {
            return Math.Max(6, Math.Min(score, 45));
        }

        private TeamGameStats BuildStats(int points, OffenseFocus offenseFocus, DefenseFocus opposingDefenseFocus)
        {
            int passYards = _random.Next(160, 341);
            int rushYards = _random.Next(70, 181);
            int turnovers = _random.Next(0, 4);

            switch (offenseFocus)
            {
                case OffenseFocus.RunFocus:
                    rushYards += _random.Next(20, 46);
                    passYards -= _random.Next(15, 36);
                    break;

                case OffenseFocus.PassFocus:
                    passYards += _random.Next(25, 56);
                    rushYards -= _random.Next(15, 31);
                    break;

                case OffenseFocus.Conservative:
                    passYards -= _random.Next(5, 16);
                    rushYards += _random.Next(0, 11);
                    turnovers = Math.Max(0, turnovers - 1);
                    break;

                case OffenseFocus.Aggressive:
                    passYards += _random.Next(10, 31);
                    rushYards += _random.Next(0, 16);
                    turnovers += _random.Next(0, 2);
                    break;
            }

            switch (opposingDefenseFocus)
            {
                case DefenseFocus.StopRun:
                    rushYards -= _random.Next(12, 31);
                    break;

                case DefenseFocus.StopPass:
                    passYards -= _random.Next(15, 36);
                    break;

                case DefenseFocus.Conservative:
                    passYards -= _random.Next(5, 16);
                    rushYards -= _random.Next(5, 16);
                    break;

                case DefenseFocus.Aggressive:
                    passYards -= _random.Next(0, 16);
                    rushYards -= _random.Next(0, 16);
                    turnovers += _random.Next(0, 2);
                    break;
            }

            passYards = Math.Max(80, passYards);
            rushYards = Math.Max(40, rushYards);
            turnovers = Math.Min(5, Math.Max(0, turnovers));

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