using System.Collections.Generic;
using FootballSim.Core.Models;

namespace FootballSim.Core.Data
{
    public static class DefaultTeamCatalog
    {
        public static List<TeamDefinition> GetTeams()
        {
            //Iteration0.5 will move to JSON/DB later
            return new List<TeamDefinition>
            {
                new TeamDefinition("ARI", "Arizona"),
                new TeamDefinition("LAR", "Los Angeles"),
                new TeamDefinition("SEA", "Seattle"),
                new TeamDefinition("SF", "San Francisco"),
                new TeamDefinition("DAL", "Dallas"),
                new TeamDefinition("NYG", "New York"),
                new TeamDefinition("PHI", "Philadelphia"),
                new TeamDefinition("WAS", "Washington")
            };
        }
    }
}
