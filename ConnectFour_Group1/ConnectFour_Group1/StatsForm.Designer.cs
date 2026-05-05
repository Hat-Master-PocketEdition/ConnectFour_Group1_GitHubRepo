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
            cpu_WH_LBL = new Label();
            p1_WH_LBL = new Label();
            p_TH_LBL = new Label();
            welcome_LBL = new Label();
            SuspendLayout();
            // 
            // Btn_BackToStart
            // 
            Btn_BackToStart.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_BackToStart.Location = new Point(12, 395);
            Btn_BackToStart.Name = "Btn_BackToStart";
            Btn_BackToStart.Size = new Size(115, 40);
            Btn_BackToStart.TabIndex = 0;
            Btn_BackToStart.Text = "Menu";
            Btn_BackToStart.UseVisualStyleBackColor = true;
            Btn_BackToStart.Click += Btn_BackToStart_Click;
            // 
            // gameCount_LBL
            // 
            gameCount_LBL.AutoSize = true;
            gameCount_LBL.Font = new Font("Segoe UI", 18F);
            gameCount_LBL.Location = new Point(555, 80);
            gameCount_LBL.Name = "gameCount_LBL";
            gameCount_LBL.Size = new Size(148, 32);
            gameCount_LBL.TabIndex = 2;
            gameCount_LBL.Text = "Game Count";
            // 
            // countInt_LBL
            // 
            countInt_LBL.AutoSize = true;
            countInt_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            countInt_LBL.Location = new Point(626, 132);
            countInt_LBL.Name = "countInt_LBL";
            countInt_LBL.Size = new Size(0, 21);
            countInt_LBL.TabIndex = 3;
            // 
            // p1_W_LBL
            // 
            p1_W_LBL.AutoSize = true;
            p1_W_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            p1_W_LBL.Location = new Point(192, 210);
            p1_W_LBL.Name = "p1_W_LBL";
            p1_W_LBL.Size = new Size(0, 21);
            p1_W_LBL.TabIndex = 5;
            // 
            // p1_stats_LBL
            // 
            p1_stats_LBL.AutoSize = true;
            p1_stats_LBL.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            p1_stats_LBL.Location = new Point(198, 134);
            p1_stats_LBL.Name = "p1_stats_LBL";
            p1_stats_LBL.Size = new Size(108, 32);
            p1_stats_LBL.TabIndex = 4;
            p1_stats_LBL.Text = "P1 Stats";
            // 
            // p1_T_LBL
            // 
            p1_T_LBL.AutoSize = true;
            p1_T_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            p1_T_LBL.Location = new Point(296, 211);
            p1_T_LBL.Name = "p1_T_LBL";
            p1_T_LBL.Size = new Size(0, 21);
            p1_T_LBL.TabIndex = 6;
            // 
            // cpu_W_LBL
            // 
            cpu_W_LBL.AutoSize = true;
            cpu_W_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            cpu_W_LBL.Location = new Point(236, 328);
            cpu_W_LBL.Name = "cpu_W_LBL";
            cpu_W_LBL.Size = new Size(0, 21);
            cpu_W_LBL.TabIndex = 8;
            // 
            // cpu_stats_LBL
            // 
            cpu_stats_LBL.AutoSize = true;
            cpu_stats_LBL.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cpu_stats_LBL.Location = new Point(177, 252);
            cpu_stats_LBL.Name = "cpu_stats_LBL";
            cpu_stats_LBL.Size = new Size(129, 32);
            cpu_stats_LBL.TabIndex = 7;
            cpu_stats_LBL.Text = "CPU Stats";
            // 
            // p1_WP_LBL
            // 
            p1_WP_LBL.AutoSize = true;
            p1_WP_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            p1_WP_LBL.Location = new Point(609, 251);
            p1_WP_LBL.Name = "p1_WP_LBL";
            p1_WP_LBL.Size = new Size(0, 21);
            p1_WP_LBL.TabIndex = 10;
            // 
            // p1_avg_LBL
            // 
            p1_avg_LBL.AutoSize = true;
            p1_avg_LBL.Font = new Font("Segoe UI", 18F);
            p1_avg_LBL.Location = new Point(533, 195);
            p1_avg_LBL.Name = "p1_avg_LBL";
            p1_avg_LBL.Size = new Size(206, 32);
            p1_avg_LBL.TabIndex = 9;
            p1_avg_LBL.Text = "Player 1 Victory %";
            // 
            // cpu_WP_LBL
            // 
            cpu_WP_LBL.AutoSize = true;
            cpu_WP_LBL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            cpu_WP_LBL.Location = new Point(609, 377);
            cpu_WP_LBL.Name = "cpu_WP_LBL";
            cpu_WP_LBL.Size = new Size(0, 21);
            cpu_WP_LBL.TabIndex = 12;
            // 
            // cpu_avg_LBL
            // 
            cpu_avg_LBL.AutoSize = true;
            cpu_avg_LBL.Font = new Font("Segoe UI", 18F);
            cpu_avg_LBL.Location = new Point(565, 319);
            cpu_avg_LBL.Name = "cpu_avg_LBL";
            cpu_avg_LBL.Size = new Size(166, 32);
            cpu_avg_LBL.TabIndex = 11;
            cpu_avg_LBL.Text = "CPU Victory %";
            // 
            // cpu_WH_LBL
            // 
            cpu_WH_LBL.AutoSize = true;
            cpu_WH_LBL.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            cpu_WH_LBL.Location = new Point(220, 301);
            cpu_WH_LBL.Name = "cpu_WH_LBL";
            cpu_WH_LBL.Size = new Size(50, 21);
            cpu_WH_LBL.TabIndex = 13;
            cpu_WH_LBL.Text = "Wins";
            // 
            // p1_WH_LBL
            // 
            p1_WH_LBL.AutoSize = true;
            p1_WH_LBL.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            p1_WH_LBL.Location = new Point(176, 187);
            p1_WH_LBL.Name = "p1_WH_LBL";
            p1_WH_LBL.Size = new Size(50, 21);
            p1_WH_LBL.TabIndex = 14;
            p1_WH_LBL.Text = "Wins";
            // 
            // p_TH_LBL
            // 
            p_TH_LBL.AutoSize = true;
            p_TH_LBL.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            p_TH_LBL.Location = new Point(284, 187);
            p_TH_LBL.Name = "p_TH_LBL";
            p_TH_LBL.Size = new Size(42, 21);
            p_TH_LBL.TabIndex = 15;
            p_TH_LBL.Text = "Ties";
            // 
            // welcome_LBL
            // 
            welcome_LBL.AutoSize = true;
            welcome_LBL.Font = new Font("Segoe UI Black", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcome_LBL.Location = new Point(14, 16);
            welcome_LBL.Name = "welcome_LBL";
            welcome_LBL.Size = new Size(540, 50);
            welcome_LBL.TabIndex = 16;
            welcome_LBL.Text = "Group1 Connect-4 Stat Sheet";
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 450);
            Controls.Add(welcome_LBL);
            Controls.Add(p_TH_LBL);
            Controls.Add(p1_WH_LBL);
            Controls.Add(cpu_WH_LBL);
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
        private Label cpu_WH_LBL;
        private Label p1_WH_LBL;
        private Label p_TH_LBL;
        private Label welcome_LBL;
    }
}