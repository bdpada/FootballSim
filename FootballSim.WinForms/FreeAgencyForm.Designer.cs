namespace FootballSim.WinForms
{
    partial class FreeAgencyForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private ComboBox cmbPositionFilter;
        private Label lblFilter;
        private ListBox lstFreeAgents;
        private Button btnSign;
        private Button btnClose;
        private Label lblSelectedPlayer;
        private Label lblFreeAgentCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            cmbPositionFilter = new ComboBox();
            lblFilter = new Label();
            lstFreeAgents = new ListBox();
            btnSign = new Button();
            btnClose = new Button();
            lblSelectedPlayer = new Label();
            lblFreeAgentCount = new Label();
            lblRosterCount = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(121, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Free Agency";
            // 
            // cmbPositionFilter
            // 
            cmbPositionFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPositionFilter.FormattingEnabled = true;
            cmbPositionFilter.Location = new Point(24, 83);
            cmbPositionFilter.Name = "cmbPositionFilter";
            cmbPositionFilter.Size = new Size(180, 23);
            cmbPositionFilter.TabIndex = 2;
            cmbPositionFilter.SelectedIndexChanged += cmbPositionFilter_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(24, 65);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(79, 15);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Filter Position";
            // 
            // lstFreeAgents
            // 
            lstFreeAgents.FormattingEnabled = true;
            lstFreeAgents.Location = new Point(24, 122);
            lstFreeAgents.Name = "lstFreeAgents";
            lstFreeAgents.Size = new Size(540, 274);
            lstFreeAgents.TabIndex = 4;
            lstFreeAgents.SelectedIndexChanged += lstFreeAgents_SelectedIndexChanged;
            // 
            // btnSign
            // 
            btnSign.Location = new Point(389, 448);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(84, 32);
            btnSign.TabIndex = 6;
            btnSign.Text = "Sign";
            btnSign.UseVisualStyleBackColor = true;
            btnSign.Click += btnSign_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(480, 448);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(84, 32);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblSelectedPlayer
            // 
            lblSelectedPlayer.AutoSize = true;
            lblSelectedPlayer.Location = new Point(24, 413);
            lblSelectedPlayer.Name = "lblSelectedPlayer";
            lblSelectedPlayer.Size = new Size(86, 15);
            lblSelectedPlayer.TabIndex = 5;
            lblSelectedPlayer.Text = "Selected: None";
            // 
            // lblFreeAgentCount
            // 
            lblFreeAgentCount.AutoSize = true;
            lblFreeAgentCount.Location = new Point(230, 87);
            lblFreeAgentCount.Name = "lblFreeAgentCount";
            lblFreeAgentCount.Size = new Size(81, 15);
            lblFreeAgentCount.TabIndex = 3;
            lblFreeAgentCount.Text = "Free Agents: 0";
            // 
            // lblRosterCount
            // 
            lblRosterCount = new Label();
            lblRosterCount.AutoSize = true;
            lblRosterCount.Location = new Point(360, 87);
            lblRosterCount.Name = "lblRosterCount";
            lblRosterCount.Size = new Size(74, 15);
            lblRosterCount.TabIndex = 8;
            lblRosterCount.Text = "Roster: ?/?";
            // 
            // FreeAgencyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 502);
            Controls.Add(lblRosterCount);
            Controls.Add(btnClose);
            Controls.Add(btnSign);
            Controls.Add(lblSelectedPlayer);
            Controls.Add(lstFreeAgents);
            Controls.Add(lblFreeAgentCount);
            Controls.Add(cmbPositionFilter);
            Controls.Add(lblFilter);
            Controls.Add(lblTitle);
            Controls.Add(lblRosterCount);
            Name = "FreeAgencyForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Free Agency";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblRosterCount;
    }
}