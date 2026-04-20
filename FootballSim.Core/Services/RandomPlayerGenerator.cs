using FootballSim.Core.Models;
using System;

namespace FootballSim.Core.Services
{
    public sealed class RandomPlayerGenerator
    {
        private readonly Random _random = new();

        private static readonly string[] FirstNames =
        {
            "John", "Mike", "Chris", "James", "Robert", "David", "Daniel", "Marcus"
        };

        private static readonly string[] LastNames =
        {
            "Smith", "Johnson", "Brown", "Williams", "Jones", "Miller", "Davis", "Wilson"
        };

        private QualityTier RollTier()
        {
            int roll = _random.Next(1, 101); // 1–100

            if (roll <= 5) return QualityTier.Elite;
            if (roll <= 20) return QualityTier.Star;
            if (roll <= 40) return QualityTier.Good;
            if (roll <= 80) return QualityTier.Average;
            return QualityTier.Bad;
        }

        private QualityTier RollFreeAgentTier()
        {
            int roll = _random.Next(1, 101); // 1–100

            if (roll <= 1) return QualityTier.Star;      // 1%
            if (roll <= 8) return QualityTier.Good;      // 7%
            if (roll <= 38) return QualityTier.Average;  // 30%
            return QualityTier.Bad;                      // 62%
        }

        private int GetBiasedValue(int min, int max, QualityTier tier)
        {
            int range = max - min;

            int adjustedMin = min;
            int adjustedMax = max;

            switch (tier)
            {
                case QualityTier.Elite:
                    adjustedMin = min + (int)(range * 0.70);
                    break;

                case QualityTier.Star:
                    adjustedMin = min + (int)(range * 0.50);
                    break;

                case QualityTier.Good:
                    adjustedMin = min + (int)(range * 0.30);
                    adjustedMax = min + (int)(range * 0.90);
                    break;

                case QualityTier.Average:
                    // full range
                    break;

                case QualityTier.Bad:
                    adjustedMax = min + (int)(range * 0.50);
                    break;
            }

            int value = _random.Next(adjustedMin, adjustedMax + 1);

            // Apply ±5 variation
            int variation = _random.Next(-5, 6);
            value += variation;

            return Math.Clamp(value, min, max);
        }

        private PositionGroup GetPositionGroup(PlayerPosition position)
        {
            return position switch
            {
                PlayerPosition.QB => PositionGroup.QB,
                PlayerPosition.RB => PositionGroup.RB,
                PlayerPosition.WR => PositionGroup.WR,
                PlayerPosition.TE => PositionGroup.TE,

                PlayerPosition.C or PlayerPosition.G or PlayerPosition.T => PositionGroup.OL,

                PlayerPosition.DE or PlayerPosition.DT => PositionGroup.DL,
                PlayerPosition.ILB or PlayerPosition.OLB => PositionGroup.LB,
                PlayerPosition.CB or PlayerPosition.S => PositionGroup.DB,

                PlayerPosition.K => PositionGroup.K,

                _ => PositionGroup.RB
            };
        }

