using FootballSim.Core.Models;
using FootballSim.WinForms.State;
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
        //private readonly string _teamId;
        //private readonly FranchiseState _franchise;
        //private readonly Form _mainMenuForm;
        private bool _isNavigatingToMainMenu = false;
        public FranchiseHubForm()
        {
            InitializeComponent();
            RefreshView();

            //_franchise = franchise;
            //_teamId = _franchise.UserTeamId;
            //_mainMenuForm = mainMenuForm;
            //lblUserTeam.Text = $"User Team: {_teamId}";
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isNavigatingToMainMenu)
            {
                // Just close this form, the main menu will still be open
                return;
            }

            //This ends the app because MainMenuFor is the Application.Run() form
            Application.Exit();
        }
    }
}
