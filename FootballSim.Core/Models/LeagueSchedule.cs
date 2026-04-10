using System.Collections.Generic;
using System.Linq;

namespace FootballSim.Core.Models
{
    public sealed class LeagueSchedule
    {
        public List<ScheduledGame> Games { get; set; } = new();

        public List<ScheduledGame> GetGamesForWeek(int weekNumber)
        {
            return Games.Where(g => g.WeekNumber == weekNumber).ToList();
        }
    }
}