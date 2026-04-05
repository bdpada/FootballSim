namespace FootballSim.WinForms
{
    partial class FranchiseHubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUserTeam = new Label();
            btnBackToMenu = new Button();
            lblWeek = new Label();
            btnSimWeek = new Button();
            txtResults = new TextBox();
            txtStandings = new TextBox();
            btnViewRoster = new Button();
            lblOffOvr = new Label();
            lblDefOvr = new Label();
            SuspendLayout();
            // 
            // lblUserTeam
            // 
            lblUserTeam.AutoSize = true;
            lblUserTeam.Location = new Point(13, 9);
            lblUserTeam.Margin = new Padding(1, 0, 1, 0);
            lblUserTeam.Name = "lblUserTeam";
            lblUserTeam.Size = new Size(105, 15);
            lblUserTeam.TabIndex = 0;
            lblUserTeam.Text = "User Team: (None)";
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Location = new Point(13, 187);
            btnBackToMenu.Margin = new Padding(1);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(90, 21);
            btnBackToMenu.TabIndex = 5;
            btnBackToMenu.Text = "Back to Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Location = new Point(13, 27);
            lblWeek.Margin = new Padding(1, 0, 1, 0);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(48, 15);
            lblWeek.TabIndex = 1;
            lblWeek.Text = "Week: 1";
            // 
            // btnSimWeek
            // 
            btnSimWeek.Location = new Point(13, 48);
            btnSimWeek.Margin = new Padding(1);
            btnSimWeek.Name = "btnSimWeek";
            btnSimWeek.Size = new Size(82, 21);
            btnSimWeek.TabIndex = 2;
            btnSimWeek.Text = "Sim Week";
            btnSimWeek.UseVisualStyleBackColor = true;
            btnSimWeek.Click += btnSimWeek_Click;
            // 
            // txtResults
            // 
            txtResults.Location = new Point(13, 77);
            txtResults.Margin = new Padding(1);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(258, 105);
            txtResults.TabIndex = 3;
            // 
            // txtStandings
            // 
            txtStandings.Location = new Point(276, 77);
            txtStandings.Margin = new Padding(1);
            txtStandings.Multiline = true;
            txtStandings.Name = "txtStandings";
            txtStandings.ReadOnly = true;
            txtStandings.ScrollBars = ScrollBars.Vertical;
            txtStandings.Size = new Size(126, 105);
            txtStandings.TabIndex = 4;
            // 
            // btnViewRoster
            // 
            btnViewRoster.Location = new Point(97, 48);
            btnViewRoster.Margin = new Padding(1);
            btnViewRoster.Name = "btnViewRoster";
            btnViewRoster.Size = new Size(82, 21);
            btnViewRoster.TabIndex = 6;
            btnViewRoster.Text = "View Roster";
            btnViewRoster.UseVisualStyleBackColor = true;
            btnViewRoster.Click += btnViewRoster_Click;
            // 
            // lblOffOvr
            // 
            lblOffOvr.AutoSize = true;
            lblOffOvr.Location = new Point(141, 9);
            lblOffOvr.Name = "lblOffOvr";
            lblOffOvr.Size = new Size(49, 15);
            lblOffOvr.TabIndex = 7;
            lblOffOvr.Text = "Off Ovr:";
            // 
            // lblDefOvr
            // 
            lblDefOvr.AutoSize = true;
            lblDefOvr.Location = new Point(221, 9);
            lblDefOvr.Name = "lblDefOvr";
            lblDefOvr.Size = new Size(50, 15);
            lblDefOvr.TabIndex = 8;
            lblDefOvr.Text = "Def Ovr:";
            // 
            // FranchiseHubForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 220);
            Controls.Add(lblDefOvr);
            Controls.Add(lblOffOvr);
            Controls.Add(btnViewRoster);
            Controls.Add(txtStandings);
            Controls.Add(txtResults);
            Controls.Add(btnSimWeek);
            Controls.Add(lblWeek);
            Controls.Add(btnBackToMenu);
            Controls.Add(lblUserTeam);
            Margin = new Padding(1);
            Name = "FranchiseHubForm";
            Text = "Franchise Hub";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserTeam;
        private Button btnBackToMenu;
        private Label lblWeek;
        private Button btnSimWeek;
        private TextBox txtResults;
        private TextBox txtStandings;
        private Button btnViewRoster;
        private Label lblOffOvr;
        private Label lblDefOvr;
    }
}