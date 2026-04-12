namespace FootballSim.WinForms
{
    partial class LoadGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private ListBox lstSaves;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnCancel;

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
            lblTitle = new Label();
            lstSaves = new ListBox();
            btnLoad = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select a Save to Load";
            // 
            // lstSaves
            // 
            lstSaves.FormattingEnabled = true;
            lstSaves.ItemHeight = 15;
            lstSaves.Location = new Point(12, 42);
            lstSaves.Name = "lstSaves";
            lstSaves.Size = new Size(460, 244);
            lstSaves.TabIndex = 1;
            lstSaves.DoubleClick += lstSaves_DoubleClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 305);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 30);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(118, 305);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(372, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // LoadGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 351);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(lstSaves);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoadGameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Load Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}