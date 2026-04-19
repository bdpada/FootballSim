using FootballSim.Core.Models;
using FootballSim.Core.Services;
using FootballSim.WinForms.State;
using FootballSim.WinForms.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class RosterForm : Form
    {
        private readonly DepthChartService _depthChartService = new();
        private readonly TeamRatingCalculator _teamRatingCalculator = new();
        private readonly TransactionService _transactionService = new();

        public RosterForm()
        {
            InitializeComponent();
            LoadPositions();
            RefreshView();
        }

        private void LoadPositions()
        {
            cmbPositions.DataSource = Enum.GetValues(typeof(PlayerPosition));
        }

        private void RefreshView()
        {
            if (FranchiseContext.Current?.UserTeam == null)
            {
                MessageBox.Show("No user team loaded.");
                Close();
                return;
            }

            var team = FranchiseContext.Current.UserTeam;
            lblTeamName.Text = $"Roster - {team.Name}";
            lblRosterSize.Text = $"Roster: {team.Roster.Count}/{TransactionService.MaxRosterSize}";

            RefreshPlayerList();
        }

        private void RefreshPlayerList()
        {
            lstPlayers.Items.Clear();

            var team = FranchiseContext.Current?.UserTeam;
            if (team?.DepthChart == null)
                return;

            if (cmbPositions.SelectedItem is not PlayerPosition position)
                return;

            var players = team.DepthChart.GetPlayersAtPosition(position, team.Roster);
            var starters = _depthChartService.GetStarters(team.DepthChart, team.Roster, position);
            var starterIds = starters.Select(p => p.Id).ToHashSet();

            foreach (var player in players)
            {
                bool isStarter = starterIds.Contains(player.Id);

                string roleTag = isStarter ? "[Starter] " : "          ";
                string injuryTag = player.IsInjured ? $" [OUT {player.InjuryWeeksRemaining}w]" : "";

                if (isStarter && player.IsInjured)
                {
                    roleTag = "[Starter-OUT] ";
                }

                lstPlayers.Items.Add(
                    new PlayerListItem(
                        player,
                        $"{roleTag}{player.FullName} - {player.Position} - OVR {player.Overall}{injuryTag}"
                    )
                );
            }
        }

        private void cmbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPlayerList();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedPlayer(up: true);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedPlayer(up: false);
        }

        private void MoveSelectedPlayer(bool up)
        {
            var team = FranchiseContext.Current?.UserTeam;
            if (team?.DepthChart == null)
                return;

            if (cmbPositions.SelectedItem is not PlayerPosition position)
                return;

            if (lstPlayers.SelectedItem is not PlayerListItem selectedItem)
                return;

            bool moved = up
                ? _depthChartService.MovePlayerUp(team.DepthChart, team.Roster, position, selectedItem.Player.Id)
                : _depthChartService.MovePlayerDown(team.DepthChart, team.Roster, position, selectedItem.Player.Id);

            if (!moved)
                return;

            _teamRatingCalculator.ApplyCalculatedRatings(team);
            RefreshPlayerList();

            ReselectPlayer(selectedItem.Player.Id);
        }

        private void ReselectPlayer(string playerId)
        {
            for (int i = 0; i < lstPlayers.Items.Count; i++)
            {
                if (lstPlayers.Items[i] is PlayerListItem item && item.Player.Id == playerId)
                {
                    lstPlayers.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnAutoFixPosition_Click(object sender, EventArgs e)
        {
            var team = FranchiseContext.Current?.UserTeam;
            if (team?.DepthChart == null)
                return;

            if (cmbPositions.SelectedItem is not PlayerPosition position)
                return;

            bool changed = _depthChartService.AutoFixPosition(team.DepthChart, team.Roster, position);

            if (changed)
            {
                _teamRatingCalculator.ApplyCalculatedRatings(team);
                RefreshPlayerList();
                MessageBox.Show($"{position} depth chart auto-fixed.", "Auto Fix Complete");
            }
            else
            {
                MessageBox.Show($"{position} depth chart did not need any changes.", "Auto Fix");
            }
        }

        private void btnAutoFixAll_Click(object sender, EventArgs e)
        {
            var team = FranchiseContext.Current?.UserTeam;
            if (team?.DepthChart == null)
                return;

            bool changed = _depthChartService.AutoFixAllPositions(team.DepthChart, team.Roster);

            if (changed)
            {
                _teamRatingCalculator.ApplyCalculatedRatings(team);
                RefreshPlayerList();
                MessageBox.Show("All position groups were auto-fixed.", "Auto Fix Complete");
            }
            else
            {
                MessageBox.Show("No lineup changes were needed.", "Auto Fix");
            }
        }

        private void lstPlayers_DoubleClick(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem is not PlayerListItem selectedItem)
                return;

            PlayerFormHelper.ShowPlayerDetails(selectedItem.Player);
        }

        private void btnCutPlayer_Click(object sender, EventArgs e)
        {
            var franchise = FranchiseContext.Current;
            var team = franchise?.UserTeam;

            if (team == null)
            {
                MessageBox.Show("No team loaded.");
                return;
            }

            if (lstPlayers.SelectedItem is not PlayerListItem selectedItem)
            {
                MessageBox.Show("Select a player to cut.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to release {selectedItem.Player.FullName}?",
                "Confirm Cut",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            bool success = _transactionService.CutPlayer(
                franchise.League,
                team,
                selectedItem.Player.Id,
                out string message);

            MessageBox.Show(message);

            if (success)
            {
                RefreshView();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private sealed class PlayerListItem
        {
            public Player Player { get; }
            public string DisplayText { get; }

            public PlayerListItem(Player player, string displayText)
            {
                Player = player;
                DisplayText = displayText;
            }

            public override string ToString() => DisplayText;
        }
    }
}