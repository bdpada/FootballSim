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
            SuspendLayout();
            // 
            // lblUserTeam
            // 
            lblUserTeam.AutoSize = true;
            lblUserTeam.Location = new Point(250, 26);
            lblUserTeam.Name = "lblUserTeam";
            lblUserTeam.Size = new Size(262, 41);
            lblUserTeam.TabIndex = 0;
            lblUserTeam.Text = "User Team: (None)";
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Location = new Point(12, 380);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(219, 58);
            btnBackToMenu.TabIndex = 1;
            btnBackToMenu.Text = "Back to Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // FranchiseHubForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}