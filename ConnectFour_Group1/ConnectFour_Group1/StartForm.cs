namespace ConnectFour_Group1
{
    public partial class StartForm : Form
    {

        int[,] gameBoard = new int[7, 6];
        //Comment Board for Form 1 Start - DS
        //I will sign off my Comment Blocks with my initials
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
            //if-chain to inspect btn sender
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
