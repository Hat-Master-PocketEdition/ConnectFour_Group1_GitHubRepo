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
        Board GameBoard = new Board();

        //these could be hard coded to just red and yellow without using variables 
        //but i thought it might be cool to come back and allow players to pick
        //their own colors later on. Plus it doesn't hurt to have them here if
        //we never get/got to it.
        Image PlayerOneColor = Image.FromFile(@"../../Resources/RedChip.png");
        Image PlayerTwoColor = Image.FromFile(@"../../Resources/YellowChip.png");
        //CB -DS ----------
        //Two Colors is solid, then we just make randomized color + turn assignment;
        //I will define Color1 as Red; Color2 is Yellow for ADS + variable reference.
        //END CB-----------

        int[,] CodeBoard = new int[7, 6];
        public PvPForm()
        {
            InitializeComponent();
            Board GameBoard = new Board(this, Image.FromFile(@"../../Resources/BlackChip.png"), 2, restartButton);

            //InitializeBoard(GameBoard);
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
        private int turnCounter()
        {
            //When called, counts the turns.
            int turnCounter = 0;
            return turnCounter++;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            PvEForm load = new PvEForm();
            load.Show();
            this.Hide();
        }
    }
}
