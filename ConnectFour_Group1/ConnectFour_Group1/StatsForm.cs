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
    public partial class StatsForm : Form
    {
        //DS- Statistic Form Workflow:
        //ListBox for SingleLine input of the ADS; {}
        //Button to reference previous gamestate (No reference of it is persistent, so may just be single previous) {}
        //Grey Button if no previous exist {}
        //Gather Pieces, and assemble object? Or make string...
        //Object is created, now to scaffold

        public StatsForm()
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
        //Scaffolding some utilities:
        private void readTextFile()
        {
            //This creates a StreamReader and grabs the GameHist.txt
            StreamReader file = new StreamReader("../../Resources/GameHist.txt");
            //End Start, Mental Note: De-Parse ADS to variables for easy display on List Box
            //REMEMBER LISTBOX SINGLE LINE APPEND
        }
        private bool isPlayerColor1(Board b)
        {
            //This function is to check previous board on what color the player was, currently set to return true until plumb
            return true;
        }
        private void fillListBox()
        {
            //This function takes our ADS data and puts it into the ListBox
        }
        private void rewriteFile()
        {
            //This can rewrite the GameHist.txt file should we elect to plumb, this is extra-scope
        }
    }
}
