using FootballSim.Core.Data;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class FranchiseFactory
    {
        public League CreateDefaultLeague()
        {
            var defs = DefaultTeamCatalog.GetTeams(); //from iteration 0.5
            var league = new League();

            foreach (var def in defs)
                league.Teams.Add(new Team(def));

            return league;
        }

        public FranchiseState CreateNewFranchise(string userTeamId)
        {
            var league = CreateDefaultLeague();
            return new FranchiseState(league, userTeamId);
        }
    }
}
