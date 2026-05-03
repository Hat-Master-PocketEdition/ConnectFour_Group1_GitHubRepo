using System.Diagnostics;
using System.Windows.Forms;

namespace ConnectFour_Group1
{
    public partial class ReviewForm : Form
    {
        Cell point1 = new Cell();
        Cell point2 = new Cell();
        int winner;
        Cell[,] board = new Cell[7, 6];
        bool control = false;
        bool isPVP;
        public ReviewForm()
        {
            InitializeComponent();
        }
        public ReviewForm(int playerWon, int formType, Cell[,] berd, Cell point1, Cell point2)
        {
            InitializeComponent();
            Debug.WriteLine("OPENING REVIEWFORM");
            if(playerWon < 3 && playerWon > 0)
            {
                //Keeps this to only actual winners
                winner = playerWon;
            }
            this.point1 = point1;
            this.point2 = point2;
            this.isPVP = (formType == 2);
            //Debug.WriteLine("[ " + point1.Location.X + ", " + point1.Location.Y + "]");
            //Debug.WriteLine("[ " + point2.Location.X + ", " + point2.Location.Y + "]");
            theLabel.Font = new Font("Comic Sans MS", 15, FontStyle.Regular);
            if (playerWon == 1)
            {
                theLabel.Text = "Red Wins!";
                theLabel.ForeColor = Color.FromArgb(186, 0, 0);
                this.Icon = new System.Drawing.Icon(@"../../Resources/RedIcon.ico");
            }
            else if (playerWon == 2)
            {
                theLabel.Text = "Yellow Wins!";
                theLabel.ForeColor = Color.FromArgb(199, 199, 0);
                this.Icon = new System.Drawing.Icon(@"../../Resources/YellowIcon.ico");
            }
            //Draw check; since we can have the point passed from Board (in a draw) be 0,0 - 6,5; 
            else if (playerWon == 3)
            {
                theLabel.Text = "Tie! No One Wins!";
                theLabel.ForeColor = Color.FromArgb(181, 112, 24);
            }
                this.Controls.Add(theLabel);
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    //this.Controls.Add(berd[x, y]);
                    board[x, y] = berd[x, y];
                    this.Controls.Add(board[x, y]);
                }
            }
            if(playerWon != 3)
            {
                //This ensures lines are drawn ONLY for winners, no full board illuminations
                DrawLine(point1, point2);
            }
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            StartForm load = new StartForm();
            load.Show();
            this.Hide();
        }
        private void AppExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void DrawLine(Cell point1, Cell point2)
        {
            //oh jeez how do i explain this

            //ok so i take the coordinates of point1 and use them to
            //inch towards the coordinates of point2 by using greaterthan,
            //lessthan, and equalto comparators

            //every time the "pointer" makes a move towards point 2
            //set the image at that position to the highlighter color
            //which is just a neon variant of the same chip color

            Image yellowHighlight = Image.FromFile(@"../../Resources/YellowHighlight.png");
            Image redHighlight = Image.FromFile(@"../../Resources/RedHighlight.png");

            Image highlighter = redHighlight;
            //im just setting this as redHighlight upon initialize to be easy
            if (winner == 1)
            {
                highlighter = redHighlight;
            }
            else
            {
                highlighter = yellowHighlight;
            }
            int pointerX = point1.GetX();
            int pointerY = point1.GetY();

            Debug.WriteLine("highlighting [ " + pointerX + ", " + pointerY + " ]");
            board[pointerX, pointerY].Image = highlighter;

            Debug.WriteLine("pointer: " + pointerX + ", " + pointerY);
            Debug.WriteLine("point2 : " + point2.GetX() + ", " + point2.GetY());
            Debug.WriteLine("moving to point 2: " + point2.GetX() + ", " + point2.GetY());


            while (point2.GetX() != pointerX || point2.GetY() != pointerY)
            {

                //using a single if-statement with a bunch of else-if's
                //to prevent the loop from moving more than once per iteration
                //it should automatically stop after highlighting point2
                if (pointerX == point2.GetX() && pointerY < point2.GetY())
                {
                    //going down
                    pointerY++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX < point2.GetX() && pointerY > point2.GetY())
                {
                    //going down-right
                    pointerX--;
                    pointerY++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX < point2.GetX() && pointerY == point2.GetY())
                {
                    //going right
                    pointerX++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX < point2.GetX() && pointerY < point2.GetY())
                {
                    //going up-right
                    pointerX++;
                    pointerY++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX == point2.GetX() && pointerY < point2.GetY())
                {
                    //going up
                    pointerY++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX > point2.GetX() && pointerY < point2.GetY())
                {
                    //going up-left
                    pointerX--;
                    pointerY++;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX > point2.GetX() && pointerY == point2.GetY())
                {
                    //going left
                    pointerX--;
                    board[pointerX, pointerY].Image = highlighter;
                }
                else if (pointerX > point2.GetX() && pointerY > point2.GetY())
                {
                    //going down-left
                    pointerX--;
                    pointerY--;
                    board[pointerX, pointerY].Image = highlighter;
                }
                Debug.WriteLine("highlighted [ " + pointerX + ", " + pointerY + " ]");

            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //restart the game depending on which mode they were playing in
            if (isPVP)
            {
                new PvPForm().Show();
            }
            else
            {

                new PvEForm().Show();

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the game after either red or yellow wins
            Application.Exit();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            //show stats after games over 
            StatsForm stats = new StatsForm();
            stats.ShowDialog();
            //stats.Show();
            //this.Close();
        }
    }
}
