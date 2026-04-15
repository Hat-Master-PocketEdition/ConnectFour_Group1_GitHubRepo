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
        private int[,] coords;

        public Cell()
        {
            //default constructor should never be invoked
            //loading it with recognisable dummy data
            //that can be easily spotted.
            value = "icosahedron";
            coords = new int[ 99, 99 ];
        }
        public Cell(string value, int x, int y)
        {
            this.value = value;
            this.coords = new int[ x, y ];
        }


        //Getters + Setters
        public string GetValue()
        {
            return value;
        }
        public int[,] GetCoords()
        {
            return coords;
        }
        public void SetValue(string value)
        {
            this.value = value;
        }
        public void SetCoords(int x, int y)
        {
            this.coords = new int[x, y];
        }

    }
}
