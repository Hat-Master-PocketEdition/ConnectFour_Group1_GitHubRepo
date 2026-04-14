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
            Btn_BackToStart = new Button();
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
            // PvPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Btn_BackToStart);
            Name = "PvPForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connect Four - Player vs. Player";
            FormClosed += AppClose;
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_BackToStart;
    }
}