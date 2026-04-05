using System.Collections.Generic;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public static class DepthChartRules
    {
        private static readonly Dictionary<PlayerPosition, int> StarterCounts = new()
        {
            { PlayerPosition.QB, 1 },
            { PlayerPosition.RB, 1 },
            { PlayerPosition.WR, 3 },
            { PlayerPosition.TE, 1 },
            { PlayerPosition.C, 1 },
            { PlayerPosition.G, 2 },
            { PlayerPosition.T, 2 },
            { PlayerPosition.DE, 2 },
            { PlayerPosition.DT, 2 },
            { PlayerPosition.ILB, 2 },
            { PlayerPosition.OLB, 2 },
            { PlayerPosition.CB, 2 },
            { PlayerPosition.S, 2 },
            { PlayerPosition.K, 1 }
        };

        public static int GetStarterCount(PlayerPosition position)
        {
            return StarterCounts.TryGetValue(position, out var count) ? count : 0;
        }
    }
}