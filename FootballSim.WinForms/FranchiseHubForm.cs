using FootballSim.Core.Models;
using FootballSim.Core.Services;
using FootballSim.WinForms.State;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class FranchiseHubForm : Form
    {
        private bool _isNavigatingToMainMenu = false;
        private readonly WeekSimulationService _weekSimulationService;
        private readonly DepthChartService _depthChartService = new();

        public FranchiseHubForm()
        {
            InitializeComponent();
            _weekSimulationService = new WeekSimulationService(new SimpleGameSimulatorV0());
            RefreshView();
        }

        private void RefreshView()
        {
            if (FranchiseContext.Current == null)
            {
                MessageBox.Show("No franchise loaded.");
                ReturnToMainMenu();
                return;
            }

            var franchise = FranchiseContext.Current;

            lblUserTeam.Text = $"User Team: {franchise.UserTeam?.Name} ({franchise.UserTeamId})";
            lblWeek.Text = $"Week: {franchise.CurrentWeek}";

            lblOffOvr.Text = $"Off OVR: {franchise.UserTeam?.OffenseRating ?? 0}";
            lblDefOvr.Text = $"Def OVR: {franchise.UserTeam?.DefenseRating ?? 0}";

            RefreshTeamStatus();
            RefreshStandings();

            bool hasGamesRemaining = franchise.League.Schedule.GetGamesForWeek(franchise.CurrentWeek).Count > 0;
            btnSimWeek.Enabled = hasGamesRemaining;

            if (!hasGamesRemaining)
            {
                lblWeek.Text += " - End of Schedule";
            }
        }

        private void RefreshStandings()
        {
            if (FranchiseContext.Current == null)
            {
                txtStandings.Text = string.Empty;
                return;
            }

            var franchise = FranchiseContext.Current;
            var standings = franchise.League.Teams
                .OrderByDescending(t => t.Record.Wins)
                .ThenBy(t => t.Record.Losses)
                .ThenByDescending(t => t.Record.PointsFor - t.Record.PointsAgainst)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("Standings");
            sb.AppendLine();

            foreach (var team in standings)
            {
                int pointDiff = team.Record.PointsFor - team.Record.PointsAgainst;

                sb.AppendLine(
                    $"{team.Id}  {team.Record.Wins}-{team.Record.Losses}-{team.Record.Ties}  " +
                    $"PF:{team.Record.PointsFor}  PA:{team.Record.PointsAgainst}  PD:{pointDiff}");
            }

            txtStandings.Text = sb.ToString();
        }

        private void RefreshTeamStatus()
        {
            if (FranchiseContext.Current?.UserTeam?.DepthChart == null)
            {
                txtTeamStatus.Text = "No team status available.";
                return;
            }

            var team = FranchiseContext.Current.UserTeam;
            var sb = new StringBuilder();

            sb.AppendLine("Team Status");
            sb.AppendLine();

            foreach (PlayerPosition position in Enum.GetValues(typeof(PlayerPosition)))
            {
                bool hasInjuredStarters = _depthChartService.HasInjuredPlayersAboveHealthyStarters(team.DepthChart, position);
                bool hasEnoughHealthyPlayers = _depthChartService.HasEnoughHealthyPlayers(team.DepthChart, position);

                if (hasInjuredStarters)
                {
                    sb.AppendLine($"{position}: injured player(s) in the top of the depth chart.");
                }

                if (!hasEnoughHealthyPlayers)
                {
                    sb.AppendLine($"{position}: not enough healthy players to fill starter slots.");
                }
            }

            if (sb.ToString().Trim() == "Team Status")
            {
                sb.AppendLine("No major roster concerns this week.");
            }

            txtTeamStatus.Text = sb.ToString();
        }

        private string BuildUserTeamInjurySummary()
        {
            if (FranchiseContext.Current?.UserTeam == null)
                return "No injury information available.";

            var team = FranchiseContext.Current.UserTeam;

            var injuredPlayers = team.Roster
                .Where(p => p.IsInjured)
                .OrderBy(p => p.Position)
                .ThenByDescending(p => p.Overall)
                .ToList();

            if (injuredPlayers.Count == 0)
            {
                return "No currently injured players on your team.";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Current Injuries:");

            foreach (var player in injuredPlayers)
            {
                sb.AppendLine($"- {player.FullName} ({player.Position}, OVR {player.Overall}) - Out {player.InjuryWeeksRemaining} week(s)");
            }

            return sb.ToString();
        }

        private void ReturnToMainMenu()
        {
            _isNavigatingToMainMenu = true;

            FranchiseContext.Clear();

            var menu = new MainMenuForm();
            menu.Show();
            Close();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        private void btnSimWeek_Click(object sender, EventArgs e)
        {
            if (FranchiseContext.Current == null)
            {
                MessageBox.Show("No franchise loaded.");
                return;
            }

            var franchise = FranchiseContext.Current;
            var weekResult = _weekSimulationService.SimulateWeek(franchise);

            if (weekResult == null)
            {
                MessageBox.Show("No games are scheduled for the current week.");
                RefreshView();
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Week {weekResult.WeekNumber} Results");
            sb.AppendLine();

            foreach (var game in weekResult.Games)
            {
                sb.AppendLine($"{game.AwayTeam.Name} {game.AwayStats.Points} - {game.HomeStats.Points} {game.HomeTeam.Name}");
                sb.AppendLine($"   {game.AwayTeam.Id}: {game.AwayStats.PassYards} pass, {game.AwayStats.RushYards} rush, {game.AwayStats.Turnovers} TO");
                sb.AppendLine($"   {game.HomeTeam.Id}: {game.HomeStats.PassYards} pass, {game.HomeStats.RushYards} rush, {game.HomeStats.Turnovers} TO");
                sb.AppendLine();
            }

            var userTeamGame = weekResult.Games.FirstOrDefault(g =>
                g.HomeTeam.Id == franchise.UserTeamId || g.AwayTeam.Id == franchise.UserTeamId);

            if (userTeamGame != null)
            {
                sb.AppendLine("Your Team Result:");
                sb.AppendLine($"{userTeamGame.AwayTeam.Name} {userTeamGame.AwayStats.Points} - {userTeamGame.HomeStats.Points} {userTeamGame.HomeTeam.Name}");
            }

            sb.AppendLine();
            sb.AppendLine(BuildUserTeamInjurySummary());

            txtResults.Text = sb.ToString();

            RefreshView();
        }

        private void btnViewRoster_Click(object sender, EventArgs e)
        {
            using var rosterForm = new RosterForm();
            rosterForm.ShowDialog();

            RefreshView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isNavigatingToMainMenu)
            {
                return;
            }

            Application.Exit();
        }
    }
}