        private void AssignAttributes(Player player)
        {
            var tier = player.Tier;
            var group = GetPositionGroup(player.Position);

            switch (group)
            {
                case PositionGroup.QB:
                    player.Speed = GetBiasedValue(45, 85, tier);
                    player.Strength = GetBiasedValue(40, 65, tier);
                    player.Awareness = GetBiasedValue(60, 90, tier);
                    player.Stamina = GetBiasedValue(60, 85, tier);
                    player.Durability = GetBiasedValue(55, 85, tier);
                    player.ThrowAccuracy = GetBiasedValue(70, 95, tier);
                    player.ThrowPower = GetBiasedValue(65, 95, tier);
                    player.Catching = GetBiasedValue(20, 45, tier);
                    player.RouteRunning = GetBiasedValue(15, 35, tier);
                    player.Blocking = GetBiasedValue(15, 35, tier);
                    player.Tackling = GetBiasedValue(15, 35, tier);
                    player.Coverage = GetBiasedValue(10, 30, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.RB:
                    player.Speed = GetBiasedValue(65, 99, tier);
                    player.Strength = GetBiasedValue(50, 80, tier);
                    player.Awareness = GetBiasedValue(55, 85, tier);
                    player.Stamina = GetBiasedValue(65, 90, tier);
                    player.Durability = GetBiasedValue(55, 85, tier);
                    player.ThrowAccuracy = GetBiasedValue(10, 30, tier);
                    player.ThrowPower = GetBiasedValue(10, 30, tier);
                    player.Catching = GetBiasedValue(45, 75, tier);
                    player.RouteRunning = GetBiasedValue(35, 65, tier);
                    player.Blocking = GetBiasedValue(30, 60, tier);
                    player.Tackling = GetBiasedValue(15, 35, tier);
                    player.Coverage = GetBiasedValue(10, 30, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.WR:
                    player.Speed = GetBiasedValue(70, 99, tier);
                    player.Strength = GetBiasedValue(35, 65, tier);
                    player.Awareness = GetBiasedValue(50, 80, tier);
                    player.Stamina = GetBiasedValue(60, 90, tier);
                    player.Durability = GetBiasedValue(50, 80, tier);
                    player.ThrowAccuracy = GetBiasedValue(10, 25, tier);
                    player.ThrowPower = GetBiasedValue(10, 25, tier);
                    player.Catching = GetBiasedValue(65, 95, tier);
                    player.RouteRunning = GetBiasedValue(65, 95, tier);
                    player.Blocking = GetBiasedValue(25, 50, tier);
                    player.Tackling = GetBiasedValue(15, 35, tier);
                    player.Coverage = GetBiasedValue(10, 30, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.TE:
                    player.Speed = GetBiasedValue(45, 85, tier);
                    player.Strength = GetBiasedValue(55, 85, tier);
                    player.Awareness = GetBiasedValue(55, 85, tier);
                    player.Stamina = GetBiasedValue(60, 85, tier);
                    player.Durability = GetBiasedValue(60, 90, tier);
                    player.ThrowAccuracy = GetBiasedValue(10, 25, tier);
                    player.ThrowPower = GetBiasedValue(10, 25, tier);
                    player.Catching = GetBiasedValue(55, 85, tier);
                    player.RouteRunning = GetBiasedValue(45, 75, tier);
                    player.Blocking = GetBiasedValue(55, 85, tier);
                    player.Tackling = GetBiasedValue(20, 40, tier);
                    player.Coverage = GetBiasedValue(10, 30, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.OL:
                    player.Speed = GetBiasedValue(25, 65, tier);
                    player.Strength = GetBiasedValue(70, 95, tier);
                    player.Awareness = GetBiasedValue(55, 85, tier);
                    player.Stamina = GetBiasedValue(60, 90, tier);
                    player.Durability = GetBiasedValue(65, 95, tier);
                    player.ThrowAccuracy = GetBiasedValue(5, 20, tier);
                    player.ThrowPower = GetBiasedValue(5, 20, tier);
                    player.Catching = GetBiasedValue(10, 30, tier);
                    player.RouteRunning = GetBiasedValue(5, 20, tier);
                    player.Blocking = GetBiasedValue(70, 95, tier);
                    player.Tackling = GetBiasedValue(25, 45, tier);
                    player.Coverage = GetBiasedValue(5, 20, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.DL:
                    player.Speed = GetBiasedValue(40, 82, tier);
                    player.Strength = GetBiasedValue(65, 95, tier);
                    player.Awareness = GetBiasedValue(50, 80, tier);
                    player.Stamina = GetBiasedValue(55, 85, tier);
                    player.Durability = GetBiasedValue(60, 90, tier);
                    player.ThrowAccuracy = GetBiasedValue(5, 20, tier);
                    player.ThrowPower = GetBiasedValue(5, 20, tier);
                    player.Catching = GetBiasedValue(10, 30, tier);
                    player.RouteRunning = GetBiasedValue(5, 20, tier);
                    player.Blocking = GetBiasedValue(25, 50, tier);
                    player.Tackling = GetBiasedValue(65, 95, tier);
                    player.Coverage = GetBiasedValue(15, 35, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.LB:
                    player.Speed = GetBiasedValue(50, 88, tier);
                    player.Strength = GetBiasedValue(55, 85, tier);
                    player.Awareness = GetBiasedValue(55, 85, tier);
                    player.Stamina = GetBiasedValue(55, 85, tier);
                    player.Durability = GetBiasedValue(55, 85, tier);
                    player.ThrowAccuracy = GetBiasedValue(5, 20, tier);
                    player.ThrowPower = GetBiasedValue(5, 20, tier);
                    player.Catching = GetBiasedValue(20, 45, tier);
                    player.RouteRunning = GetBiasedValue(10, 30, tier);
                    player.Blocking = GetBiasedValue(20, 45, tier);
                    player.Tackling = GetBiasedValue(65, 95, tier);
                    player.Coverage = GetBiasedValue(45, 75, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.DB:
                    player.Speed = GetBiasedValue(65, 99, tier);
                    player.Strength = GetBiasedValue(35, 65, tier);
                    player.Awareness = GetBiasedValue(55, 85, tier);
                    player.Stamina = GetBiasedValue(55, 85, tier);
                    player.Durability = GetBiasedValue(50, 80, tier);
                    player.ThrowAccuracy = GetBiasedValue(5, 20, tier);
                    player.ThrowPower = GetBiasedValue(5, 20, tier);
                    player.Catching = GetBiasedValue(45, 75, tier);
                    player.RouteRunning = GetBiasedValue(35, 65, tier);
                    player.Blocking = GetBiasedValue(15, 35, tier);
                    player.Tackling = GetBiasedValue(50, 80, tier);
                    player.Coverage = GetBiasedValue(65, 95, tier);
                    player.Kicking = GetBiasedValue(5, 20, tier);
                    break;

                case PositionGroup.K:
                    player.Speed = GetBiasedValue(20, 50, tier);
                    player.Strength = GetBiasedValue(30, 60, tier);
                    player.Awareness = GetBiasedValue(50, 80, tier);
                    player.Stamina = GetBiasedValue(55, 85, tier);
                    player.Durability = GetBiasedValue(50, 80, tier);
                    player.ThrowAccuracy = GetBiasedValue(5, 20, tier);
                    player.ThrowPower = GetBiasedValue(5, 20, tier);
                    player.Catching = GetBiasedValue(10, 30, tier);
                    player.RouteRunning = GetBiasedValue(5, 20, tier);
                    player.Blocking = GetBiasedValue(10, 25, tier);
                    player.Tackling = GetBiasedValue(10, 25, tier);
                    player.Coverage = GetBiasedValue(5, 20, tier);
                    player.Kicking = GetBiasedValue(70, 95, tier);
                    break;
            }
        }

        public Player CreatePlayer(PlayerPosition position, string teamId)
        {
            var firstName = FirstNames[_random.Next(FirstNames.Length)];
            var lastName = LastNames[_random.Next(LastNames.Length)];

            int age = _random.Next(21, 33);
            int yearsPro = Math.Max(0, age - (21 + _random.Next(0, 3)));

            var player = new Player(
                Guid.NewGuid().ToString(),
                firstName,
                lastName,
                position,
                age,
                yearsPro,
                teamId
            );

            player.Tier = RollTier();

            AssignAttributes(player);

            player.Overall = PlayerOverallCalculator.Calculate(player);

            return player;
        }

        public Player CreateFreeAgentPlayer(PlayerPosition position)
        {
            var firstName = FirstNames[_random.Next(FirstNames.Length)];
            var lastName = LastNames[_random.Next(LastNames.Length)];

            // Free agents skew a little older than rostered players
            int age = _random.Next(24, 34);
            int yearsPro = Math.Max(0, age - (21 + _random.Next(0, 3)));

            var player = new Player(
                Guid.NewGuid().ToString(),
                firstName,
                lastName,
                position,
                age,
                yearsPro,
                string.Empty
            );

            player.Tier = RollFreeAgentTier();

            AssignAttributes(player);

            player.Overall = PlayerOverallCalculator.Calculate(player);

            return player;
        }
    }
}