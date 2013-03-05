using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Shapes
{
    abstract class Shape
    {
        private int width;
        private int height;

        public Shape(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        #region Properties
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        #endregion

        public abstract double CalculateSurface();

    }
}
