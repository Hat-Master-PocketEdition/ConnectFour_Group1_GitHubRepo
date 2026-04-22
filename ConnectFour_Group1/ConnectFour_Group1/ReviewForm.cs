using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group1
{
    public partial class ReviewForm : Form
    {
        public ReviewForm()
        {
            InitializeComponent();
        }
        public ReviewForm(int playerWon, int winningMoveX, int winningMoveY, int formType)
        {

            InitializeComponent();
            theLabel.Font = new Font("Comic Sans MS", 15, FontStyle.Regular);
            if (playerWon == 1)
            {
                theLabel.Text = "Red Wins!";
                theLabel.ForeColor = Color.FromArgb(186, 0, 0);
                this.Icon = new System.Drawing.Icon(@"../../Resources/RedIcon.ico");
            }
            else if (playerWon == 2)
            {
                theLabel.Text = "Yellow Wins!";
                theLabel.ForeColor = Color.FromArgb(199, 199, 0);
                this.Icon = new System.Drawing.Icon(@"../../Resources/YellowIcon.ico");
            }
            this.Controls.Add(theLabel);

        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            StartForm load = new StartForm();
            load.Show();
            this.Hide();
        }

        private void AppExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
