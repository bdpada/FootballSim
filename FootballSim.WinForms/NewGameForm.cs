using FootballSim.Core.Data;
using FootballSim.Core.Models;
using FootballSim.Core.Services;
using System;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class NewGameForm : Form
    {
        public FranchiseState? CreatedFranchise { get; private set; }

        public NewGameForm()
        {
            InitializeComponent();

            var teams = DefaultTeamCatalog.GetTeams();

            cmbTeams.DataSource = teams;
            cmbTeams.DisplayMember = nameof(TeamDefinition.DisplayName);
            cmbTeams.ValueMember = nameof(TeamDefinition.TeamId);
            cmbTeams.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbTeams.SelectedValue is string teamId)
            {
                var factory = new FranchiseFactory();
                CreatedFranchise = factory.CreateNewFranchise(teamId);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please choose a team.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
