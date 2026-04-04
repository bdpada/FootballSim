using System.Collections.Generic;

namespace FootballSim.Core.Models
{
    public sealed class WeekResult
    {
        public int WeekNumber { get; set; }
        public List<GameResult> Games { get; set; } = new();
    }
}