using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group1
{
    //Cell is a subclass of PictureBox
    //This allows us to store more data

    //AW
    internal class Cell : PictureBox
    {
        private string value;

        //originally i tried to save this as a 2d array
        //but it caused more issues than i thought it would
        private int x;
        private int y;

        public Cell()
        {
            //default constructor should never be invoked
            //loading it with recognisable dummy data
            //that can be easily spotted.
            value = "icosahedron";
            x = 99;
            y = 99;
            //coords = new int[ 99, 99 ];
        }
        public Cell(string value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
            //this.coords = new int[ x, y ];
        }


        //Getters + Setters
        public string GetValue()
        {
            return value;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetValue(string value)
        {
            this.value = value;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }

    }
}
