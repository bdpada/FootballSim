using FootballSim.Core.Models;
using System;
using static FootballSim.Core.Services.RandomPlayerGenerator;

namespace FootballSim.Core.Services
{
    public static class PlayerOverallCalculator
    {
        public static int Calculate(Player player)
        {
            var group = GetPositionGroup(player.Position);

            double overall = group switch
            {
                PositionGroup.QB => CalculateQuarterback(player),
                PositionGroup.RB => CalculateRunningBack(player),
                PositionGroup.WR => CalculateWideReceiver(player),
                PositionGroup.TE => CalculateTightEnd(player),
                PositionGroup.OL => CalculateOffensiveLine(player),
                PositionGroup.DL => CalculateDefensiveLine(player),
                PositionGroup.LB => CalculateLinebacker(player),
                PositionGroup.DB => CalculateDefensiveBack(player),
                PositionGroup.K => CalculateKicker(player),
                _ => 50.0
            };

            return Math.Clamp((int)Math.Round(overall), 0, 99);
        }

        private static PositionGroup GetPositionGroup(PlayerPosition position)
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

        private static double CalculateQuarterback(Player p)
        {
            return
                (p.ThrowAccuracy * 0.30) +
                (p.ThrowPower * 0.20) +
                (p.Awareness * 0.20) +
                (p.Stamina * 0.10) +
                (p.Durability * 0.10) +
                (p.Speed * 0.05) +
                (p.Strength * 0.05);
        }

        private static double CalculateRunningBack(Player p)
        {
            return
                (p.Speed * 0.25) +
                (p.Awareness * 0.20) +
                (p.Strength * 0.15) +
                (p.Stamina * 0.15) +
                (p.Durability * 0.10) +
                (p.Catching * 0.10) +
                (p.Blocking * 0.05);
        }

        private static double CalculateWideReceiver(Player p)
        {
            return
                (p.Catching * 0.25) +
                (p.RouteRunning * 0.25) +
                (p.Speed * 0.20) +
                (p.Awareness * 0.10) +
                (p.Stamina * 0.10) +
                (p.Durability * 0.05) +
                (p.Strength * 0.05);
        }

        private static double CalculateTightEnd(Player p)
        {
            return
                (p.Catching * 0.20) +
                (p.RouteRunning * 0.15) +
                (p.Blocking * 0.25) +
                (p.Strength * 0.15) +
                (p.Awareness * 0.10) +
                (p.Stamina * 0.10) +
                (p.Durability * 0.05);
        }

        private static double CalculateOffensiveLine(Player p)
        {
            return
                (p.Blocking * 0.40) +
                (p.Strength * 0.25) +
                (p.Awareness * 0.15) +
                (p.Stamina * 0.10) +
                (p.Durability * 0.10);
        }

        private static double CalculateDefensiveLine(Player p)
        {
            return
                (p.Strength * 0.25) +
                (p.Tackling * 0.25) +
                (p.Awareness * 0.15) +
                (p.Stamina * 0.15) +
                (p.Durability * 0.10) +
                (p.Speed * 0.10);
        }

        private static double CalculateLinebacker(Player p)
        {
            return
                (p.Tackling * 0.30) +
                (p.Awareness * 0.20) +
                (p.Strength * 0.15) +
                (p.Coverage * 0.15) +
                (p.Speed * 0.10) +
                (p.Stamina * 0.05) +
                (p.Durability * 0.05);
        }

        private static double CalculateDefensiveBack(Player p)
        {
            return
                (p.Coverage * 0.30) +
                (p.Speed * 0.20) +
                (p.RouteRunning * 0.05) +
                (p.Awareness * 0.15) +
                (p.Tackling * 0.10) +
                (p.Catching * 0.10) +
                (p.Stamina * 0.05) +
                (p.Durability * 0.05);
        }

        private static double CalculateKicker(Player p)
        {
            return
                (p.Kicking * 0.50) +
                (p.Awareness * 0.15) +
                (p.Stamina * 0.15) +
                (p.Durability * 0.10) +
                (p.Strength * 0.05) +
                (p.Speed * 0.05);
        }
    }
}