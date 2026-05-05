namespace ConnectFour_Group1
{
    partial class ReviewForm
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
            BackToMenu = new Button();
            theLabel = new Label();
            btnRestart = new Button();
            btnExit = new Button();
            btnStats = new Button();
            SuspendLayout();
            // 
            // BackToMenu
            // 
            BackToMenu.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            BackToMenu.Location = new Point(282, 402);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(115, 40);
            BackToMenu.TabIndex = 0;
            BackToMenu.Text = "Menu";
            BackToMenu.UseVisualStyleBackColor = true;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // theLabel
            // 
            theLabel.AutoSize = true;
            theLabel.Location = new Point(329, 9);
            theLabel.Name = "theLabel";
            theLabel.Size = new Size(38, 15);
            theLabel.TabIndex = 1;
            theLabel.Text = "label1";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            btnRestart.Location = new Point(155, 402);
            btnRestart.Margin = new Padding(3, 2, 3, 2);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(115, 40);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            btnExit.Location = new Point(541, 402);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(115, 40);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnStats
            // 
            btnStats.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            btnStats.Location = new Point(410, 402);
            btnStats.Margin = new Padding(3, 2, 3, 2);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(115, 40);
            btnStats.TabIndex = 4;
            btnStats.Text = "Stats";
            btnStats.UseVisualStyleBackColor = true;
            btnStats.Click += btnStats_Click;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(800, 450);
            Controls.Add(btnStats);
            Controls.Add(btnExit);
            Controls.Add(btnRestart);
            Controls.Add(theLabel);
            Controls.Add(BackToMenu);
            Name = "ReviewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReviewForm";
            FormClosed += AppExit;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackToMenu;
        private Label theLabel;
        private Button btnRestart;
        private Button btnExit;
        private Button btnStats;
    }
}