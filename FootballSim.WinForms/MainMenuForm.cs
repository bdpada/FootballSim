using FootballSim.WinForms.State;

namespace FootballSim.WinForms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            using var newGameForm = new NewGameForm();
            var result = newGameForm.ShowDialog();

            if (result == DialogResult.OK && newGameForm.CreatedFranchise != null)
            {
                MessageBox.Show($"Selected Team: {newGameForm.CreatedFranchise.UserTeam?.Name}");
                FranchiseContext.Set(newGameForm.CreatedFranchise);

                var hub = new FranchiseHubForm();
                hub.Show();
                this.Hide();
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load Game not implemented yet.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
