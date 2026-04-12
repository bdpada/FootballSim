using FootballSim.Persistence.Services;
using FootballSim.WinForms.State;

namespace FootballSim.WinForms
{
    public partial class MainMenuForm : Form
    {
        private readonly ISaveService _saveService = new JsonSaveService();

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
            using var loadGameForm = new LoadGameForm();
            var result = loadGameForm.ShowDialog();

            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(loadGameForm.SelectedSaveName))
                return;

            try
            {
                var franchise = _saveService.Load(loadGameForm.SelectedSaveName);

                FranchiseContext.Set(franchise);

                var hub = new FranchiseHubForm();
                hub.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load save:\n{ex.Message}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
