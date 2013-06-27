using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14_Labyrinth
{
    class Coordinate
    {
        private int row;
        private int col;

        public Coordinate(int row = 0, int col = 0)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

    }
}
