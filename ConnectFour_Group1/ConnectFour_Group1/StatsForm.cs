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
        //Gather Games on a List, and reference per object in succession
        //Object is created, now to scaffold
        private List<Game> listofGames = new List<Game>();
        public StatsForm()
        {
            InitializeComponent();
            readTextFile();
            fillListBox();
        }
        //We need to think on how to bring previous board to view - DS
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
            String line = file.ReadLine();
            String m;
            String d;
            String y;
            int w;
            char gT;
            int mC;
            String cS;
            int delimPOS;
            char delim = ',';
            Game newGame;
            while(line != null)
            {
                //Locate DelimPOS
                delimPOS = line.IndexOf(delim);
                //Read up to, but not the comma
                m = line.Substring(0, delimPOS);
                //Change line to Post comma
                line = line.Substring(delimPOS + 1);
                //Repeat for ADS
                delimPOS = line.IndexOf(delim);
                d = line.Substring(0, delimPOS);
                line = line.Substring (delimPOS + 1);
                delimPOS = line.IndexOf(delim);
                y = line.Substring(0, delimPOS);
                line = line.Substring(delimPOS + 1);
                delimPOS = line.IndexOf(delim);
                w = Int32.Parse(line.Substring(0, delimPOS));
                line = line.Substring(delimPOS + 1);
                delimPOS = line.IndexOf(delim);
                gT = Convert.ToChar(line.Substring(0, delimPOS));
                line = line.Substring(delimPOS + 1);
                delimPOS = line.IndexOf(delim);
                mC = Int32.Parse(line.Substring(0, delimPOS));
                line = line.Substring(delimPOS + 1);
                delimPOS = line.IndexOf(delim);
                cS = line.Substring(0, delimPOS);
                line = line.Substring(delimPOS + 1);
                //Compiles all our data to the list
                newGame = new Game(m, d, y, w, gT, mC, cS);
                //Add to List, and continue until readline is clear
                listofGames.Add(newGame);
                line = file.ReadLine();
            }
            file.Close();
        }
        private bool isPlayerColor1(Board b)
        {
            //This function is to check previous board on what color the player was, currently set to return true until plumb
            return true;
        }
        private void fillListBox()
        {
            //This function takes our ADS data and puts it into the ListBox
            //First step clear the ListBox
            for(int i = 0; i < listofGames.Count; i++)
            {
                //This is the Single Line Output onto the ListBox
            }    
        }
    }
}
