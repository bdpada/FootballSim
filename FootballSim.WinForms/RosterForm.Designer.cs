namespace FootballSim.WinForms
{
    partial class RosterForm
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            lblTeamName = new Label();
            lblPosition = new Label();
            cmbPositions = new ComboBox();
            lstPlayers = new ListBox();
            btnMoveUp = new Button();
            btnMoveDown = new Button();
            btnAutoFixPosition = new Button();
            btnAutoFixAll = new Button();
            btnClose = new Button();
            lblRosterSize = new Label();
            btnCutPlayer = new Button();
            SuspendLayout();
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTeamName.Location = new Point(24, 20);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(185, 25);
            lblTeamName.TabIndex = 0;
            lblTeamName.Text = "Roster - TeamName";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(24, 64);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Position";
            // 
            // cmbPositions
            // 
            cmbPositions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPositions.FormattingEnabled = true;
            cmbPositions.Location = new Point(24, 82);
            cmbPositions.Name = "cmbPositions";
            cmbPositions.Size = new Size(180, 23);
            cmbPositions.TabIndex = 2;
            cmbPositions.SelectedIndexChanged += cmbPositions_SelectedIndexChanged;
            // 
            // lstPlayers
            // 
            lstPlayers.Font = new Font("Consolas", 10F);
            lstPlayers.FormattingEnabled = true;
            lstPlayers.Location = new Point(24, 122);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(520, 259);
            lstPlayers.TabIndex = 3;
            lstPlayers.DoubleClick += lstPlayers_DoubleClick;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(568, 122);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(120, 32);
            btnMoveUp.TabIndex = 4;
            btnMoveUp.Text = "Move Up";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(568, 160);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(120, 32);
            btnMoveDown.TabIndex = 5;
            btnMoveDown.Text = "Move Down";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnAutoFixPosition
            // 
            btnAutoFixPosition.Location = new Point(568, 257);
            btnAutoFixPosition.Name = "btnAutoFixPosition";
            btnAutoFixPosition.Size = new Size(120, 40);
            btnAutoFixPosition.TabIndex = 6;
            btnAutoFixPosition.Text = "Auto Fix Position";
            btnAutoFixPosition.UseVisualStyleBackColor = true;
            btnAutoFixPosition.Click += btnAutoFixPosition_Click;
            // 
            // btnAutoFixAll
            // 
            btnAutoFixAll.Location = new Point(568, 303);
            btnAutoFixAll.Name = "btnAutoFixAll";
            btnAutoFixAll.Size = new Size(120, 40);
            btnAutoFixAll.TabIndex = 7;
            btnAutoFixAll.Text = "Auto Fix All";
            btnAutoFixAll.UseVisualStyleBackColor = true;
            btnAutoFixAll.Click += btnAutoFixAll_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(568, 349);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 32);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblRosterSize
            // 
            lblRosterSize.AutoSize = true;
            lblRosterSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRosterSize.Location = new Point(215, 23);
            lblRosterSize.Name = "lblRosterSize";
            lblRosterSize.Size = new Size(200, 21);
            lblRosterSize.TabIndex = 9;
            lblRosterSize.Text = "Roster: {team.Roster.Count}";
            // 
            // btnCutPlayer
            // 
            btnCutPlayer.Location = new Point(568, 198);
            btnCutPlayer.Name = "btnCutPlayer";
            btnCutPlayer.Size = new Size(120, 35);
            btnCutPlayer.TabIndex = 8;
            btnCutPlayer.Text = "Cut Player";
            btnCutPlayer.UseVisualStyleBackColor = true;
            btnCutPlayer.Click += btnCutPlayer_Click;
            // 
            // RosterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 411);
            Controls.Add(btnCutPlayer);
            Controls.Add(lblRosterSize);
            Controls.Add(btnAutoFixAll);
            Controls.Add(btnAutoFixPosition);
            Controls.Add(btnClose);
            Controls.Add(btnMoveDown);
            Controls.Add(btnMoveUp);
            Controls.Add(lstPlayers);
            Controls.Add(cmbPositions);
            Controls.Add(lblPosition);
            Controls.Add(lblTeamName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RosterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Roster";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPositions;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnAutoFixPosition;
        private System.Windows.Forms.Button btnAutoFixAll;
        private System.Windows.Forms.Button btnCutPlayer;
        private System.Windows.Forms.Button btnClose;
        private Label lblRosterSize;
    }
}