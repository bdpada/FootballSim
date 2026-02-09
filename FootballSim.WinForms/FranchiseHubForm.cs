using FootballSim.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class FranchiseHubForm : Form
    {
        private readonly string _teamId;
        private readonly FranchiseState _franchise;
        private readonly Form _mainMenuForm;
        public FranchiseHubForm(FranchiseState franchise, Form mainMenuForm)
        {
            InitializeComponent();

            _franchise = franchise;
            _teamId = _franchise.UserTeamId;
            _mainMenuForm = mainMenuForm;
            lblUserTeam.Text = $"User Team: {_teamId}";
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            _mainMenuForm.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //This ennds the app because MainMenuFor is the Application.Run() form
            if (_mainMenuForm != null && !_mainMenuForm.IsDisposed && _mainMenuForm.Visible == false)
                _mainMenuForm.Close();
        }
    }
}
