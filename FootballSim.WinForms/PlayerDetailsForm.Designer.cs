namespace FootballSim.WinForms
{
    partial class PlayerDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblName;
        private Label lblPosition;
        private Label lblOverall;
        private Label lblAge;
        private Label lblYearsPro;
        private Label lblInjury;

        private GroupBox grpPhysicalMental;
        private Label lblSpeed;
        private Label lblStrength;
        private Label lblAwareness;
        private Label lblStamina;
        private Label lblDurability;

        private GroupBox grpOffense;
        private Label lblThrowAccuracy;
        private Label lblThrowPower;
        private Label lblCatching;
        private Label lblRouteRunning;
        private Label lblBlocking;

        private GroupBox grpDefenseSpecial;
        private Label lblTackling;
        private Label lblCoverage;
        private Label lblKicking;

        private Button btnClose;

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
            lblName = new Label();
            lblPosition = new Label();
            lblOverall = new Label();
            lblAge = new Label();
            lblYearsPro = new Label();
            lblInjury = new Label();

            grpPhysicalMental = new GroupBox();
            lblSpeed = new Label();
            lblStrength = new Label();
            lblAwareness = new Label();
            lblStamina = new Label();
            lblDurability = new Label();

            grpOffense = new GroupBox();
            lblThrowAccuracy = new Label();
            lblThrowPower = new Label();
            lblCatching = new Label();
            lblRouteRunning = new Label();
            lblBlocking = new Label();

            grpDefenseSpecial = new GroupBox();
            lblTackling = new Label();
            lblCoverage = new Label();
            lblKicking = new Label();

            btnClose = new Button();

            grpPhysicalMental.SuspendLayout();
            grpOffense.SuspendLayout();
            grpDefenseSpecial.SuspendLayout();
            SuspendLayout();

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(136, 30);
            lblName.TabIndex = 0;
            lblName.Text = "Player Name";

            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(20, 65);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(80, 15);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Position: N/A";

            // 
            // lblOverall
            // 
            lblOverall.AutoSize = true;
            lblOverall.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblOverall.Location = new Point(160, 65);
            lblOverall.Name = "lblOverall";
            lblOverall.Size = new Size(57, 15);
            lblOverall.TabIndex = 2;
            lblOverall.Text = "OVR: 000";

            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(20, 90);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(49, 15);
            lblAge.TabIndex = 3;
            lblAge.Text = "Age: N/A";

            // 
            // lblYearsPro
            // 
            lblYearsPro.AutoSize = true;
            lblYearsPro.Location = new Point(160, 90);
            lblYearsPro.Name = "lblYearsPro";
            lblYearsPro.Size = new Size(86, 15);
            lblYearsPro.TabIndex = 4;
            lblYearsPro.Text = "Years Pro: N/A";

            // 
            // lblInjury
            // 
            lblInjury.AutoSize = true;
            lblInjury.Location = new Point(20, 115);
            lblInjury.Name = "lblInjury";
            lblInjury.Size = new Size(88, 15);
            lblInjury.TabIndex = 5;
            lblInjury.Text = "Status: Healthy";

            // 
            // grpPhysicalMental
            // 
            grpPhysicalMental.Controls.Add(lblSpeed);
            grpPhysicalMental.Controls.Add(lblStrength);
            grpPhysicalMental.Controls.Add(lblAwareness);
            grpPhysicalMental.Controls.Add(lblStamina);
            grpPhysicalMental.Controls.Add(lblDurability);
            grpPhysicalMental.Location = new Point(20, 150);
            grpPhysicalMental.Name = "grpPhysicalMental";
            grpPhysicalMental.Size = new Size(210, 165);
            grpPhysicalMental.TabIndex = 6;
            grpPhysicalMental.TabStop = false;
            grpPhysicalMental.Text = "Physical / Mental";

            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new Point(15, 30);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(63, 15);
            lblSpeed.TabIndex = 0;
            lblSpeed.Text = "Speed: 000";

            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Location = new Point(15, 55);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(75, 15);
            lblStrength.TabIndex = 1;
            lblStrength.Text = "Strength: 000";

            // 
            // lblAwareness
            // 
            lblAwareness.AutoSize = true;
            lblAwareness.Location = new Point(15, 80);
            lblAwareness.Name = "lblAwareness";
            lblAwareness.Size = new Size(88, 15);
            lblAwareness.TabIndex = 2;
            lblAwareness.Text = "Awareness: 000";

            // 
            // lblStamina
            // 
            lblStamina.AutoSize = true;
            lblStamina.Location = new Point(15, 105);
            lblStamina.Name = "lblStamina";
            lblStamina.Size = new Size(75, 15);
            lblStamina.TabIndex = 3;
            lblStamina.Text = "Stamina: 000";

            // 
            // lblDurability
            // 
            lblDurability.AutoSize = true;
            lblDurability.Location = new Point(15, 130);
            lblDurability.Name = "lblDurability";
            lblDurability.Size = new Size(81, 15);
            lblDurability.TabIndex = 4;
            lblDurability.Text = "Durability: 000";

            // 
            // grpOffense
            // 
            grpOffense.Controls.Add(lblThrowAccuracy);
            grpOffense.Controls.Add(lblThrowPower);
            grpOffense.Controls.Add(lblCatching);
            grpOffense.Controls.Add(lblRouteRunning);
            grpOffense.Controls.Add(lblBlocking);
            grpOffense.Location = new Point(250, 150);
            grpOffense.Name = "grpOffense";
            grpOffense.Size = new Size(220, 165);
            grpOffense.TabIndex = 7;
            grpOffense.TabStop = false;
            grpOffense.Text = "Offensive Skills";

            // 
            // lblThrowAccuracy
            // 
            lblThrowAccuracy.AutoSize = true;
            lblThrowAccuracy.Location = new Point(15, 30);
            lblThrowAccuracy.Name = "lblThrowAccuracy";
            lblThrowAccuracy.Size = new Size(119, 15);
            lblThrowAccuracy.TabIndex = 0;
            lblThrowAccuracy.Text = "Throw Accuracy: 000";

            // 
            // lblThrowPower
            // 
            lblThrowPower.AutoSize = true;
            lblThrowPower.Location = new Point(15, 55);
            lblThrowPower.Name = "lblThrowPower";
            lblThrowPower.Size = new Size(105, 15);
            lblThrowPower.TabIndex = 1;
            lblThrowPower.Text = "Throw Power: 000";

            // 
            // lblCatching
            // 
            lblCatching.AutoSize = true;
            lblCatching.Location = new Point(15, 80);
            lblCatching.Name = "lblCatching";
            lblCatching.Size = new Size(78, 15);
            lblCatching.TabIndex = 2;
            lblCatching.Text = "Catching: 000";

            // 
            // lblRouteRunning
            // 
            lblRouteRunning.AutoSize = true;
            lblRouteRunning.Location = new Point(15, 105);
            lblRouteRunning.Name = "lblRouteRunning";
            lblRouteRunning.Size = new Size(108, 15);
            lblRouteRunning.TabIndex = 3;
            lblRouteRunning.Text = "Route Running: 000";

            // 
            // lblBlocking
            // 
            lblBlocking.AutoSize = true;
            lblBlocking.Location = new Point(15, 130);
            lblBlocking.Name = "lblBlocking";
            lblBlocking.Size = new Size(76, 15);
            lblBlocking.TabIndex = 4;
            lblBlocking.Text = "Blocking: 000";

            // 
            // grpDefenseSpecial
            // 
            grpDefenseSpecial.Controls.Add(lblTackling);
            grpDefenseSpecial.Controls.Add(lblCoverage);
            grpDefenseSpecial.Controls.Add(lblKicking);
            grpDefenseSpecial.Location = new Point(20, 330);
            grpDefenseSpecial.Name = "grpDefenseSpecial";
            grpDefenseSpecial.Size = new Size(210, 105);
            grpDefenseSpecial.TabIndex = 8;
            grpDefenseSpecial.TabStop = false;
            grpDefenseSpecial.Text = "Defense / Special Teams";

            // 
            // lblTackling
            // 
            lblTackling.AutoSize = true;
            lblTackling.Location = new Point(15, 28);
            lblTackling.Name = "lblTackling";
            lblTackling.Size = new Size(74, 15);
            lblTackling.TabIndex = 0;
            lblTackling.Text = "Tackling: 000";

            // 
            // lblCoverage
            // 
            lblCoverage.AutoSize = true;
            lblCoverage.Location = new Point(15, 53);
            lblCoverage.Name = "lblCoverage";
            lblCoverage.Size = new Size(78, 15);
            lblCoverage.TabIndex = 1;
            lblCoverage.Text = "Coverage: 000";

            // 
            // lblKicking
            // 
            lblKicking.AutoSize = true;
            lblKicking.Location = new Point(15, 78);
            lblKicking.Name = "lblKicking";
            lblKicking.Size = new Size(69, 15);
            lblKicking.TabIndex = 2;
            lblKicking.Text = "Kicking: 000";

            // 
            // btnClose
            // 
            btnClose.Location = new Point(375, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(95, 30);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;

            // 
            // PlayerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 461);
            Controls.Add(btnClose);
            Controls.Add(grpDefenseSpecial);
            Controls.Add(grpOffense);
            Controls.Add(grpPhysicalMental);
            Controls.Add(lblInjury);
            Controls.Add(lblYearsPro);
            Controls.Add(lblAge);
            Controls.Add(lblOverall);
            Controls.Add(lblPosition);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlayerDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Player Details";
            grpPhysicalMental.ResumeLayout(false);
            grpPhysicalMental.PerformLayout();
            grpOffense.ResumeLayout(false);
            grpOffense.PerformLayout();
            grpDefenseSpecial.ResumeLayout(false);
            grpDefenseSpecial.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}