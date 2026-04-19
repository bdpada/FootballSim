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
            lblGameplanHeader = new Label();
            lblTeamStatusHeader = new Label();
            lblOffenseFocus = new Label();
            cmbOffenseFocus = new ComboBox();
            lblDefenseFocus = new Label();
            cmbDefenseFocus = new ComboBox();
            pnlGameplan = new TableLayoutPanel();
            mainLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            actionLayout = new FlowLayoutPanel();
            btnSave = new Button();
            contentLayout = new TableLayoutPanel();
            leftColumnLayout = new TableLayoutPanel();
            rightColumnLayout = new TableLayoutPanel();
            btnFreeAgency = new Button();
            pnlGameplan.SuspendLayout();
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
            lblUserTeam.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserTeam.Location = new Point(3, 0);
            lblUserTeam.Name = "lblUserTeam";
            lblUserTeam.Size = new Size(514, 29);
            lblUserTeam.TabIndex = 0;
            lblUserTeam.Text = "User Team: (None)";
            lblUserTeam.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Dock = DockStyle.Fill;
            lblWeek.Font = new Font("Segoe UI", 10F);
            lblWeek.Location = new Point(3, 29);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(514, 25);
            lblWeek.TabIndex = 1;
            lblWeek.Text = "Week: 1";
            lblWeek.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOffOvr
            // 
            lblOffOvr.AutoSize = true;
            lblOffOvr.Dock = DockStyle.Fill;
            lblOffOvr.Font = new Font("Segoe UI", 10F);
            lblOffOvr.Location = new Point(523, 0);
            lblOffOvr.Name = "lblOffOvr";
            lblOffOvr.Size = new Size(254, 29);
            lblOffOvr.TabIndex = 2;
            lblOffOvr.Text = "Off OVR: 0";
            lblOffOvr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDefOvr
            // 
            lblDefOvr.AutoSize = true;
            lblDefOvr.Dock = DockStyle.Fill;
            lblDefOvr.Font = new Font("Segoe UI", 10F);
            lblDefOvr.Location = new Point(523, 29);
            lblDefOvr.Name = "lblDefOvr";
            lblDefOvr.Size = new Size(254, 25);
            lblDefOvr.TabIndex = 3;
            lblDefOvr.Text = "Def OVR: 0";
            lblDefOvr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSimWeek
            // 
            btnSimWeek.AutoSize = true;
            btnSimWeek.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSimWeek.Location = new Point(0, 0);
            btnSimWeek.Margin = new Padding(0, 0, 10, 0);
            btnSimWeek.Name = "btnSimWeek";
            btnSimWeek.Padding = new Padding(12, 6, 12, 6);
            btnSimWeek.Size = new Size(93, 37);
            btnSimWeek.TabIndex = 4;
            btnSimWeek.Text = "Sim Week";
            btnSimWeek.UseVisualStyleBackColor = true;
            btnSimWeek.Click += btnSimWeek_Click;
            // 
            // btnViewRoster
            // 
            btnViewRoster.AutoSize = true;
            btnViewRoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnViewRoster.Location = new Point(103, 0);
            btnViewRoster.Margin = new Padding(0, 0, 10, 0);
            btnViewRoster.Name = "btnViewRoster";
            btnViewRoster.Padding = new Padding(12, 6, 12, 6);
            btnViewRoster.Size = new Size(102, 37);
            btnViewRoster.TabIndex = 5;
            btnViewRoster.Text = "View Roster";
            btnViewRoster.UseVisualStyleBackColor = true;
            btnViewRoster.Click += btnViewRoster_Click;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.AutoSize = true;
            btnBackToMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackToMenu.Location = new Point(331, 0);
            btnBackToMenu.Margin = new Padding(0, 0, 10, 0);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Padding = new Padding(12, 6, 12, 6);
            btnBackToMenu.Size = new Size(114, 37);
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
            txtResults.Size = new Size(456, 359);
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
            txtStandings.Size = new Size(300, 87);
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
            txtTeamStatus.Size = new Size(300, 114);
            txtTeamStatus.TabIndex = 9;
            // 
            // lblResultsHeader
            // 
            lblResultsHeader.AutoSize = true;
            lblResultsHeader.Dock = DockStyle.Fill;
            lblResultsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultsHeader.Location = new Point(3, 0);
            lblResultsHeader.Name = "lblResultsHeader";
            lblResultsHeader.Size = new Size(456, 28);
            lblResultsHeader.TabIndex = 10;
            lblResultsHeader.Text = "Weekly Results";
            lblResultsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStandingsHeader
            // 
            lblStandingsHeader.AutoSize = true;
            lblStandingsHeader.Dock = DockStyle.Fill;
            lblStandingsHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStandingsHeader.Location = new Point(3, 0);
            lblStandingsHeader.Name = "lblStandingsHeader";
            lblStandingsHeader.Size = new Size(300, 28);
            lblStandingsHeader.TabIndex = 11;
            lblStandingsHeader.Text = "Standings";
            lblStandingsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGameplanHeader
            // 
            lblGameplanHeader.AutoSize = true;
            lblGameplanHeader.Dock = DockStyle.Fill;
            lblGameplanHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGameplanHeader.Location = new Point(3, 121);
            lblGameplanHeader.Name = "lblGameplanHeader";
            lblGameplanHeader.Size = new Size(300, 28);
            lblGameplanHeader.TabIndex = 12;
            lblGameplanHeader.Text = "Weekly Gameplan";
            lblGameplanHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTeamStatusHeader
            // 
            lblTeamStatusHeader.AutoSize = true;
            lblTeamStatusHeader.Dock = DockStyle.Fill;
            lblTeamStatusHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTeamStatusHeader.Location = new Point(3, 245);
            lblTeamStatusHeader.Name = "lblTeamStatusHeader";
            lblTeamStatusHeader.Size = new Size(300, 28);
            lblTeamStatusHeader.TabIndex = 13;
            lblTeamStatusHeader.Text = "Team Status";
            lblTeamStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOffenseFocus
            // 
            lblOffenseFocus.AutoSize = true;
            lblOffenseFocus.Dock = DockStyle.Fill;
            lblOffenseFocus.Location = new Point(3, 0);
            lblOffenseFocus.Name = "lblOffenseFocus";
            lblOffenseFocus.Size = new Size(100, 45);
            lblOffenseFocus.TabIndex = 0;
            lblOffenseFocus.Text = "Offense Focus";
            lblOffenseFocus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbOffenseFocus
            // 
            cmbOffenseFocus.Dock = DockStyle.Fill;
            cmbOffenseFocus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOffenseFocus.FormattingEnabled = true;
            cmbOffenseFocus.Location = new Point(109, 11);
            cmbOffenseFocus.Margin = new Padding(3, 11, 3, 11);
            cmbOffenseFocus.Name = "cmbOffenseFocus";
            cmbOffenseFocus.Size = new Size(188, 23);
            cmbOffenseFocus.TabIndex = 1;
            cmbOffenseFocus.SelectedIndexChanged += cmbOffenseFocus_SelectedIndexChanged;
            // 
            // lblDefenseFocus
            // 
            lblDefenseFocus.AutoSize = true;
            lblDefenseFocus.Dock = DockStyle.Fill;
            lblDefenseFocus.Location = new Point(3, 45);
            lblDefenseFocus.Name = "lblDefenseFocus";
            lblDefenseFocus.Size = new Size(100, 45);
            lblDefenseFocus.TabIndex = 2;
            lblDefenseFocus.Text = "Defense Focus";
            lblDefenseFocus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbDefenseFocus
            // 
            cmbDefenseFocus.Dock = DockStyle.Fill;
            cmbDefenseFocus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDefenseFocus.FormattingEnabled = true;
            cmbDefenseFocus.Location = new Point(109, 56);
            cmbDefenseFocus.Margin = new Padding(3, 11, 3, 11);
            cmbDefenseFocus.Name = "cmbDefenseFocus";
            cmbDefenseFocus.Size = new Size(188, 23);
            cmbDefenseFocus.TabIndex = 3;
            cmbDefenseFocus.SelectedIndexChanged += cmbDefenseFocus_SelectedIndexChanged;
            // 
            // pnlGameplan
            // 
            pnlGameplan.ColumnCount = 2;
            pnlGameplan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.52632F));
            pnlGameplan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.47369F));
            pnlGameplan.Controls.Add(lblOffenseFocus, 0, 0);
            pnlGameplan.Controls.Add(cmbOffenseFocus, 1, 0);
            pnlGameplan.Controls.Add(lblDefenseFocus, 0, 1);
            pnlGameplan.Controls.Add(cmbDefenseFocus, 1, 1);
            pnlGameplan.Dock = DockStyle.Fill;
            pnlGameplan.Location = new Point(3, 152);
            pnlGameplan.Name = "pnlGameplan";
            pnlGameplan.RowCount = 2;
            pnlGameplan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlGameplan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlGameplan.Size = new Size(300, 90);
            pnlGameplan.TabIndex = 14;
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
            mainLayout.TabIndex = 15;
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
            actionLayout.Controls.Add(btnFreeAgency);
            actionLayout.Controls.Add(btnBackToMenu);
            actionLayout.Controls.Add(btnSave);
            actionLayout.Dock = DockStyle.Fill;
            actionLayout.Location = new Point(3, 63);
            actionLayout.Name = "actionLayout";
            actionLayout.Size = new Size(780, 42);
            actionLayout.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Location = new Point(455, 0);
            btnSave.Margin = new Padding(0, 0, 10, 0);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(12, 6, 12, 6);
            btnSave.Size = new Size(99, 37);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save Game";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
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
            leftColumnLayout.Size = new Size(462, 393);
            leftColumnLayout.TabIndex = 0;
            // 
            // rightColumnLayout
            // 
            rightColumnLayout.ColumnCount = 1;
            rightColumnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightColumnLayout.Controls.Add(lblStandingsHeader, 0, 0);
            rightColumnLayout.Controls.Add(txtStandings, 0, 1);
            rightColumnLayout.Controls.Add(lblGameplanHeader, 0, 2);
            rightColumnLayout.Controls.Add(pnlGameplan, 0, 3);
            rightColumnLayout.Controls.Add(lblTeamStatusHeader, 0, 4);
            rightColumnLayout.Controls.Add(txtTeamStatus, 0, 5);
            rightColumnLayout.Dock = DockStyle.Fill;
            rightColumnLayout.Location = new Point(471, 3);
            rightColumnLayout.Name = "rightColumnLayout";
            rightColumnLayout.RowCount = 6;
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 44F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rightColumnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 56F));
            rightColumnLayout.Size = new Size(306, 393);
            rightColumnLayout.TabIndex = 1;
            // 
            // btnFreeAgency
            // 
            btnFreeAgency.AutoSize = true;
            btnFreeAgency.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFreeAgency.Location = new Point(215, 0);
            btnFreeAgency.Margin = new Padding(0, 0, 10, 0);
            btnFreeAgency.Name = "btnFreeAgency";
            btnFreeAgency.Padding = new Padding(12, 6, 12, 6);
            btnFreeAgency.Size = new Size(106, 37);
            btnFreeAgency.TabIndex = 8;
            btnFreeAgency.Text = "Free Agency";
            btnFreeAgency.UseVisualStyleBackColor = true;
            btnFreeAgency.Click += btnFreeAgency_Click;
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
            pnlGameplan.ResumeLayout(false);
            pnlGameplan.PerformLayout();
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
        private Label lblGameplanHeader;
        private Label lblTeamStatusHeader;
        private Label lblOffenseFocus;
        private ComboBox cmbOffenseFocus;
        private Label lblDefenseFocus;
        private ComboBox cmbDefenseFocus;
        private TableLayoutPanel pnlGameplan;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel headerLayout;
        private FlowLayoutPanel actionLayout;
        private TableLayoutPanel contentLayout;
        private TableLayoutPanel leftColumnLayout;
        private TableLayoutPanel rightColumnLayout;
        private Button btnSave;
        private Button btnFreeAgency;
    }
}