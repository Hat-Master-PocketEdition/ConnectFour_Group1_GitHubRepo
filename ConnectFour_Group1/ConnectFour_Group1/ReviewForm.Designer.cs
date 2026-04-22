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
            SuspendLayout();
            // 
            // BackToMenu
            // 
            BackToMenu.Location = new Point(12, 415);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(75, 23);
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
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(800, 450);
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
    }
}