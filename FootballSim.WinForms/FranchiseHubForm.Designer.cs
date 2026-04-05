using System.Drawing;
using System.Windows.Forms;

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
            lblWeek = new Label();
            lblOffOvr = new Label();
            lblDefOvr = new Label();
            btnSimWeek = new Button();
            btnViewRoster = new Button();
            btnBackToMenu = new Button();
            txtResults = new TextBox();
            txtStandings = new TextBox();
            txtTeamStatus = new TextBox();
            lblResultsHeader = new Label();
            lblStandingsHeader = new Label();
            lblTeamStatusHeader = new Label();
            mainLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            actionLayout = new FlowLayoutPanel();
            contentLayout = new TableLayoutPanel();
            leftColumnLayout = new TableLayoutPanel();
            rightColumnLayout = new TableLayoutPanel();
            mainLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            actionLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            leftColumnLayout.SuspendLayout();
            rightColumnLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserTeam
            // 
            lblUserTeam.AutoSize = true;
            lblUserTeam.Dock = DockStyle.Fill;
            lblUserTeam.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserTeam.Location = new Point(3, 0);
            lblUserTeam.Name = "lblUserTeam";
            lblUserTeam.Size = new Size(514, 32);
            lblUserTeam.TabIndex = 0;
            lblUserTeam.Text = "User Team: (None)";
            lblUserTeam.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Dock = DockStyle.Fill;
            lblWeek.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeek.Location = new Point(3, 32);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(514, 28);
            lblWeek.TabIndex = 1;
            lblWeek.Text = "Week: 1";
            lblWeek.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOffOvr
            // 
            lblOffOvr.AutoSize = true;
            lblOffOvr.Dock = DockStyle.Fill;
            lblOffOvr.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOffOvr.Location = new Point(523, 0);
            lblOffOvr.Name = "lblOffOvr";
            lblOffOvr.Size = new Size(254, 32);
            lblOffOvr.TabIndex = 2;
            lblOffOvr.Text = "Off OVR: 0";
            lblOffOvr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDefOvr
            // 
            lblDefOvr.AutoSize = true;
            lblDefOvr.Dock = DockStyle.Fill;
            lblDefOvr.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDefOvr.Location = new Point(523, 32);
            lblDefOvr.Name = "lblDefOvr";
            lblDefOvr.Size = new Size(254, 28);
            lblDefOvr.TabIndex = 3;
            lblDefOvr.Text = "Def OVR: 0";
            lblDefOvr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSimWeek
            // 
            btnSimWeek.AutoSize = true;
            btnSimWeek.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSimWeek.Margin = new Padding(0, 0, 10, 0);
            btnSimWeek.Name = "btnSimWeek";
            btnSimWeek.Padding = new Padding(12, 6, 12, 6);
            btnSimWeek.Size = new Size(96, 37);
            btnSimWeek.TabIndex = 4;
            btnSimWeek.Text = "Sim Week";
            btnSimWeek.UseVisualStyleBackColor = true;
            btnSimWeek.Click += btnSimWeek_Click;
            // 
            // btnViewRoster
            // 
            btnViewRoster.AutoSize = true;
            btnViewRoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnViewRoster.Margin = new Padding(0, 0, 10, 0);
            btnViewRoster.Name = "btnViewRoster";
            btnViewRoster.Padding = new Padding(12, 6, 12, 6);
            btnViewRoster.Size = new Size(108, 37);
            btnViewRoster.TabIndex = 5;
            btnViewRoster.Text = "View Roster";
            btnViewRoster.UseVisualStyleBackColor = true;
            btnViewRoster.Click += btnViewRoster_Click;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.AutoSize = true;
            btnBackToMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackToMenu.Margin = new Padding(0);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Padding = new Padding(12, 6, 12, 6);
            btnBackToMenu.Size = new Size(122, 37);
            btnBackToMenu.TabIndex = 6;
            btnBackToMenu.Text = "Back to Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // txtResults
            // 
            txtResults.Dock = DockStyle.Fill;
            txtResults.Location = new Point(3, 31);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(460, 473);
            txtResults.TabIndex = 7;
            // 
            // txtStandings
            // 
            txtStandings.Dock = DockStyle.Fill;
            txtStandings.Location = new Point(3, 31);
            txtStandings.Multiline = true;
            txtStandings.Name = "txtStandings";
            txtStandings.ReadOnly = true;
            txtStandings.ScrollBars = ScrollBars.Vertical;
            txtStandings.Size = new Size(304, 211);
            txtStandings.TabIndex = 8;
            // 
            // txtTeamStatus
            // 
            txtTeamStatus.Dock = DockStyle.Fill;
            txtTeamStatus.Location = new Point(3, 276);
            txtTeamStatus.Multiline = true;
            txtTeamStatus.Name = "txtTeamStatus";
            txtTeamStatus.ReadOnly = true;
            txtTeamStatus.ScrollBars = ScrollBars.Vertical;
            txtTeamStatus.Size = new Size(304, 228);
            txtTeamStatus.TabIndex = 9;
            // 
            // lblResultsHeader
            // 
            lblResultsHeader.AutoSize = true;
            lblResultsHeader.Dock = DockStyle.Fill;
            lblResultsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblResultsHeader.Location = new Point(3, 0);
            lblResultsHeader.Name = "lblResultsHeader";
            lblResultsHeader.Size = new Size(460, 28);
            lblResultsHeader.TabIndex = 10;
            lblResultsHeader.Text = "Weekly Results";
            lblResultsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStandingsHeader
            // 
            lblStandingsHeader.AutoSize = true;
            lblStandingsHeader.Dock = DockStyle.Fill;
            lblStandingsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblStandingsHeader.Location = new Point(3, 0);
            lblStandingsHeader.Name = "lblStandingsHeader";
            lblStandingsHeader.Size = new Size(304, 28);
            lblStandingsHeader.TabIndex = 11;
            lblStandingsHeader.Text = "Standings";
            lblStandingsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTeamStatusHeader
            // 
            lblTeamStatusHeader.AutoSize = true;
            lblTeamStatusHeader.Dock = DockStyle.Fill;
            lblTeamStatusHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTeamStatusHeader.Location = new Point(3, 245);
            lblTeamStatusHeader.Name = "lblTeamStatusHeader";
            lblTeamStatusHeader.Size = new Size(304, 28);
            lblTeamStatusHeader.TabIndex = 12;
            lblTeamStatusHeader.Text = "Team Status";
            lblTeamStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(headerLayout, 0, 0);
            mainLayout.Controls.Add(actionLayout, 0, 1);
            mainLayout.Controls.Add(contentLayout, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(12, 12);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(786, 513);
            mainLayout.TabIndex = 13;
            // 
            // headerLayout
            // 
            headerLayout.ColumnCount = 2;
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.66667F));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            headerLayout.Controls.Add(lblUserTeam, 0, 0);
            headerLayout.Controls.Add(lblWeek, 0, 1);
            headerLayout.Controls.Add(lblOffOvr, 1, 0);
            headerLayout.Controls.Add(lblDefOvr, 1, 1);
            headerLayout.Dock = DockStyle.Fill;
            headerLayout.Location = new Point(3, 3);
            headerLayout.Name = "headerLayout";
            headerLayout.RowCount = 2;
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            headerLayout.Size = new Size(780, 54);
            headerLayout.TabIndex = 0;
            // 
            // actionLayout
            // 
            actionLayout.Controls.Add(btnSimWeek);
            actionLayout.Controls.Add(btnViewRoster);
            actionLayout.Controls.Add(btnBackToMenu);
            actionLayout.Dock = DockStyle.Fill;
            actionLayout.Location = new Point(3, 63);
            actionLayout.Name = "actionLayout";
            actionLayout.Size = new Size(780, 42);
            actionLayout.TabIndex = 1;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            contentLayout.Controls.Add(leftColumnLayout, 0, 0);
            contentLayout.Controls.Add(rightColumnLayout, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(3, 111);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(780, 399);
            contentLayout.TabIndex = 2;
            // 
            // leftColumnLayout
            // 
            leftColumnLayout.ColumnCount = 1;
            leftColumnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftColumnLayout.Controls.Add(lblResultsHeader, 0, 0);
            leftColumnLayout.Controls.Add(txtResults, 0, 1);
            leftColumnLayout.Dock = DockStyle.Fill;
            leftColumnLayout.Location = new Point(3, 3);
            leftColumnLayout.Name = "leftColumnLayout";
            leftColumnLayout.RowCount = 2;
            leftColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            leftColumnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftColumnLayout.Size = new Size(466, 393);
            leftColumnLayout.TabIndex = 0;
            // 
            // rightColumnLayout
            // 
            rightColumnLayout.ColumnCount = 1;
            rightColumnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightColumnLayout.Controls.Add(lblStandingsHeader, 0, 0);
            rightColumnLayout.Controls.Add(txtStandings, 0, 1);
            rightColumnLayout.Controls.Add(lblTeamStatusHeader, 0, 2);
            rightColumnLayout.Controls.Add(txtTeamStatus, 0, 3);
            rightColumnLayout.Dock = DockStyle.Fill;
            rightColumnLayout.Location = new Point(475, 3);
            rightColumnLayout.Name = "rightColumnLayout";
            rightColumnLayout.RowCount = 4;
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            rightColumnLayout.Size = new Size(302, 393);
            rightColumnLayout.TabIndex = 1;
            // 
            // FranchiseHubForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 537);
            Controls.Add(mainLayout);
            MinimumSize = new Size(760, 500);
            Name = "FranchiseHubForm";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Franchise Hub";
            mainLayout.ResumeLayout(false);
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            actionLayout.ResumeLayout(false);
            actionLayout.PerformLayout();
            contentLayout.ResumeLayout(false);
            leftColumnLayout.ResumeLayout(false);
            leftColumnLayout.PerformLayout();
            rightColumnLayout.ResumeLayout(false);
            rightColumnLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUserTeam;
        private Label lblWeek;
        private Label lblOffOvr;
        private Label lblDefOvr;
        private Button btnSimWeek;
        private Button btnViewRoster;
        private Button btnBackToMenu;
        private TextBox txtResults;
        private TextBox txtStandings;
        private TextBox txtTeamStatus;
        private Label lblResultsHeader;
        private Label lblStandingsHeader;
        private Label lblTeamStatusHeader;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel headerLayout;
        private FlowLayoutPanel actionLayout;
        private TableLayoutPanel contentLayout;
        private TableLayoutPanel leftColumnLayout;
        private TableLayoutPanel rightColumnLayout;
    }
}