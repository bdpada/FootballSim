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

            var playersAtPosition = team.DepthChart.GetPlayersAtPosition(position);
            var starters = depthChartService.GetStarters(team.DepthChart, position);

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
