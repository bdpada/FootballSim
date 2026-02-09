namespace FootballSim.WinForms
{
    partial class NewGameForm
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
            lblChooseTeam = new Label();
            cmbTeams = new ComboBox();
            btnStart = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblChooseTeam
            // 
            lblChooseTeam.AutoSize = true;
            lblChooseTeam.Location = new Point(226, 32);
            lblChooseTeam.Name = "lblChooseTeam";
            lblChooseTeam.Size = new Size(271, 41);
            lblChooseTeam.TabIndex = 0;
            lblChooseTeam.Text = "Choose Your Team:";
            // 
            // cmbTeams
            // 
            cmbTeams.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeams.FormattingEnabled = true;
            cmbTeams.Location = new Point(216, 105);
            cmbTeams.Name = "cmbTeams";
            cmbTeams.Size = new Size(302, 49);
            cmbTeams.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(534, 319);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(188, 58);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(58, 319);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(188, 58);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // NewGameForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnStart);
            Controls.Add(cmbTeams);
            Controls.Add(lblChooseTeam);
            Name = "NewGameForm";
            Text = "New Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChooseTeam;
        private ComboBox cmbTeams;
        private Button btnStart;
        private Button btnCancel;
    }
}