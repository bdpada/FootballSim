using System;
using System.Windows.Forms;
using FootballSim.Core.Models;

namespace FootballSim.WinForms
{
    public partial class PlayerDetailsForm : Form
    {
        private readonly Player _player;

        public PlayerDetailsForm(Player player)
        {
            InitializeComponent();
            _player = player ?? throw new ArgumentNullException(nameof(player));

            LoadPlayer();
        }

        private void LoadPlayer()
        {
            Text = $"{_player.FullName} Details";

            lblName.Text = _player.FullName;
            lblPosition.Text = $"Position: {_player.Position}";
            lblOverall.Text = $"OVR: {_player.Overall}";
            lblAge.Text = $"Age: {_player.Age}";
            lblYearsPro.Text = $"Years Pro: {_player.YearsPro}";
            lblInjury.Text = _player.IsInjured
                ? $"Status: OUT {_player.InjuryWeeksRemaining} week(s)"
                : "Status: Healthy";

            lblSpeed.Text = $"Speed: {_player.Speed}";
            lblStrength.Text = $"Strength: {_player.Strength}";
            lblAwareness.Text = $"Awareness: {_player.Awareness}";
            lblStamina.Text = $"Stamina: {_player.Stamina}";
            lblDurability.Text = $"Durability: {_player.Durability}";

            lblThrowAccuracy.Text = $"Throw Accuracy: {_player.ThrowAccuracy}";
            lblThrowPower.Text = $"Throw Power: {_player.ThrowPower}";
            lblCatching.Text = $"Catching: {_player.Catching}";
            lblRouteRunning.Text = $"Route Running: {_player.RouteRunning}";
            lblBlocking.Text = $"Blocking: {_player.Blocking}";

            lblTackling.Text = $"Tackling: {_player.Tackling}";
            lblCoverage.Text = $"Coverage: {_player.Coverage}";
            lblKicking.Text = $"Kicking: {_player.Kicking}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}