using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group1
{
    public class Game
    {
        //Created by DS; 4/15/26
        //Instill Private Variables of the Object for definition of Game Object
        //MM,DD,YYYY,W,G,M,C

        //MM,
        private string month;
        //DD,
        private string day;
        //YYYY
        private string year;
        //W; 0 - P1; 1 - P2; 2 - AI; 3 - Tie;
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

        }
        //Overloaded Constructor
        public Game(string m, string d, string y, int w, char g, int mC, string c)
        {
            month = m;
            day = d;
            year = y;
            win = w;
            gameType = g;
            moveCount = mC;
            colorSchema = c;
        }
        //==========S e t t e r s==================================
        public void setMonth(string m)
        {
            month = m;
        }
        public void setDay(string d)
        {
            day = d;
        }
        public void setYear(string y)
        {
            year = y;
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
        public string getMonth()
        {
            return month;
        }
        public string getDay()
        {
            return day;
        }
        public string getYear()
        {
            return year;
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
            entry += o.getMonth();
            entry += delim.ToString();
            entry += o.getDay();
            entry += delim.ToString();
            entry += o.getYear();
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
        //==========E N D  U T I L I T Y  F U N C T I O N S=========
        //End -DS
    }
}
