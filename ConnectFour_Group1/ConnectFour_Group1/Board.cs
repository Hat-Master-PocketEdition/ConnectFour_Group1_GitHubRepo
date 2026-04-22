using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace ConnectFour_Group1
{
    internal class Board
    {
        //The Board class is merely a vessel that contains
        //a 2D Cell array.
        //-DS Let's add private const int for better definition
        //Also added numRows / numCols to For Loops for better control
        int numPlayers = 2;
        private const int numRows = 7;
        private const int numCols = 6;
        Cell[,] board = new Cell[numRows, numCols];
        bool control = false;

        Label theLabel = new Label();

        int CurrentPlayer = 1;

        //these could be hard coded to just red and yellow without using variables 
        //but i thought it might be cool to come back and allow players to pick
        //their own colors later on. Plus it doesn't hurt to have them here if
        //we never get/got to it.
        Image PlayerOneColor = Image.FromFile(@"../../Resources/RedChip.png");
        Image PlayerTwoColor = Image.FromFile(@"../../Resources/YellowChip.png");
        Image CurrentPlayerColor;
        //Reading through, how does data get to CodeBoard?
        //I have a scaffold (copyBoard) - DS
        int[,] CodeBoard = new int[numRows, numCols];
        public Board()
        {
            //"this" does not exist in the current context
            //keeping this blank, this is never invoked on purpose
        }
        public Board(Form parentForm, Image placeholder, int numPlayers)
        {
            //this constructor takes a placeholder image to act as empty space in
            //the connect four grid
            this.numPlayers = numPlayers;
            CurrentPlayerColor = PlayerOneColor;
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    board[x, y] = new Cell("0", x, y);

                    //i think this location variable needs a little explaining
                    //these numbers procedurally place the board in approximately
                    //the center of the screen. if we ever decide to change the
                    //size of the form at some point in the future, I will need
                    //to manually change those values.
                    
                    //this y value is negative because a 2d array's values 
                    //start in the top-left instead of the bottom left. inversing
                    //the y-axis here changes the graph it to be more legible 
                    board[x, y].Location = new Point(200 + (x * 50), 300 + (-y * 44));

                    board[x, y].Image = placeholder;
                    board[x, y].Size = new Size(50, 40);
                    board[x, y].Cursor = Cursors.Hand;
                    board[x, y].BorderStyle = BorderStyle.None;
                    board[x, y].Name = x + ", " + y;

                    board[x, y].SetX(x);
                    board[x, y].SetY(y);

                    board[x, y].MouseEnter += MouseEnter;
                    board[x, y].MouseLeave += MouseLeave;
                    board[x, y].Click += PictureBox_Clicked;

                    parentForm.Controls.Add(board[x, y]);
                    //CodeBoard[x, y] = 0;
                }
            }
            theLabel.Location = new Point(300, 10);
            theLabel.AutoSize = true;
            //yeah i made it comic sans on purpose, what about it?
            theLabel.Font = new Font("Comic Sans MS", 15, FontStyle.Regular);
            if (numPlayers == 1) { theLabel.Text = "Player vs. Bot"; }
            else { theLabel.Text = "Player vs. Player\nRed's Turn"; }
            parentForm.Controls.Add(theLabel);
            control = true;
        }
        public Cell At(int x, int y)
        {
            //just returns the cell at the coordinates provided
            //from there, you can pull whatever code you need
            return board[x, y];
        }
        private void PictureBox_Clicked(object sender, EventArgs e)
        {
            //only do something if the program isnt doing anything like
            //dropping a chips, checking win states
            //or if the game isn't over
            if(control)
            {
                Cell curCell = sender as Cell;

                //reverse-engineering the location data to get the 2d array
                //coordinates of the PictureBox array the cursor clicked.

                int x = curCell.GetX();
                int y = curCell.GetY();

                //int x = (Pic.Location.X - 200) / 48;
                //int y = -(Pic.Location.Y - 300) / 44;

                //we can use that X and Y data to translate it to CodeBoard
                //GameBoard[] and CodeBoard[] are set up the exact same way, so we
                //basically we swap out RedChip.png and YellowChip.png for 1 and 2
                DropChip(CurrentPlayer, x, y);
                MouseEnter(sender, e);
            }

        }
        private void MouseEnter(object sender, EventArgs e)
        {
            if (control)
            {
                PictureBox Pic = sender as PictureBox;
                int x = (Pic.Location.X - 200) / 48;
                int y = -(Pic.Location.Y - 300) / 44;
                HoverChip(CurrentPlayerColor, x);
            }
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            RedrawGameBoard();
        }
        private void DropChip(int player, int x, int y)
        {
            control = false;
            Debug.WriteLine("Dropping Player " + player + "'s Chip at: " + x + ", " + y);

            //This function handles the dropping of a player's chip
            //it traverses a column of CodeBoard until it finds an
            //open spot that "obeys the laws of gravity."

            bool ValidMove = false;

            int startY = 5;
            while (true)
            {
                if (CodeBoard[x, startY] != 0)
                {
                    //this column is already filled up
                    //we cannot drop the chip here
                    //do nothing and break

                    break;
                }
                else if (startY == 0)
                {
                    //startY has traversed as far as it can go
                    //that means it's hit the bottom of the game board
                    //we will place the chip here :)
                    //Debug.WriteLine("WRITING");
                    CodeBoard[x, startY] = player;
                    //Debug.WriteLine("SAVED " + player + " TO CodeBoard[" + x + ", " + y + "]");

                    ValidMove = true;
                    break;

                }
                else if (CodeBoard[x, startY - 1] == 1)
                {
                    //The spot below startY is occupied by player 1
                    //place the chip here

                    //Debug.WriteLine("WRITING");
                    CodeBoard[x, startY] = player;
                    //Debug.WriteLine("SAVED " + player + " TO CodeBoard[" + x + ", " + startY + "]");

                    ValidMove = true;
                    break;
                }
                else if (CodeBoard[x, startY - 1] == 2)
                {
                    //The spot below startY is occupied by player 2
                    //place the chip here

                    //Debug.WriteLine("WRITING");
                    CodeBoard[x, startY] = player;
                    //Debug.WriteLine("SAVED " + player + " TO CodeBoard[" + x + ", " + startY + "]");

                    ValidMove = true;
                    break;
                }
                else if (CodeBoard[x, startY] == 0)
                {
                    //there is empty space below the currently falling chip

                    //Debug.WriteLine("CodeBoard at [" + x + ", " + startY + "] is empty");
                    startY--;
                }

            }
            RedrawGameBoard();
            if (ValidMove)
            {
                //if WinStateChecking returns 4 in this scenarion, that means the current player one
                Debug.WriteLine(WinStateChecking(x, y, player));
                if (WinStateChecking(x, y, player) >= 4)
                {
                    PlayerWon(player);
                }
                else
                {
                    //if not, proceed to next player turn;
                    NextPlayerTurn();
                    control = true;
                }

            }
            PrintCodeBoardToConsole();
        }
        private void HoverChip(Image color, int x)
        {

            //HoverChip is a carbon copy of Drop Chip with some slight differences
            //and both vary from each other a lot with changes that came after
            //instead of handling placing chips, this manages the "hologram" that 
            //allows a player to preview their move

            //AW
            int startY = 5;
            while (true)
            {
                if (startY == 0)
                {
                    //Debug.WriteLine("2");

                    board[x, startY].Image = color;

                    break;

                }
                else if (CodeBoard[x, startY - 1] == 1)
                {
                    //Debug.WriteLine("3");

                    //startY has fallen and found another chip
                    //we will place it on top of that chip
                    board[x, startY].Image = color;

                    break;
                }
                else if (CodeBoard[x, startY - 1] == 2)
                {
                    //Debug.WriteLine("3");

                    //startY has fallen and found another chip
                    //we will place it on top of that chip
                    board[x, startY].Image = color;

                    break;
                }
                else if (CodeBoard[x, startY] == 0)
                {
                    //there is empty space below the currently falling chip

                    //Debug.WriteLine("CodeBoard at [" + x + ", " + startY + "] is empty");
                    //Debug.WriteLine("4");

                    startY--;
                }

            }
        }
        private int HighestAvailablePointInColumn(int x)
        {
            //this function returns the highest point in the column 
            //returns nintey nine if column is full

            //this is a slight copy/paste of HoverChip
            int startY = 5;
            if (CodeBoard[x, 5] != 0)
            {
                //if CodeBoard at the highest point isn't 0, column is full
                return 99;
            }
            while (true)
            {
                if (startY == 0)
                {
                    //the whileloop has traversed to the bottom of the column
                    //return the lowest possible value, zero
                    return 0;
                }
                else if (CodeBoard[x, startY - 1] != 0)
                {
                    //the whileloop has reached the highest available point
                    //return the current point

                    return startY;
                }
                else if (CodeBoard[x, startY] == 0)
                {
                    //there is empty space below the currently falling chip
                    //we haven't reached to highest availble point
                    //keep going

                    startY--;
                }
                

            }
        }
        private void RedrawGameBoard()
        {
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    if (CodeBoard[x, y] == 0)
                    {
                        board[x, y].Image = Image.FromFile(@"../../Resources/BlackChip.png");
                    }
                    else if (CodeBoard[x, y] == 1)
                    {
                        board[x, y].Image = Image.FromFile(@"../../Resources/RedChip.png");
                    }
                    else if (CodeBoard[x, y] == 2)
                    {
                        board[x, y].Image = Image.FromFile(@"../../Resources/YellowChip.png");
                    }
                }
            }
        }
        private void PrintCodeBoardToConsole()
        {
            //Debug function, remains hard-coded
            Debug.WriteLine("");
            for (int y = 6; y > 0; y--)
            {
                for (int x = 0; x < 7; x++)
                {
                    Debug.Write(" " + CodeBoard[x, y - 1] + " ");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");

        }
        private void BotTurn()
        {
            Debug.WriteLine("start of bot turn");

            int currentHighestChain = 0;
            //if the bot doesn't know what to do
            //just place chip in random column
            int highestChainAtColumn = 0;

            //first, check to see if the human can win next turn, take effort to block it
            for (int i = 0; i < numCols; i++)
            {

                int currentColumnChain = WinStateChecking(i, HighestAvailablePointInColumn(i), 1);
                if (currentHighestChain < currentColumnChain && currentColumnChain != 99)
                {
                    //if currentColumnChain is nintey nine, that means the column is full. 
                    //the bot should not try to drop a chip in this column
                    currentHighestChain = currentColumnChain;
                    highestChainAtColumn = i;
                }
            }
            if (currentHighestChain == 4)
            {
                //if the current highest chain while tracking the player is 4
                //take effort to block the player's move
                DropChip(2, highestChainAtColumn, 5);
            }
            else
            {

                //if currentHighestChain doesn't turn up as 4, then the player isn't about to win
                //the bot should then continue to pursue it's own chain
                currentHighestChain = 0;
                highestChainAtColumn = 0;
                for (int i = 0; i < numCols; i++)
                {
                    int currentColumnChain = WinStateChecking(i, HighestAvailablePointInColumn(i), 2);
                    Debug.WriteLine("currentColumnChain at i = " + i + ": " + currentColumnChain);
                    if (currentHighestChain < currentColumnChain && currentColumnChain != 99)
                    {
                        currentHighestChain = currentColumnChain;
                        highestChainAtColumn = i;
                    }
                }
                Debug.WriteLine("currentHighestChain: " + currentHighestChain);
                if (currentHighestChain == 2)
                {
                    //if the highest chain returned is 2, then the board is either fresh
                    //or there are no "good" spots to play
                    //in this case, we can just have the bot drop the chip anywhere :)


                    Random rng = new Random();
                    int randomColumn = rng.Next(1, numCols);
                    Debug.WriteLine("doing random spot at: " + randomColumn);
                    DropChip(2, randomColumn, 5);
                }
                else
                {
                    DropChip(2, highestChainAtColumn, 5);
                }
            }
            Debug.WriteLine("end of bot turn");
        }
        private void NextPlayerTurn()
        {
            if (CurrentPlayer == 1 && numPlayers == 2)
            {
                //in 2 player mode
                //player 1 just played
                //change to player 2
                CurrentPlayer = 2;
                CurrentPlayerColor = PlayerTwoColor;
                theLabel.Text = "Player vs. Player\nYellow's Turn";
            }
            else if (CurrentPlayer == 2 && numPlayers == 2)
            {
                //in 2 player mode
                //player 2 just played
                //change to player 1
                CurrentPlayer = 1;
                CurrentPlayerColor = PlayerOneColor;
                theLabel.Text = "Player vs. Player\nRed's Turn";

            }
            else if (CurrentPlayer == 1 && numPlayers == 1)
            {
                //in 1 player mode
                //human just played
                //BotTurn
                CurrentPlayer = 2;
                CurrentPlayerColor = PlayerTwoColor;
                BotTurn();
            }
            else if (CurrentPlayer == 2 && numPlayers == 1)
            {
                //in 1 player mode
                //bot just played
                //change to player 1;
                CurrentPlayer = 1;
                CurrentPlayerColor = PlayerOneColor;
            }
        }
        private int WinStateChecking(int playedSpotX, int playedSpotY, int currentPlayer)
        {
            //AW
            
            //The following function is divided into four segments via brackets
            //each segment searches for how many chips are in-a-row in their
            //given direction.


            //First, we will check if we have a 4-in-a-row in the single column
            //we only need to check downwards because nothing can be above
            //the chip we just dropped
            int superY = playedSpotY;
            int superX = playedSpotX;

            Debug.WriteLine("attempting to resolve: " + playedSpotX + ", " + playedSpotY);
            if(playedSpotY == 99)
            {
                //if this passes true, then the column is full, the bot shouldn't try to DropChip here
                //under any circumstances

                //return zero here, since BotTurn() will read this and pass over the column
                Debug.WriteLine("returning 0");
                return 0;
                
            }
            int chain = 1;
            int largestChain = 1;
            bool keepGoing = true;

            //check for DIRECTLY BELOW
            {
                keepGoing = CheckIfArrayInBounds(superX, superY, "down", "none");

                while (keepGoing)
                {
                    if (superY > 0 && CodeBoard[playedSpotX, superY - 1] == currentPlayer)
                    {
                        chain++;
                        //Debug.WriteLine("VERTICAL CHAIN: " + chain);
                        superY--;
                    }
                    else
                    {
                        keepGoing = false;
                        //Debug.WriteLine("VERTICAL CHAIN: " + chain + ", STOPPING");
                    }
                }
                if (chain > largestChain)
                {
                    
                    Debug.WriteLine("Setting largestChain to " +  chain + ", previously " + largestChain);
                    largestChain = chain;
                    //Debug.WriteLine("chain: " + chain + ", " + "returned WIN for PLAYER " + currentPlayer);
                }
                //else
                //{
                //    Debug.WriteLine("VERTICAL CHAIN:  " + chain + ", MOVING ON");


                //    //return false;
                //}


                //reset all values because each check is separate from the others
                superY = playedSpotY;
                chain = 1;
                keepGoing = true;
            }
            //check for EAST and WEST
            {
                //This is WEST
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "none", "left");
                    if (keepGoing)
                    {
                        if (superX > 0 && CodeBoard[superX - 1, playedSpotY] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("WEST CHAIN: " + chain);
                            superX--;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("WEST CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //the previous only checks for West
                //reset all the values except for chain
                //because the previous chain still carries over
                keepGoing = true;
                superY = playedSpotY;
                superX = playedSpotX;
                //same loop, just inverting the axis 
                //This is EAST
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "none", "r");
                    if (keepGoing == true)
                    {
                        if (superY > 0 && CodeBoard[superX + 1, playedSpotY] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("EAST CHAIN: " + chain);
                            superX++;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("EAST CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //now we can check if chain wins
                //This is EAST-WEST CHECKING
                if (chain > largestChain)
                {

                    Debug.WriteLine("Setting largestChain to " + chain + ", previously " + largestChain);
                    largestChain = chain;
                    //Debug.WriteLine("EAST-WEST chain: " + chain + ", " + "returned WIN for PLAYER " + currentPlayer);
                    //return true;
                }
                //else
                //{
                //    Debug.WriteLine("EAST-WEST CHAIN: " + chain + ", MOVING ON");
                //    //return false;
                //}

                //reset all values because each check is separate from the others
                superY = playedSpotY;
                superX = playedSpotX;
                chain = 1;
                keepGoing = true;
            }
            //check for the SOUTHWEST and NORTHEAST diagonals
            {
                //This is SOUTHWEST DIAGONAL
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "down", "left");
                    if (keepGoing)
                    {
                        if (superY > 0 && CodeBoard[superX - 1, superY - 1] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("SouthWest CHAIN: " + chain);
                            superY--;
                            superX--;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("SouthWest CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //the previous only checks for SouthWest
                //reset all the values except for chain
                //because the previous chain still carries over
                keepGoing = true;
                superY = playedSpotY;
                superX = playedSpotX;
                //same loop, just inverting the axis 
                //This is NORTHEAST DIAGONAL
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "up", "r");
                    if (keepGoing == true)
                    {
                        if (superY > 0 && CodeBoard[superX + 1, superY + 1] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("NorthEast CHAIN: " + chain);
                            superY++;
                            superX++;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("NorthEast CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //now we can check if chain wins
                //This is SOUTHEAST-NORTHWEST DIAGONAL
                if (chain > largestChain)
                {

                    Debug.WriteLine("Setting largestChain to " + chain + ", previously " + largestChain);
                    largestChain = chain;
                    //Debug.WriteLine("NE-SW CHAIN:     " + chain + ", " + "returned WIN for PLAYER " + currentPlayer);
                    //return true;
                }
                //else
                //{
                //    Debug.WriteLine("NE-SW CHAIN:     " + chain + ", MOVING ON");
                //    //return false;
                //}

                //reset all values because each check is separate from the others
                superY = playedSpotY;
                superX = playedSpotX;
                chain = 1;
                keepGoing = true;
            }
            //check for the SOUTHEAST and NORTHWEST diagonals
            {
                //This is SOUTHEAST DIAGONAL
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "down", "r");
                    if (keepGoing)
                    {
                        if (superY > 0 && CodeBoard[superX + 1, superY - 1] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("SouthEast CHAIN: " + chain);
                            superY--;
                            superX++;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("SouthEast CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //the previous only checks for SouthEast
                //reset all the values except for chain
                //because the previous chain still carries over
                keepGoing = true;
                superY = playedSpotY;
                superX = playedSpotX;

                //same loop, just inverting the axis
                //This is NORTHWEST DIAGONAL
                while (keepGoing)
                {
                    keepGoing = CheckIfArrayInBounds(superX, superY, "up", "left");
                    if (keepGoing == true)
                    {
                        if (superY > 0 && CodeBoard[superX - 1, superY + 1] == currentPlayer)
                        {
                            chain++;
                            //Debug.WriteLine("NorthWest CHAIN: " + chain);
                            superY++;
                            superX--;
                        }
                        else
                        {
                            keepGoing = false;
                            //Debug.WriteLine("NorthWest CHAIN: " + chain + ", STOPPING");
                        }
                    }
                }
                //now we can check if chain wins
                if (chain > largestChain)
                {

                    Debug.WriteLine("Setting largestChain to " + chain + ", previously " + largestChain);
                    largestChain = chain;
                    //Debug.WriteLine("SE-NW CHAIN:     " + chain + ", " + "returned WIN for PLAYER " + currentPlayer);
                    //return true;
                }
                //else
                //{
                //    Debug.WriteLine("SE-NW CHAIN:     " + chain + ", MOVING ON");

                //    //since this is the last check in the loop, return false
                    
                //}

            }

            return largestChain;
        }
        public bool CheckIfArrayInBounds(int superX, int superY, string intentUD, string intentLR)
        {
            //these if-statements ensure the hypothetical pointer never goes out-of-bounds
            //from the array

            //intent is just which direction the "pointer" would be going, with UD = UpDown and LR = LeftRight
            //example: diagonal NorthWest would be intentUD = "up" and intentLR = "left"
            //this was done because certain movements skirt right across the edge of the board, and they would
            //constantly be caught 

            if (intentUD == "up" && superY + 1 > 5)
            {
                //Debug.WriteLine("superY + 1 = " + (superY + 1).ToString() + ", out of bounds");
                return false;
            }
            if (intentUD == "down" && superY - 1 < 0)
            {
                //Debug.WriteLine("superY - 1 = " + (superY - 1).ToString() + ", out of bounds");
                return false;
            }
            if (intentLR == "r" && superX + 1 > 6)
            {
                return false;
            }
            if (intentLR == "left" && superX - 1 < 0)
            {
                //Debug.WriteLine("superX - 1 = " + (superX - 1).ToString() + ", out of bounds");

                return false;
            }

            //if all those passed, then the array is still in bounds, return true;
            //Debug.WriteLine("no out of bounds detected");


            return true;
            
        }
        public Board copyBoard()
        {
            //Copy function to allow the AI to calculate passing a board
            Board copy = new Board();
            //copy only the state
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    //Using this nested for Loop, we can put the data onto the copy and return it. Seeing how we can take board -> CodeBoard
                    //TypeCast board data -> CodeBoard data? - DS
                }
            }
            return copy;
        }
        public void PlayerWon(int player)
        {
            control = false;
            if (player == 1)
            {
                theLabel.Text = "Red Wins!";
                theLabel.ForeColor = Color.FromArgb(186, 0, 0);
            }
            else if (player == 2)
            {
                theLabel.Text = "Yellow Wins!";
                theLabel.ForeColor = Color.FromArgb(199, 199, 0);
            }
        }
    }
    
}
