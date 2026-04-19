using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FootballSim.Core.Models;
using FootballSim.Core.Services;
using FootballSim.WinForms.State;
using FootballSim.WinForms.Helpers;

namespace FootballSim.WinForms
{
    public partial class FreeAgencyForm : Form
    {
        private readonly TransactionService _transactionService = new();

        public FreeAgencyForm()
        {
            InitializeComponent();
            LoadPositionFilter();
            RefreshFreeAgentList();
        }

        private void LoadPositionFilter()
        {
            var filterOptions = new List<string> { "All" };
            filterOptions.AddRange(Enum.GetNames(typeof(PlayerPosition)));

            cmbPositionFilter.DataSource = filterOptions;
            cmbPositionFilter.SelectedIndex = 0;
        }

        private void RefreshFreeAgentList()
        {
            lstFreeAgents.Items.Clear();

            if (FranchiseContext.Current == null)
                return;

            IEnumerable<Player> freeAgents = FranchiseContext.Current.League.FreeAgents;

            if (cmbPositionFilter.SelectedItem is string selectedFilter &&
                selectedFilter != "All" &&
                Enum.TryParse<PlayerPosition>(selectedFilter, out var selectedPosition))
            {
                freeAgents = freeAgents.Where(p => p.Position == selectedPosition);
            }

            var ordered = freeAgents
                .OrderByDescending(p => p.Overall)
                .ThenBy(p => p.Position)
                .ThenBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            foreach (var player in ordered)
            {
                lstFreeAgents.Items.Add(player);
            }

            lblFreeAgentCount.Text = $"Free Agents: {ordered.Count}";
            lblSelectedPlayer.Text = "Selected: None";

            RefreshRosterCount();
        }

        private void RefreshRosterCount()
        {
            if (FranchiseContext.Current?.UserTeam == null)
            {
                lblRosterCount.Text = "Roster: N/A";
                return;
            }

            var team = FranchiseContext.Current.UserTeam;
            lblRosterCount.Text = $"Roster: {team.Roster.Count}/{TransactionService.MaxRosterSize}";
        }

        private void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFreeAgentList();
        }

        private void lstFreeAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFreeAgents.SelectedItem is Player player)
            {
                lblSelectedPlayer.Text =
                    $"Selected: {player.FullName} | {player.Position} | OVR {player.Overall} | Age {player.Age}";
            }
            else
            {
                lblSelectedPlayer.Text = "Selected: None";
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (FranchiseContext.Current?.UserTeam == null)
            {
                MessageBox.Show("No franchise or user team is loaded.");
                return;
            }

            if (lstFreeAgents.SelectedItem is not Player selectedPlayer)
            {
                MessageBox.Show("Please select a free agent to sign.");
                return;
            }

            var franchise = FranchiseContext.Current;
            var userTeam = franchise.UserTeam;

            bool success = _transactionService.SignFreeAgent(
                franchise.League,
                userTeam,
                selectedPlayer.Id,
                out string message);

            MessageBox.Show(message);

            RefreshFreeAgentList();
        }

        private void lstFreeAgents_DoubleClick(object sender, EventArgs e)
        {
            if (lstFreeAgents.SelectedItem is not Player selectedPlayer)
                return;

            PlayerFormHelper.ShowPlayerDetails(selectedPlayer);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}