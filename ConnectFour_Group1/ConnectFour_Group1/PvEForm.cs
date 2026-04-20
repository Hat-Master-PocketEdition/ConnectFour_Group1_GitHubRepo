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
    public partial class PvEForm : Form
    {
        //This is PvE Form, we will have our MinMax algo in here - DS
        private Board board = new Board();
        public PvEForm()
        {
            InitializeComponent();
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
        //MinMax Algo
        //Pass A Board Reference to AI (Make a Copy function to copy Board state for MinMax) - DS
        private int turnCounter()
        {
            //When called, counts the turns.
            int turnCounter = 0;
            return turnCounter++;
        }
        //Call Game.assembleEntry(Game game) to pass to Stat sheet
    }
}
