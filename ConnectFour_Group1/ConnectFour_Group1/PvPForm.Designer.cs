namespace ConnectFour_Group1
{
    partial class PvPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvPForm));
            restartButton = new Button();
            Btn_BacktoStart = new Button();
            SuspendLayout();
            // 
            // restartButton
            // 
            restartButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restartButton.Location = new Point(667, 391);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(115, 40);
            restartButton.TabIndex = 4;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // Btn_BacktoStart
            // 
            Btn_BacktoStart.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_BacktoStart.Location = new Point(12, 391);
            Btn_BacktoStart.Name = "Btn_BacktoStart";
            Btn_BacktoStart.Size = new Size(115, 40);
            Btn_BacktoStart.TabIndex = 3;
            Btn_BacktoStart.Text = "Back";
            Btn_BacktoStart.UseVisualStyleBackColor = true;
            Btn_BacktoStart.Click += Btn_BackToStart_Click;
            // 
            // PvPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(800, 450);
            Controls.Add(restartButton);
            Controls.Add(Btn_BacktoStart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PvPForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connect Four - Player vs. Player";
            FormClosed += AppClose;
            ResumeLayout(false);
        }

        #endregion
        private Button restartButton;
        private Button Btn_BacktoStart;
    }
}