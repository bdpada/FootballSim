using System.Collections.Generic;
using System.Linq;

namespace FootballSim.Core.Models
{
    public sealed class League
    {
        public List<Team> Teams { get; set; } = new();
        public LeagueSchedule Schedule { get; set; } = new();
        public List<WeekResult> CompletedWeeks { get; set; } = new();
        public List<Player> FreeAgents { get; set; } = new();
        public List<PlayoffSeed> PlayoffSeeds { get; set; } = new();

        public Team? GetTeamById(string id)
            => Teams.FirstOrDefault(t => t.Id == id);
    }
}
