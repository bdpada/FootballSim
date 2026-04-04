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

            CreateSimpleSchedule(league);

            return league;
        }

        public FranchiseState CreateNewFranchise(string userTeamId)
        {
            var league = CreateDefaultLeague();
            return new FranchiseState(league, userTeamId);
        }

        private void CreateSimpleSchedule(League league)
        {
            if (league.Teams.Count < 8)
                return;

            var ari = league.GetTeamById("ARI");
            var lar = league.GetTeamById("LAR");
            var sea = league.GetTeamById("SEA");
            var sf = league.GetTeamById("SF");
            var dal = league.GetTeamById("DAL");
            var nyg = league.GetTeamById("NYG");
            var phi = league.GetTeamById("PHI");
            var was = league.GetTeamById("WAS");

            if (ari == null || lar == null || sea == null || sf == null ||
                dal == null || nyg == null || phi == null || was == null)
            {
                return;
            }

            // Week 1
            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 1,
                HomeTeam = ari,
                AwayTeam = lar
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 1,
                HomeTeam = sea,
                AwayTeam = sf
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 1,
                HomeTeam = dal,
                AwayTeam = nyg
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 1,
                HomeTeam = phi,
                AwayTeam = was
            });

            // Week 2
            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 2,
                HomeTeam = ari,
                AwayTeam = sea
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 2,
                HomeTeam = lar,
                AwayTeam = sf
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 2,
                HomeTeam = dal,
                AwayTeam = phi
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 2,
                HomeTeam = nyg,
                AwayTeam = was
            });

            // Week 3
            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 3,
                HomeTeam = ari,
                AwayTeam = sf
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 3,
                HomeTeam = lar,
                AwayTeam = sea
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 3,
                HomeTeam = dal,
                AwayTeam = was
            });

            league.Schedule.Games.Add(new ScheduledGame
            {
                WeekNumber = 3,
                HomeTeam = nyg,
                AwayTeam = phi
            });
        }
    }
}
