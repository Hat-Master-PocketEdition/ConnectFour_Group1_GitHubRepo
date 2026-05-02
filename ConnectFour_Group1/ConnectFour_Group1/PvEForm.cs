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
            Board GameBoard = new Board(this, Image.FromFile(@"../../Resources/BlackChip.png"), 1, restartButton);
            Game PvE = new Game();
            //Runs ID Check to set new Game ID, if no games, ID -> 1;
            PvE.setID(PvE.getIDcheck());
            PvE.setGameType('C');
            //If player is first, then we run setColorSchema to set 0 for C1; -> 1 for C2;
            PvE.setColorSchema("0");
            //PvE.setColorSchema("1");
            //Pipe in the remainder game pieces, these just need uncommented
            //PvE.setMoveCount();
            //PvE.setWin();
            //string endGame = PvE.assembleEntry(PvE);
            //PvE.writeToFile(endGame);
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
        private int turnCounter(int turnCount)
        {
            //When called, counts the turns.
            return turnCount++;
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            PvEForm load = new PvEForm();
            load.Show();
            this.Hide();
        }
        //Call Game.assembleEntry(Game game) to pass to Stat sheet
    }
}
