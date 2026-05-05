namespace ConnectFour_Group1
{
    partial class PvEForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvEForm));
            Btn_BackToStart = new Button();
            restartButton = new Button();
            SuspendLayout();
            // 
            // Btn_BackToStart
            // 
            Btn_BackToStart.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_BackToStart.Location = new Point(12, 391);
            Btn_BackToStart.Name = "Btn_BackToStart";
            Btn_BackToStart.Size = new Size(115, 40);
            Btn_BackToStart.TabIndex = 0;
            Btn_BackToStart.Text = "Back";
            Btn_BackToStart.UseVisualStyleBackColor = true;
            Btn_BackToStart.Click += Btn_BackToStart_Click;
            // 
            // restartButton
            // 
            restartButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restartButton.Location = new Point(667, 391);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(115, 40);
            restartButton.TabIndex = 2;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // PvEForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(800, 450);
            Controls.Add(restartButton);
            Controls.Add(Btn_BackToStart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PvEForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connect Four - Player vs. Computer";
            FormClosed += AppClose;
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_BackToStart;
        private Button restartButton;
    }
}