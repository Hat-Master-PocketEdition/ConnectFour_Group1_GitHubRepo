namespace ConnectFour_Group1
{
    partial class StartForm
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
            label1 = new Label();
            btn_GoToPvE = new Button();
            btn_GoToPvP = new Button();
            btn_GoToStats = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(389, 163);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // btn_GoToPvE
            // 
            btn_GoToPvE.Location = new Point(292, 415);
            btn_GoToPvE.Name = "btn_GoToPvE";
            btn_GoToPvE.Size = new Size(75, 23);
            btn_GoToPvE.TabIndex = 1;
            btn_GoToPvE.Text = "1 Player";
            btn_GoToPvE.UseVisualStyleBackColor = true;
            btn_GoToPvE.Click += Btn_Clicked;
            // 
            // btn_GoToPvP
            // 
            btn_GoToPvP.Location = new Point(373, 415);
            btn_GoToPvP.Name = "btn_GoToPvP";
            btn_GoToPvP.Size = new Size(75, 23);
            btn_GoToPvP.TabIndex = 2;
            btn_GoToPvP.Text = "2 Player";
            btn_GoToPvP.UseVisualStyleBackColor = true;
            btn_GoToPvP.Click += Btn_Clicked;
            // 
            // btn_GoToStats
            // 
            btn_GoToStats.Location = new Point(454, 415);
            btn_GoToStats.Name = "btn_GoToStats";
            btn_GoToStats.Size = new Size(75, 23);
            btn_GoToStats.TabIndex = 3;
            btn_GoToStats.Text = "Stats";
            btn_GoToStats.UseVisualStyleBackColor = true;
            btn_GoToStats.Click += Btn_Clicked;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 178);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_GoToStats);
            Controls.Add(btn_GoToPvP);
            Controls.Add(btn_GoToPvE);
            Controls.Add(label1);
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connect Four";
            FormClosed += AppClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_GoToPvE;
        private Button btn_GoToPvP;
        private Button btn_GoToStats;
    }
}
