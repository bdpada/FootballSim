using System.Collections.Generic;
using System.Linq;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class TeamRatingCalculator
    {
        private readonly DepthChartService _depthChartService = new();

        public int CalculateOffenseRating(Team team)
        {
            if (team.DepthChart == null)
                return team.OffenseRating;

            var qb = GetAverageOverall(team, PlayerPosition.QB);
            var rb = GetAverageOverall(team, PlayerPosition.RB);
            var wr = GetAverageOverall(team, PlayerPosition.WR);
            var te = GetAverageOverall(team, PlayerPosition.TE);
            var c = GetAverageOverall(team, PlayerPosition.C);
            var g = GetAverageOverall(team, PlayerPosition.G);
            var t = GetAverageOverall(team, PlayerPosition.T);

            double weightedRating =
                (qb * 0.25) +
                (rb * 0.10) +
                (wr * 0.20) +
                (te * 0.10) +
                (c * 0.10) +
                (g * 0.125) +
                (t * 0.125);

            return (int)System.Math.Round(weightedRating);
        }

        public int CalculateDefenseRating(Team team)
        {
            if (team.DepthChart == null)
                return team.DefenseRating;

            var de = GetAverageOverall(team, PlayerPosition.DE);
            var dt = GetAverageOverall(team, PlayerPosition.DT);
            var ilb = GetAverageOverall(team, PlayerPosition.ILB);
            var olb = GetAverageOverall(team, PlayerPosition.OLB);
            var cb = GetAverageOverall(team, PlayerPosition.CB);
            var s = GetAverageOverall(team, PlayerPosition.S);

            double weightedRating =
                (de * 0.20) +
                (dt * 0.15) +
                (ilb * 0.175) +
                (olb * 0.175) +
                (cb * 0.15) +
                (s * 0.15);

            return (int)System.Math.Round(weightedRating);
        }

        public void ApplyCalculatedRatings(Team team)
        {
            team.OffenseRating = CalculateOffenseRating(team);
            team.DefenseRating = CalculateDefenseRating(team);
        }

        private double GetAverageOverall(Team team, PlayerPosition position)
        {
            if (team.DepthChart == null)
                return 0;

            List<Player> starters = _depthChartService.GetStarters(team.DepthChart, team.Roster, position);

            if (starters.Count == 0)
                return 0;

            return starters.Average(p => p.Overall);
        }
    }
}