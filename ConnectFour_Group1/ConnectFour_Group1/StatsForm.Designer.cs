namespace ConnectFour_Group1
{
    partial class StatsForm
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
            Btn_BackToStart = new Button();
            gameCount_LBL = new Label();
            countInt_LBL = new Label();
            p1_W_LBL = new Label();
            p1_stats_LBL = new Label();
            p1_T_LBL = new Label();
            cpu_W_LBL = new Label();
            cpu_stats_LBL = new Label();
            p1_WP_LBL = new Label();
            p1_avg_LBL = new Label();
            cpu_WP_LBL = new Label();
            cpu_avg_LBL = new Label();
            SuspendLayout();
            // 
            // Btn_BackToStart
            // 
            Btn_BackToStart.Location = new Point(12, 415);
            Btn_BackToStart.Name = "Btn_BackToStart";
            Btn_BackToStart.Size = new Size(75, 23);
            Btn_BackToStart.TabIndex = 0;
            Btn_BackToStart.Text = "Back";
            Btn_BackToStart.UseVisualStyleBackColor = true;
            Btn_BackToStart.Click += Btn_BackToStart_Click;
            // 
            // gameCount_LBL
            // 
            gameCount_LBL.AutoSize = true;
            gameCount_LBL.Location = new Point(610, 33);
            gameCount_LBL.Name = "gameCount_LBL";
            gameCount_LBL.Size = new Size(74, 15);
            gameCount_LBL.TabIndex = 2;
            gameCount_LBL.Text = "Game Count";
            // 
            // countInt_LBL
            // 
            countInt_LBL.AutoSize = true;
            countInt_LBL.Location = new Point(602, 59);
            countInt_LBL.Name = "countInt_LBL";
            countInt_LBL.Size = new Size(94, 15);
            countInt_LBL.TabIndex = 3;
            countInt_LBL.Text = "<countInt here>";
            // 
            // p1_W_LBL
            // 
            p1_W_LBL.AutoSize = true;
            p1_W_LBL.Location = new Point(69, 99);
            p1_W_LBL.Name = "p1_W_LBL";
            p1_W_LBL.Size = new Size(84, 15);
            p1_W_LBL.TabIndex = 5;
            p1_W_LBL.Text = "<p1 win here>";
            // 
            // p1_stats_LBL
            // 
            p1_stats_LBL.AutoSize = true;
            p1_stats_LBL.Location = new Point(141, 73);
            p1_stats_LBL.Name = "p1_stats_LBL";
            p1_stats_LBL.Size = new Size(48, 15);
            p1_stats_LBL.TabIndex = 4;
            p1_stats_LBL.Text = "P1 Stats";
            // 
            // p1_T_LBL
            // 
            p1_T_LBL.AutoSize = true;
            p1_T_LBL.Location = new Point(181, 99);
            p1_T_LBL.Name = "p1_T_LBL";
            p1_T_LBL.Size = new Size(83, 15);
            p1_T_LBL.TabIndex = 6;
            p1_T_LBL.Text = "<p1 ties here>";
            // 
            // cpu_W_LBL
            // 
            cpu_W_LBL.AutoSize = true;
            cpu_W_LBL.Location = new Point(117, 237);
            cpu_W_LBL.Name = "cpu_W_LBL";
            cpu_W_LBL.Size = new Size(91, 15);
            cpu_W_LBL.TabIndex = 8;
            cpu_W_LBL.Text = "<cpu win here>";
            // 
            // cpu_stats_LBL
            // 
            cpu_stats_LBL.AutoSize = true;
            cpu_stats_LBL.Location = new Point(131, 210);
            cpu_stats_LBL.Name = "cpu_stats_LBL";
            cpu_stats_LBL.Size = new Size(58, 15);
            cpu_stats_LBL.TabIndex = 7;
            cpu_stats_LBL.Text = "CPU Stats";
            // 
            // p1_WP_LBL
            // 
            p1_WP_LBL.AutoSize = true;
            p1_WP_LBL.Location = new Point(616, 161);
            p1_WP_LBL.Name = "p1_WP_LBL";
            p1_WP_LBL.Size = new Size(71, 15);
            p1_WP_LBL.TabIndex = 10;
            p1_WP_LBL.Text = "<p1 win %>";
            // 
            // p1_avg_LBL
            // 
            p1_avg_LBL.AutoSize = true;
            p1_avg_LBL.Location = new Point(604, 134);
            p1_avg_LBL.Name = "p1_avg_LBL";
            p1_avg_LBL.Size = new Size(101, 15);
            p1_avg_LBL.TabIndex = 9;
            p1_avg_LBL.Text = "Player 1 Victory %";
            // 
            // cpu_WP_LBL
            // 
            cpu_WP_LBL.AutoSize = true;
            cpu_WP_LBL.Location = new Point(614, 255);
            cpu_WP_LBL.Name = "cpu_WP_LBL";
            cpu_WP_LBL.Size = new Size(78, 15);
            cpu_WP_LBL.TabIndex = 12;
            cpu_WP_LBL.Text = "<cpu win %>";
            // 
            // cpu_avg_LBL
            // 
            cpu_avg_LBL.AutoSize = true;
            cpu_avg_LBL.Location = new Point(609, 228);
            cpu_avg_LBL.Name = "cpu_avg_LBL";
            cpu_avg_LBL.Size = new Size(83, 15);
            cpu_avg_LBL.TabIndex = 11;
            cpu_avg_LBL.Text = "CPU Victory %";
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cpu_WP_LBL);
            Controls.Add(cpu_avg_LBL);
            Controls.Add(p1_WP_LBL);
            Controls.Add(p1_avg_LBL);
            Controls.Add(cpu_W_LBL);
            Controls.Add(cpu_stats_LBL);
            Controls.Add(p1_T_LBL);
            Controls.Add(p1_W_LBL);
            Controls.Add(p1_stats_LBL);
            Controls.Add(countInt_LBL);
            Controls.Add(gameCount_LBL);
            Controls.Add(Btn_BackToStart);
            Name = "StatsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stats";
            FormClosed += AppClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_BackToStart;
        private Label gameCount_LBL;
        private Label countInt_LBL;
        private Label p1_W_LBL;
        private Label p1_stats_LBL;
        private Label p1_T_LBL;
        private Label cpu_W_LBL;
        private Label cpu_stats_LBL;
        private Label p1_WP_LBL;
        private Label p1_avg_LBL;
        private Label cpu_WP_LBL;
        private Label cpu_avg_LBL;
    }
}