using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Cell[,] board = new Cell[7, 6];

        int CurrentPlayer = 1;

        //these could be hard coded to just red and yellow without using variables 
        //but i thought it might be cool to come back and allow players to pick
        //their own colors later on. Plus it doesn't hurt to have them here if
        //we never get/got to it.
        Image PlayerOneColor = Image.FromFile(@"../../Resources/RedChip.png");
        Image PlayerTwoColor = Image.FromFile(@"../../Resources/YellowChip.png");
        Image CurrentPlayerColor;
        int[,] CodeBoard = new int[7, 6];
        public Board()
        {
            //"this" does not exist in the current context
        }
        public Board(Form parentForm, Image placeholder)
        {
            //this constructor takes a placeholder image to act as empty space in
            //the connect four grid

            CurrentPlayerColor = PlayerOneColor;
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    board[x, y] = new Cell("0", x, y);

                    //i think this location variable needs a little explaining
                    //these numbers procedurally place the board in aproximately
                    //the center of the screen. if we ever decide to change the
                    //size of the form at some point in the future, I will need
                    //to manually change those values.
                    
                    //this y value is negative because a 2d array's values 
                    //start in the top-left instead of the bottom left. inversing
                    //the y-axis here changes the graph it to be more legible 
                    board[x, y].Location = new Point(200 + (x * 48), 300 + (-y * 44));

                    board[x, y].Image = placeholder;
                    board[x, y].Size = new Size(40, 40);
                    board[x, y].Cursor = Cursors.Hand;
                    board[x, y].BorderStyle = BorderStyle.None;
                    board[x, y].Name = x + ", " + y;

                    board[x, y].SetX(x);
                    board[x, y].SetY(y);
                    
                    Debug.WriteLine(board[x, y].GetX() + ", " + board[x, y].GetY());
                    Debug.WriteLine(board[x, y].Name);


                    board[x, y].MouseEnter += MouseEnter;
                    board[x, y].MouseLeave += MouseLeave;
                    board[x, y].Click += PictureBox_Clicked;

                    parentForm.Controls.Add(board[x, y]);

                    //CodeBoard[x, y] = 0;
                }
            }
        }
        public Cell At(int x, int y)
        {
            //just returns the cell at the coordinates provided
            //from there, you can pull whatever code you need
            return board[x, y];
        }
        private void PictureBox_Clicked(object sender, EventArgs e)
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
            DropChip(CurrentPlayerColor, CurrentPlayer, x, y);
            MouseEnter(sender, e);
        }
        private void MouseEnter(object sender, EventArgs e)
        {
            PictureBox Pic = sender as PictureBox;
            int x = (Pic.Location.X - 200) / 48;
            int y = -(Pic.Location.Y - 300) / 44;
            Debug.WriteLine("MouseEnter");
            Debug.WriteLine(x + ", " + y);
            HoverChip(CurrentPlayerColor, CurrentPlayer, x, y);
            Debug.WriteLine("MouseEnded");
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            RedrawGameBoard();
        }
        private void DropChip(Image color, int player, int x, int y)
        {

            Debug.WriteLine(x + ", " + y);


            //This function handles the dropping of a player's chip
            //it traverses a collumn of CodeBoard until it finds an
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
            if (ValidMove)
            {
                Debug.WriteLine("VALID MOVE");
                NextPlayerTurn();
            }
            RedrawGameBoard();
            PrintCodeBoardToConsole();


        }
        private void HoverChip(Image color, int player, int x, int y)
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
        private void RedrawGameBoard()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
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
        private void NextPlayerTurn()
        {
            if (CurrentPlayer == 1)
            {
                Debug.WriteLine("CHANGING TO PLAYER 2");
                CurrentPlayer = 2;
                CurrentPlayerColor = PlayerTwoColor;
            }
            else if (CurrentPlayer == 2)
            {
                Debug.WriteLine("CHANGING TO PLAYER 1");
                CurrentPlayer = 1;
                CurrentPlayerColor = PlayerOneColor;
            }
            Debug.WriteLine("CHANGES COMPLETE");

        }
    }
}
