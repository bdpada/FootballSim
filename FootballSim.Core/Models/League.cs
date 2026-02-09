using System.Collections.Generic;
using System.Linq;

namespace FootballSim.Core.Models
{
    public sealed class League
    {
        public List<Team> Teams { get; } = new();

        public Team? GetTeamById(string id)
            => Teams.FirstOrDefault(t => t.Id == id);
    }
}
