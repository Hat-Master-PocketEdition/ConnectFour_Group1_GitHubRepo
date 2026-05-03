using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group1
{
    public partial class PvEForm : Form
    {
        //This is PvE Form, we will have our MinMax algo in here - DS
        private Board GameBoard;
        private Game PvE;
        private bool resultSaved = false;
        public PvEForm()
        {
            InitializeComponent();
            GameBoard = new Board(this, Image.FromFile(@"../../Resources/BlackChip.png"), 1, restartButton);
            PvE = new Game();
            PvE.setGameType('C');
            //If player is first, then we run setColorSchema to set 0 for C1; -> 1 for C2;
            PvE.setColorSchema("0");
            //PvE.setColorSchema("1");
            //Create the save method and 
            
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
        //Make the GameResults
        public void saveGameResult()
        {
            //Check form bool, and board GameState And write to Game file
            if (resultSaved)
            {
                return;
            }
            if (GameBoard.getGameState() == "PlayerWin")
            {
                PvE.setWin(0);
            }
            else if (GameBoard.getGameState() == "AIWin")
            {
                PvE.setWin(1);
            }
            else if(GameBoard.getGameState() == "Tie")
            {
                PvE.setWin(2);
            }
            else
            {
                //else game keeps running
                return;
            }
            PvE.setMoveCount(GameBoard.getMoveCount());
            string endGame = PvE.assembleEntry(PvE);
            PvE.writeToFile(endGame);
            resultSaved = true;

            Debug.WriteLine("Saving Game: " + endGame);
        }
    }
}
