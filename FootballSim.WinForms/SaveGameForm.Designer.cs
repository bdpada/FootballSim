namespace FootballSim.WinForms
{
    partial class SaveGameForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private ListBox lstSaves;
        private Label lblSaveName;
        private TextBox txtSaveName;
        private Button btnSave;
        private Button btnCancel;

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
            lstSaves = new ListBox();
            lblSaveName = new Label();
            txtSaveName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Save Franchise Game";
            // 
            // lstSaves
            // 
            lstSaves.FormattingEnabled = true;
            lstSaves.ItemHeight = 15;
            lstSaves.Location = new Point(12, 42);
            lstSaves.Name = "lstSaves";
            lstSaves.Size = new Size(520, 184);
            lstSaves.TabIndex = 1;
            lstSaves.SelectedIndexChanged += lstSaves_SelectedIndexChanged;
            // 
            // lblSaveName
            // 
            lblSaveName.AutoSize = true;
            lblSaveName.Location = new Point(12, 241);
            lblSaveName.Name = "lblSaveName";
            lblSaveName.Size = new Size(92, 15);
            lblSaveName.TabIndex = 2;
            lblSaveName.Text = "Save file name:";
            // 
            // txtSaveName
            // 
            txtSaveName.Location = new Point(12, 259);
            txtSaveName.Name = "txtSaveName";
            txtSaveName.Size = new Size(520, 23);
            txtSaveName.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(432, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SaveGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 342);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSaveName);
            Controls.Add(lblSaveName);
            Controls.Add(lstSaves);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaveGameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save Game";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}