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
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbPositions = new System.Windows.Forms.ComboBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTeamName.Location = new System.Drawing.Point(24, 20);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(172, 25);
            this.lblTeamName.TabIndex = 0;
            this.lblTeamName.Text = "Roster - TeamName";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(24, 64);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(50, 15);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position";
            // 
            // cmbPositions
            // 
            this.cmbPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositions.FormattingEnabled = true;
            this.cmbPositions.Location = new System.Drawing.Point(24, 82);
            this.cmbPositions.Name = "cmbPositions";
            this.cmbPositions.Size = new System.Drawing.Size(180, 23);
            this.cmbPositions.TabIndex = 2;
            this.cmbPositions.SelectedIndexChanged += new System.EventHandler(this.cmbPositions_SelectedIndexChanged);
            // 
            // lstPlayers
            // 
            this.lstPlayers.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.ItemHeight = 15;
            this.lstPlayers.Location = new System.Drawing.Point(24, 122);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(520, 259);
            this.lstPlayers.TabIndex = 3;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(568, 122);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(120, 32);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(568, 166);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(120, 32);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(568, 349);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 411);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.cmbPositions);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblTeamName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RosterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Roster";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPositions;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnClose;
    }
}