using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectFour_Group1.Properties;

namespace ConnectFour_Group1
{
    public partial class PvPForm : Form
    {
        Image Highlighter = Image.FromFile(@"../../Resources/PurpleChip.png");
        PictureBox[,] GameBoard = new PictureBox[7, 6];
        int[,] CodeBoard = new int[7, 6];
        public PvPForm()
        {
            InitializeComponent();
            InitializeBoard(GameBoard);
            TestPictureBox.Image = Image.FromFile(@"../../Resources/BlackChip.png");
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

        private void InitializeBoard(PictureBox[,] board)
        {
            //This Function creates the visuals for the gameboard
            //using a nested for-loop
            //This is only used for the spawning each cell of the
            //game board

            //AW

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    board[x, y] = new PictureBox();

                    board[x, y].Image = Image.FromFile(@"../../Resources/BlackChip.png");
                    board[x, y].Size = new Size(40, 40);
                    board[x, y].Location = new Point(200 + (x * 48), 300 + (-y * 44));
                    board[x, y].Cursor = Cursors.Hand;
                    board[x, y].BorderStyle = BorderStyle.None;
                    board[x, y].Name = x + ", " + y;

                    board[x, y].MouseEnter += new EventHandler(MouseEnter);
                    board[x, y].MouseLeave += new EventHandler(MouseLeave);
                    board[x, y].Click += new EventHandler(PictureBox_Clicked);

                    this.Controls.Add(board[x, y]);

                    CodeBoard[x, y] = 0;
                }
            }
        }

        private void PictureBox_Clicked(object sender, EventArgs e)
        {
            PictureBox Pic = sender as PictureBox;

            //reverse-engineering the location data to get the 2d array
            //coordinates of the PictureBox array the cursor clicked.
            int x = (Pic.Location.X - 200) / 48;
            int y = -(Pic.Location.Y - 300) / 44;

            //we can use that X and Y data to translate it to CodeBoard
            //GameBoard[] and CodeBoard[] are set up the exact same way, so we
            //basically we swap out RedChip.png and YellowChip.png for 1 and 2
            DropChip("red", 1, x, y);
            MouseEnter(sender, e);
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            PictureBox Pic = sender as PictureBox;
            //Pic.Image = Highlighter;
            HoverChip("red", 1, (Pic.Location.X - 200) / 48, -(Pic.Location.Y - 300) / 44);
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            RedrawGameBoard();
        }

        private void RedrawGameBoard()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (CodeBoard[x, y] == 0)
                    {
                        GameBoard[x, y].Image = Image.FromFile(@"../../Resources/BlackChip.png");
                    }
                    else if (CodeBoard[x, y] == 1)
                    {
                        GameBoard[x, y].Image = Image.FromFile(@"../../Resources/RedChip.png");
                    }
                    else if (CodeBoard[x, y] == 2)
                    {
                        GameBoard[x, y].Image = Image.FromFile(@"../../Resources/YellowChip.png");
                    }
                }
            }
        }
        private void DropChip(string color, int player, int x, int y)
        {
            //This function handles the dropping of a player's chip
            //it traverses a collumn of CodeBoard until it finds an
            //open spot that "obeys the laws of gravity."
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
                    Debug.WriteLine("WRITING");
                    CodeBoard[x, startY] = player;
                    Debug.WriteLine("SAVED " + player + " TO CodeBoard[" + x + ", " + y + "]");

                    break;

                }
                else if (CodeBoard[x, startY - 1] == 1)
                {
                    Debug.WriteLine("WRITING");
                    CodeBoard[x, startY] = player;
                    Debug.WriteLine("SAVED " + player + " TO CodeBoard[" + x + ", " + startY + "]");

                    break;
                }
                else if (CodeBoard[x, startY] == 0)
                {
                    //there is empty space below the currently falling chip

                    Debug.WriteLine("CodeBoard at [" + x + ", " + startY +"] is empty");
                    startY--;
                }

            }
            RedrawGameBoard();
            //PrintCodeBoardToConsole();
        }
        private void HoverChip(string color, int player, int x, int y)
        {
            //HoverChip() is a carbon copy of DropChip with some slight differences
            //instead of handling placing chips, this manages the "hologram" that 
            //allows a player to preview their move

            //AW
            int startY = 5;
            while (true)
            {
                if (CodeBoard[x, startY] != 0)
                {
                    //this column is already filled up
                    //we cannot drop the chip here
                    //do nothing
                }
                else if (startY == 0)
                {

                    GameBoard[x, startY].Image = Image.FromFile(@"../../Resources/RedChip.png"); ;

                    break;

                }
                else if (CodeBoard[x, startY - 1] == 1)
                {
                    //startY has fallen and found another chip
                    //we will place it on top of that chip
                    GameBoard[x, startY].Image = Image.FromFile(@"../../Resources/RedChip.png"); ;

                    break;
                }
                else if (CodeBoard[x, startY] == 0)
                {
                    //there is empty space below the currently falling chip

                    //Debug.WriteLine("CodeBoard at [" + x + ", " + startY + "] is empty");
                    startY--;
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
                    Debug.Write(CodeBoard[x, y - 1] + "");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");

        }

        private void TestPictureBox_Click(object sender, EventArgs e)
        {
            PrintCodeBoardToConsole();

        }
    }
}
