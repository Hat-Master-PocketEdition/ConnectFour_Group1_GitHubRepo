using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        //Gather Games on a List, and reference per object in succession
        private List<Game> listofGames = new List<Game>();
        int counter = 0;
        public StatsForm()
        {
            InitializeComponent();
            readTextFile();
            //Fills Game Count Integer Lbl;
            fillLBLs(countInt_LBL);
            //Fills Player1 Wins, Ties, and CPU Wins;
            fillLBLs(p1_W_LBL);
            fillLBLs(p1_T_LBL);
            fillLBLs(cpu_W_LBL);
            //Fills Player1 and CPU Win Percentages;
            fillLBLs(p1_WP_LBL);
            fillLBLs(cpu_WP_LBL);
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
            string filePath = "../../Resources/GameHist.txt";
            StreamReader file = new StreamReader(filePath);
            //End Start, Mental Note: De-Parse ADS to variables for easy display on List Box
            //REMEMBER LISTBOX SINGLE LINE APPEND
            String line = file.ReadLine();
            int counter = 0;
            int id;
            int w;
            char gT;
            int mC;
            String cS;
            int delimPOS;
            char delim = ',';
            Game newGame;
            if (File.Exists(filePath))
            {
                Debug.WriteLine("File Found");
                while (line != null)
                {
                    if (line.Trim() != "")
                    {
                        //Locate DelimPOS
                        delimPOS = line.IndexOf(delim);
                        //Read up to, but not the comma
                        id = Int32.Parse(line.Substring(0, delimPOS));
                        //Change line to Post comma
                        line = line.Substring(delimPOS + 1);
                        //Repeat for ADS
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
                        cS = line;
                        //Compiles all our data to the list
                        newGame = new Game(id, w, gT, mC, cS);
                        //Add to List, and continue until readline is clear
                        listofGames.Add(newGame);
                    }
                    line = file.ReadLine();
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
        private bool isPlayerColor1(Board b)
        {
            //This function is to check previous board on what color the player was, currently set to return true until plumb
            if (b.getPlayerColor() == "Red")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void fillLBLs(Label l)
        {
            
            //This function adds to LBLs upon what 'l' is;
            //GameCount (linecount for how many games), averages for Player1, and CPU;
            //P1 Based: Victories, Ties; CPU Based: Victories;
            if (l == countInt_LBL)
            {
                countInt_LBL.Text = listofGames.Count.ToString();
            }
            if (l == p1_W_LBL)
            {
                p1_W_LBL.Text = "0";
                for (int i = 0; i < listofGames.Count; i++)
                {
                    if (listofGames[i].getWin() == 0)
                    {
                        p1_W_LBL.Text = (Int32.Parse(p1_W_LBL.Text) + 1).ToString();
                    }
                }
            }
            if (l == p1_T_LBL)
            {
                p1_T_LBL.Text = "0";
                for (int i = 0; i < listofGames.Count; i++)
                {
                    if (listofGames[i].getWin() == 3)
                    {
                        p1_T_LBL.Text = (Int32.Parse(p1_T_LBL.Text) + 1).ToString();
                    }
                }
            }
            if (l == cpu_W_LBL)
            {
                cpu_W_LBL.Text = "0";
                for (int i = 0; i < listofGames.Count; i++)
                {
                    if (listofGames[i].getGameType() == 'C' && listofGames[i].getWin() == 1)
                    {
                        counter++;
                        Debug.WriteLine(counter);

                        //cpu_W_LBL.Text = (Int32.Parse(cpu_W_LBL.Text) + 1).ToString();

                    }
                }
                cpu_W_LBL.Text = counter.ToString();
            }
            if(l == p1_WP_LBL)
            {
                p1_WP_LBL.Text = "0%";
                int p1W = 0;
                int p1T = 0;
                int p1L = 0;
                for (int i = 0; i < listofGames.Count; i++)
                {
                    if (listofGames[i].getWin() == 0)
                    {
                        p1W++;
                    }
                    else if (listofGames[i].getWin() == 3)
                    {
                        p1T++;
                    }
                    else
                    {
                        p1L++;
                    }
                }
                if (p1W + p1T + p1L > 0)
                {
                    double winPercent = (double)p1W / (p1W + p1T + p1L) * 100;
                    p1_WP_LBL.Text = winPercent.ToString("F2") + "%";
                }
            }
            if(l == cpu_WP_LBL)
            {
                cpu_WP_LBL.Text = "99%";
                float gamesPlayed = listofGames[listofGames.Count - 1].getID();
                float percentWon = (counter / gamesPlayed) * 100;
                cpu_WP_LBL.Text = percentWon.ToString("F2") + "%";
                Debug.WriteLine("counter: " + counter + ", gamesPlayed: " + gamesPlayed + ", percentWon: " + percentWon);
                //cpu_WP_LBL.Text = "0%";
                //int cpuW = 0;
                //int cpuT = 0;
                //int cpuL = 0;
                //for (int i = 0; i < listofGames.Count; i++)
                //{
                //    if (listofGames[i].getGameType() == 'C')
                //    {
                //        if (listofGames[i].getWin() == 2)
                //        {
                //            cpuW++;
                //        }
                //        else if (listofGames[i].getWin() == 3)
                //        {
                //            cpuT++;
                //        }
                //        else
                //        {
                //            cpuL++;
                //        }
                //    }
                //}
                //if (cpuW + cpuT + cpuL > 0)
                //{
                //    double winPercent = (double)cpuW / (cpuW + cpuT + cpuL) * 100;
                //    cpu_WP_LBL.Text = winPercent.ToString("F2") + "%";
                //}
                //else
                //{
                //    cpu_WP_LBL.Text = "0%";
                //}
            }
        }
    }
}
