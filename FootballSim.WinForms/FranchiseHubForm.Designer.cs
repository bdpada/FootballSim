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
            SuspendLayout();
            // 
            // lblUserTeam
            // 
            lblUserTeam.AutoSize = true;
            lblUserTeam.Location = new Point(32, 24);
            lblUserTeam.Name = "lblUserTeam";
            lblUserTeam.Size = new Size(262, 41);
            lblUserTeam.TabIndex = 0;
            lblUserTeam.Text = "User Team: (None)";
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Location = new Point(32, 75);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(114, 41);
            lblWeek.TabIndex = 1;
            lblWeek.Text = "Week: 1";
            // 
            // btnSimWeek
            // 
            btnSimWeek.Location = new Point(32, 130);
            btnSimWeek.Name = "btnSimWeek";
            btnSimWeek.Size = new Size(200, 58);
            btnSimWeek.TabIndex = 2;
            btnSimWeek.Text = "Sim Week";
            btnSimWeek.UseVisualStyleBackColor = true;
            btnSimWeek.Click += btnSimWeek_Click;
            // 
            // txtResults
            // 
            txtResults.Location = new Point(32, 210);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(620, 280);
            txtResults.TabIndex = 3;
            // 
            // txtStandings
            // 
            txtStandings.Location = new Point(670, 210);
            txtStandings.Multiline = true;
            txtStandings.Name = "txtStandings";
            txtStandings.ReadOnly = true;
            txtStandings.ScrollBars = ScrollBars.Vertical;
            txtStandings.Size = new Size(300, 280);
            txtStandings.TabIndex = 4;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Location = new Point(32, 510);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(219, 58);
            btnBackToMenu.TabIndex = 5;
            btnBackToMenu.Text = "Back to Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // FranchiseHubForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(txtStandings);
            Controls.Add(txtResults);
            Controls.Add(btnSimWeek);
            Controls.Add(lblWeek);
            Controls.Add(btnBackToMenu);
            Controls.Add(lblUserTeam);
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
    }
}