namespace ConnectFour_Group1
{
    public partial class StartForm : Form
    {

        int[,] gameBoard = new int[7, 6];
        //Comment Board for Form 1 Start - DS
        //I will sign off my Comment Blocks with my initials
        //Important we discuss program clocking procedures.
        //Either a Clock-In/Out system in Discord, allowing our group to know where and when.
        //Or, agreed timeframes on when working on the Code.
        //Once procedures are finalize, we can replace this comment, and remove line 10-12 (and others obsoleted).
        //As soon as we reach consensus, it is off to the races with getting this done.
        //====================================================
        //FORM BEAUTY STANDARD
        //====================================================
        //Details for Front-End, form style, font sizes and type. I will ask in the meeting.
        //Name cases for Items (Buttons, Labels, TextBoxes, etc.)
        //====================================================
        //We will need to make the README to gather our work, and make it effective.
        //Any other pieces we can muster for the coding etiquettes for our project.
        //Looking forward to coding together, team. Good luck, good coding.
        //End Comment Block - DS

        //All Forms Traversal (proper allignment, going to/from Forms, and passing data) by AW
        public StartForm()
        {
            InitializeComponent();
        }

        public void DrawBoard()
        {

        }

        private void AppClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //private void btn_GoToPvE_Click(object sender, EventArgs e)
        //{
        //    PvPForm load = new PvPForm();
        //    load.Show();
        //    this.Hide();
        //}

        //private void btn_GoToPvP_Click(object sender, EventArgs e)
        //{
        //    PvEForm load = new PvEForm();
        //    load.Show();
        //    this.Hide();
        //}

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if(sender == btn_GoToPvE)
            {
                PvEForm load = new PvEForm();
                load.Show();
            }
            else if(sender == btn_GoToPvP)
            {
                PvPForm load = new PvPForm();
                load.Show();
            }
            else if(sender == btn_GoToStats)
            {
                StatsForm load = new StatsForm();
                load.Show();
            }
            this.Hide();
        }
    }
}
