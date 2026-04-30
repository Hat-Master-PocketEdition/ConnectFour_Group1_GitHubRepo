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
            SuspendLayout();
            // 
            // BackToMenu
            // 
            BackToMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BackToMenu.Location = new Point(14, 553);
            BackToMenu.Margin = new Padding(3, 4, 3, 4);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(86, 31);
            BackToMenu.TabIndex = 0;
            BackToMenu.Text = "Menu";
            BackToMenu.UseVisualStyleBackColor = true;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // theLabel
            // 
            theLabel.AutoSize = true;
            theLabel.Location = new Point(376, 12);
            theLabel.Name = "theLabel";
            theLabel.Size = new Size(50, 20);
            theLabel.TabIndex = 1;
            theLabel.Text = "label1";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRestart.Location = new Point(816, 553);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(86, 31);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.Location = new Point(405, 553);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 31);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(914, 600);
            Controls.Add(btnExit);
            Controls.Add(btnRestart);
            Controls.Add(theLabel);
            Controls.Add(BackToMenu);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}