using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectFour_Group1.Properties;

namespace ConnectFour_Group1
{
    public partial class PvPForm : Form
    {

        PictureBox[,] GameBoard = new PictureBox[7, 6];
        public PvPForm()
        {
            InitializeComponent();
            DrawBoard(GameBoard);
        }

        private void AppClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Btn_BackToStart_Click(object sender, EventArgs e)
        {
            StartForm load = new StartForm();
            load.Show();
            this.Hide();
        }

        private void DrawBoard(PictureBox[,] board)
        {

            for(int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    board[x, y] = new PictureBox();

                    Debug.WriteLine("COORDS: " + x + ", " + y);
                    board[x, y].Image = Image.FromFile(@"../../Resources/YellowChip.png");
                    board[x, y].Size = new Size(80, 80);
                    board[x, y].Location = new Point(x * 85, y * 85);
                    board[x, y].BorderStyle = BorderStyle.FixedSingle;

                    this.Controls.Add(board[x, y]);
                }
            }
        }
    }
}
