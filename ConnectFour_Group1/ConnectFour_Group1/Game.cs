using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group1
{
    public class Game
    {
        //Make a List to parse the GameHist.txt into, and reference for StatsForm display;
        //Also for returning ints for other Form Parsing
        List<Game> gameHistory = new List<Game>();
        //Created by DS; 4/15/26
        //Instill Private Variables of the Object for definition of Game Object
        //ID,W,G,M,C
        //ID Schema: 0 - Debug Game, does not save. Index Start at 1 - N;
        private int id;
        //W; 0 - P1; 1 - AI; 2 - Tie; 
        private int win;
        //G; P - PvP; C - PvAI;
        private char gameType;
        //M: #
        private int moveCount;
        //C: String of Color arrangement, great for previous board (recollect where was what)
        //C: 0 - Color 1 Red; 1 - Color 2 Yellow
        //This allows the reference of who was what "player 1 was Red, and Player2/AI was Yellow N games ago"
        //Thus it is a string to if-chain discern a bool of "Player1 color is?" thus easily discerning for QoL
        private string colorSchema;

        //Constructor and Overloaded Constructor
        public Game()
        {
            int id;
            int win;
            char gameType;
            int movecount;
            string colorSchema;
        }
        //Overloaded Constructor
        public Game(int i,int w, char g, int mC, string c)
        {
            id = i;
            win = w;
            gameType = g;
            moveCount = mC;
            colorSchema = c;
        }
        //==========S e t t e r s==================================
        public void setID(int i)
        {
            id = i;
        }
        public void setWin(int w)
        {
            win = w;
        }
        public void setGameType(char g)
        {
            gameType = g;
        }
        public void setMoveCount(int m)
        {
            moveCount = m;
        }
        public void setColorSchema(string c)
        {
            colorSchema = c;
        }
        //===========E N D  S E T T E R S===========================
        //==============G E T T E R S===============================
        public int getID() 
        {
            return id;
        }
        public int getWin()
        {
            return win;
        }
        public char getGameType()
        {
            return gameType;
        }
        public int getMoveCount()
        {
            return moveCount;
        }
        public string getColorSchema()
        {
            return colorSchema;
        }
        //===========E N D  G E T T E R S===========================
        //===========U T I L I T Y  F U N C T I O N S===============
        //I can only conjure up "assembleEntry" - DS
        public string assembleEntry(Game o)
        {
            //This assembles the string to place in the GameHist .txt within the resource file
            string entry = "";
            char delim = ',';
            entry += o.getID().ToString();
            entry += delim.ToString();
            entry += o.getWin().ToString();
            entry += delim.ToString();
            entry += o.getGameType().ToString();
            entry += delim.ToString();
            entry += o.getMoveCount().ToString();
            entry += delim.ToString();
            entry += o.getColorSchema();
            return entry;
        }
        public Game stringToGame(string s)
        {
            //This is a function taking a string and converting to an Game;
            Game g = new Game();
            char delim = ',';
            int delimPOS;
            delimPOS = s.IndexOf(delim);
            g.setID(Int32.Parse(s.Substring(0, delimPOS)));
            s = s.Substring(delimPOS + 1);
            delimPOS = s.IndexOf(delim);
            g.setWin(Int32.Parse(s.Substring(0, delimPOS)));
            s = s.Substring(delimPOS + 1);
            delimPOS = s.IndexOf(delim);
            g.setGameType(s[0]);
            s = s.Substring(delimPOS + 1);
            delimPOS = s.IndexOf(delim);
            g.setMoveCount(Int32.Parse(s.Substring(0, delimPOS)));
            s = s.Substring(delimPOS + 1);
            g.setColorSchema(s);
            return g;
        }
        public string filePath()
        {
            //Designate this as PATH for other Forms
            string p = "../../Resources/GameHist.txt";
            return p;
        }
        public void writeToFile(string e)
        {
            //Since Lists aren't on every form, we are going to run a while loop to count lines, and use for post for-loop to know where to add our latest game
            //Since, you can't play backwards via time.
            string p = filePath();
            StreamReader fileAppend = new StreamReader(p);
            string line = fileAppend.ReadLine();
            int lineCount = 0;
            while(line != null)
            {
                lineCount++;
                line = fileAppend.ReadLine();
            }    
            for(int i = 0; i < lineCount; i++)
            {
                if (i == 0)
                {
                    File.AppendAllText(p, e);
                }
                else
                {
                    File.AppendAllText(p, Environment.NewLine + e);
                }
            }
        }
        public List<Game> parseFile(List<Game> gameHistory)
        {
            //This is a function to parse the GameHist.txt into a List of Game Objects for reference on StatsForm and ReviewForm
            string p = filePath();
            StreamReader fileRead = new StreamReader(p);
            string line = fileRead.ReadLine();
            int index = 0;
            while(line != null)
            {
                if (assembleEntry(gameHistory[index]) == line)
                {
                    index++;
                    continue;
                }
                else
                {
                    gameHistory.Add(stringToGame(line));
                    index++;
                }
            }
            return gameHistory;
        }
        public int getp1Win(List<Game> g)
        {
            //This is a function to return the int of p1 wins to ReviewForm
            int p1WinCount = 0;
            for (int i = 0; i < g.Count; i++)
            {
                if(g[i].getWin() == 0)
                {
                    p1WinCount++;
                }
            }
            return p1WinCount;
        }
        public int getCPUWin(List<Game> g)
        {
            //This is a function to return the int of CPU wins to ReviewForm
            int cpuWinCount = 0;
            for (int i = 0; i < g.Count; i++)
            {
                if (g[i].getWin() == 1)
                {
                    cpuWinCount++;
                }
            }
            return cpuWinCount;
        }
        public int getTie(List<Game> g)
        {
            //This returns the int for ties to StatsForm
            int tieCount = 0;
            for(int i = 0; i < g.Count; i++)
            {
                if (g[i].getWin() == 2)
                {
                    tieCount++;
                }
            }
            return tieCount;
        }
        public double calcp1Win(List<Game> g)
        {
            //This returns the double for p1 win percentage to StatsForm
            int p1WinCount = getp1Win(gameHistory);
            int totalGames = g.Count;
            if (totalGames == 0)
            {
                return 0;
            }
            double p1WinPercentage = (double)p1WinCount / totalGames * 100;
            return p1WinPercentage;
        }
        public double calcCPUwin(List<Game> g)
        {
            //This returns the double for CPU win percentage to StatsForm
            int cpuWinCount = getCPUWin(gameHistory);
            int totalGames = g.Count;
            if (totalGames == 0)
            {
                return 0;
            }
            double cpuWinPercentage = (double)cpuWinCount / totalGames * 100;
            return cpuWinPercentage;
        }
        public int getIDcheck()
        {
            //Goes through gameHistory and returns highest ID + 1;
            int ID = 0;
            for (int i = 0; i < gameHistory.Count; i++)
            {
                if(gameHistory[i].getID() > ID)
                {
                    ID = gameHistory[i].getID();
                }
            }
            //End of Loop; Add 1 to ID to identify new position
            ID++;
            return ID;

        }
    //==========E N D  U T I L I T Y  F U N C T I O N S=========
    //End -DS
    }
}
