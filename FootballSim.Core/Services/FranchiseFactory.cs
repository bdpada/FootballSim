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

            var rosterGenerator = new RosterGenerator();
            var depthChartService = new DepthChartService();
            var teamRatingCalculator = new TeamRatingCalculator();

            foreach (var def in defs)
            {
                var team = new Team(def);

                rosterGenerator.GenerateRoster(team);
                team.DepthChart = depthChartService.CreateDefaultDepthChart(team.Roster);
                teamRatingCalculator.ApplyCalculatedRatings(team);

                // Debug test output for Arizona
                //if (team.Id == "ARI" && team.DepthChart != null)
                //{
                //    System.Diagnostics.Debug.WriteLine($"{team.Name} roster count: {team.Roster.Count}");

                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.QB);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.RB);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.WR);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.TE);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.C);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.G);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.T);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.DE);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.DT);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.ILB);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.OLB);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.CB);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.S);
                //    WriteDepthChartDebug(team, depthChartService, PlayerPosition.K);

                //    System.Diagnostics.Debug.WriteLine($"{team.Name} Offense Rating: {team.OffenseRating}");
                //    System.Diagnostics.Debug.WriteLine($"{team.Name} Defense Rating: {team.DefenseRating}");
                //    System.Diagnostics.Debug.WriteLine(string.Empty);

                //    var player = new Player("9999999999", "Test", "Player", PlayerPosition.QB, 99, 25, 2, team.Id);
                //    team.Roster.Add(player);
                //    team.DepthChart = depthChartService.CreateDefaultDepthChart(team.Roster);

                //    player.ApplyInjury(3);

                //    System.Diagnostics.Debug.WriteLine(player.ToString());
                //    // Should show: [OUT 3w]

                //    player.AdvanceWeek();
                //    System.Diagnostics.Debug.WriteLine(player.ToString());
                //    // Should show: [OUT 2w]
                //}

                league.Teams.Add(team);
            }

            CreateSimpleSchedule(league);

            return league;
        }

        public FranchiseState CreateNewFranchise(string userTeamId)
        {
            var league = CreateDefaultLeague();
            return new FranchiseState(league, userTeamId);
        }

        private void WriteDepthChartDebug(Team team, DepthChartService depthChartService, PlayerPosition position)
        {
            if (team.DepthChart == null)
                return;

            var playersAtPosition = team.DepthChart.GetPlayersAtPosition(position, team.Roster);
            var starters = depthChartService.GetStarters(team.DepthChart, team.Roster, position);

            System.Diagnostics.Debug.WriteLine($"--- {team.Name} {position} Depth Chart ---");

            for (int i = 0; i < playersAtPosition.Count; i++)
            {
                var player = playersAtPosition[i];
                System.Diagnostics.Debug.WriteLine($"{i + 1}. {player.FullName} - {player.Position} - OVR {player.Overall}");
            }

            System.Diagnostics.Debug.WriteLine($"Starters for {position}:");

            foreach (var starter in starters)
            {
                System.Diagnostics.Debug.WriteLine($"   {starter.FullName} - OVR {starter.Overall}");
            }

            System.Diagnostics.Debug.WriteLine(string.Empty);
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
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 1, HomeTeamId = ari.Id, AwayTeamId = lar.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 1, HomeTeamId = sea.Id, AwayTeamId = sf.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 1, HomeTeamId = dal.Id, AwayTeamId = nyg.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 1, HomeTeamId = phi.Id, AwayTeamId = was.Id });

            // Week 2
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 2, HomeTeamId = ari.Id, AwayTeamId = sea.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 2, HomeTeamId = lar.Id, AwayTeamId = sf.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 2, HomeTeamId = dal.Id, AwayTeamId = phi.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 2, HomeTeamId = nyg.Id, AwayTeamId = was.Id });

            // Week 3
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 3, HomeTeamId = ari.Id, AwayTeamId = sf.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 3, HomeTeamId = lar.Id, AwayTeamId = sea.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 3, HomeTeamId = dal.Id, AwayTeamId = was.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 3, HomeTeamId = nyg.Id, AwayTeamId = phi.Id });

            // Week 4
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 4, HomeTeamId = lar.Id, AwayTeamId = ari.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 4, HomeTeamId = sf.Id, AwayTeamId = sea.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 4, HomeTeamId = nyg.Id, AwayTeamId = dal.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 4, HomeTeamId = was.Id, AwayTeamId = phi.Id });

            // Week 5
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 5, HomeTeamId = sea.Id, AwayTeamId = ari.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 5, HomeTeamId = sf.Id, AwayTeamId = lar.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 5, HomeTeamId = phi.Id, AwayTeamId = dal.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 5, HomeTeamId = was.Id, AwayTeamId = nyg.Id });

            // Week 6
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 6, HomeTeamId = sf.Id, AwayTeamId = ari.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 6, HomeTeamId = sea.Id, AwayTeamId = lar.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 6, HomeTeamId = was.Id, AwayTeamId = dal.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 6, HomeTeamId = phi.Id, AwayTeamId = nyg.Id });

            // Week 7
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 7, HomeTeamId = ari.Id, AwayTeamId = dal.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 7, HomeTeamId = lar.Id, AwayTeamId = nyg.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 7, HomeTeamId = sea.Id, AwayTeamId = phi.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 7, HomeTeamId = sf.Id, AwayTeamId = was.Id });

            // Week 8
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 8, HomeTeamId = dal.Id, AwayTeamId = ari.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 8, HomeTeamId = nyg.Id, AwayTeamId = lar.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 8, HomeTeamId = phi.Id, AwayTeamId = sea.Id });
            league.Schedule.Games.Add(new ScheduledGame { WeekNumber = 8, HomeTeamId = was.Id, AwayTeamId = sf.Id });
        }
    }
}
