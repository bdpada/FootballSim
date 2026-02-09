namespace FootballSim.WinForms
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNewGame = new Button();
            btnLoadGame = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(300, 72);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(188, 58);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.Location = new Point(300, 181);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(188, 58);
            btnLoadGame.TabIndex = 1;
            btnLoadGame.Text = "Load Game";
            btnLoadGame.UseVisualStyleBackColor = true;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(300, 283);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(188, 58);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnLoadGame);
            Controls.Add(btnNewGame);
            Name = "MainMenuForm";
            Text = "Main Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewGame;
        private Button btnLoadGame;
        private Button btnExit;
    }
}
