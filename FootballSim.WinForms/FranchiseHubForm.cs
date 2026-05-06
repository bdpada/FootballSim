using FootballSim.Core.Models;
using FootballSim.Core.Services;
using FootballSim.WinForms.State;
using FootballSim.Persistence.Services;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class FranchiseHubForm : Form
    {
        private bool _isNavigatingToMainMenu = false;
        private bool _isLoadingGameplanControls = false;
        private readonly WeekSimulationService _weekSimulationService;
        private readonly DepthChartService _depthChartService = new();
        private readonly ISaveService _saveService = new JsonSaveService();

        private void LoadGameplanControls()
        {
            if (FranchiseContext.Current == null)
                return;

            _isLoadingGameplanControls = true;

            cmbOffenseFocus.DataSource = Enum.GetValues(typeof(OffenseFocus));
            cmbDefenseFocus.DataSource = Enum.GetValues(typeof(DefenseFocus));

            cmbOffenseFocus.SelectedItem = FranchiseContext.Current.WeeklyGameplan.OffenseFocus;
            cmbDefenseFocus.SelectedItem = FranchiseContext.Current.WeeklyGameplan.DefenseFocus;

            _isLoadingGameplanControls = false;
        }

        private void RefreshGameplanDisplay()
        {
            if (FranchiseContext.Current == null)
                return;

            _isLoadingGameplanControls = true;

            cmbOffenseFocus.SelectedItem = FranchiseContext.Current.WeeklyGameplan.OffenseFocus;
            cmbDefenseFocus.SelectedItem = FranchiseContext.Current.WeeklyGameplan.DefenseFocus;

            _isLoadingGameplanControls = false;
        }

        private void cmbOffenseFocus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingGameplanControls || FranchiseContext.Current == null)
                return;

            if (cmbOffenseFocus.SelectedItem is OffenseFocus offenseFocus)
            {
                FranchiseContext.Current.WeeklyGameplan.OffenseFocus = offenseFocus;
            }
        }

        private void cmbDefenseFocus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingGameplanControls || FranchiseContext.Current == null)
                return;

            if (cmbDefenseFocus.SelectedItem is DefenseFocus defenseFocus)
            {
                FranchiseContext.Current.WeeklyGameplan.DefenseFocus = defenseFocus;
            }
        }

        private WeeklyGameplan? GetWeeklyGameplanForTeam(Team team)
        {
            if (FranchiseContext.Current?.UserTeamId == team.Id)
            {
                return FranchiseContext.Current.WeeklyGameplan;
            }

            return null;
        }

        public FranchiseHubForm()
        {
            InitializeComponent();
            LoadGameplanControls();
            _weekSimulationService = new WeekSimulationService(new SimpleGameSimulatorV1(GetWeeklyGameplanForTeam));
            RefreshView();
        }

        private string BuildPlayoffSeedSummary()
        {
            var franchise = FranchiseContext.Current;

            if (franchise == null || franchise.League.PlayoffSeeds.Count == 0)
                return "Playoff field has not been set yet.";

            var sb = new StringBuilder();

            sb.AppendLine("Playoff Seeds");
            sb.AppendLine();

            foreach (var seed in franchise.League.PlayoffSeeds.OrderBy(s => s.SeedNumber))
            {
                var team = franchise.League.GetTeamById(seed.TeamId);

                if (team != null)
                {
                    sb.AppendLine($"{seed.SeedNumber}. {team.Name} ({team.Record})");
                }
            }

            return sb.ToString();
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
            RefreshGameplanDisplay();

            bool hasGamesRemaining = franchise.League.Schedule.GetGamesForWeek(franchise.CurrentWeek).Count > 0;

            if (franchise.SeasonPhase == SeasonPhase.RegularSeason)
            {
                btnSimWeek.Enabled = hasGamesRemaining;

                if (!hasGamesRemaining)
                {
                    lblWeek.Text += " - End of Regular Season";
                }
            }
            else if (franchise.SeasonPhase == SeasonPhase.Playoffs)
            {
                btnSimWeek.Enabled = false;
                lblWeek.Text = "Playoffs - Not Yet Implemented";
            }
            else if (franchise.SeasonPhase == SeasonPhase.SeasonComplete)
            {
                btnSimWeek.Enabled = false;
                lblWeek.Text = "Season Complete";
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
                bool hasInjuredStarters = _depthChartService.HasInjuredPlayersAboveHealthyStarters(team.DepthChart, team.Roster, position);
                bool hasEnoughHealthyPlayers = _depthChartService.HasEnoughHealthyPlayers(team.DepthChart, team.Roster, position);

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
                if (franchise.SeasonPhase == SeasonPhase.Playoffs)
                {
                    MessageBox.Show("Regular season complete. Entering playoffs.");
                    txtResults.Text = BuildPlayoffSeedSummary();
                }
                else
                {
                    MessageBox.Show("No games are scheduled for the current week.");
                }

                RefreshView();
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Week {weekResult.WeekNumber} Results");
            sb.AppendLine();

            foreach (var game in weekResult.Games)
            {
                var awayTeam = franchise.League.GetTeamById(game.AwayTeamId);
                var homeTeam = franchise.League.GetTeamById(game.HomeTeamId);

                if (awayTeam == null || homeTeam == null)
                    continue;

                sb.AppendLine($"{awayTeam.Name} {game.AwayStats.Points} - {game.HomeStats.Points} {homeTeam.Name}");
                sb.AppendLine($"   {awayTeam.Id}: {game.AwayStats.PassYards} pass, {game.AwayStats.RushYards} rush, {game.AwayStats.Turnovers} TO");
                sb.AppendLine($"   {homeTeam.Id}: {game.HomeStats.PassYards} pass, {game.HomeStats.RushYards} rush, {game.HomeStats.Turnovers} TO");
                sb.AppendLine();
            }

            var userTeamGame = weekResult.Games.FirstOrDefault(g =>
                g.HomeTeamId == franchise.UserTeamId || g.AwayTeamId == franchise.UserTeamId);

            if (userTeamGame != null)
            {
                var userAwayTeam = franchise.League.GetTeamById(userTeamGame.AwayTeamId);
                var userHomeTeam = franchise.League.GetTeamById(userTeamGame.HomeTeamId);

                if (userAwayTeam != null && userHomeTeam != null)
                {
                    sb.AppendLine("Your Team Result:");
                    sb.AppendLine($"{userAwayTeam.Name} {userTeamGame.AwayStats.Points} - {userTeamGame.HomeStats.Points} {userHomeTeam.Name}");
                    sb.AppendLine();
                }
            }

            sb.AppendLine(BuildUserTeamInjurySummary());

            if (franchise.SeasonPhase == SeasonPhase.Playoffs)
            {
                sb.AppendLine();
                sb.AppendLine("Regular season complete. Playoff field is set.");
                sb.AppendLine();
                sb.AppendLine(BuildPlayoffSeedSummary());
            }

            txtResults.Text = sb.ToString();

            RefreshView();
        }

        private void btnViewRoster_Click(object sender, EventArgs e)
        {
            using var rosterForm = new RosterForm();
            rosterForm.ShowDialog();

            RefreshView();
        }

        private void btnFreeAgency_Click(object sender, EventArgs e)
        {
            using var freeAgencyForm = new FreeAgencyForm();
            freeAgencyForm.ShowDialog();

            RefreshView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FranchiseContext.Current == null)
            {
                MessageBox.Show("No franchise loaded.");
                return;
            }

            using var saveGameForm = new SaveGameForm();
            var result = saveGameForm.ShowDialog();

            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(saveGameForm.SelectedSaveName))
                return;

            string saveName = saveGameForm.SelectedSaveName;

            try
            {
                if (_saveService.SaveExists(saveName))
                {
                    var overwriteResult = MessageBox.Show(
                        $"A save named '{saveName}' already exists. Overwrite it?",
                        "Confirm Overwrite",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (overwriteResult != DialogResult.Yes)
                        return;
                }

                _saveService.Save(saveName, FranchiseContext.Current);
                MessageBox.Show("Game saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save game:\n{ex.Message}");
            }
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