using System;
using System.Collections.Generic;
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
        public Board()
        {
            //"this" does not exist in the current context
        }
        public Board(Form parentForm, Image placeholder)
        {
            //this constructor takes a placeholder image to act as empty space in
            //the connect four grid

            //CurrentPlayerColor = PlayerOneColor;
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

                    //board[x, y].MouseEnter += new EventHandler(MouseEnter);
                    //board[x, y].MouseLeave += new EventHandler(MouseLeave);
                    //board[x, y].Click += new EventHandler(PictureBox_Clicked);

                    parentForm.Controls.Add(board[x, y]);

                    //CodeBoard[x, y] = 0;
                }
            }
        }
        public Cell At(int x, int y)
        {
            return board[x, y];
        }
    }
}
