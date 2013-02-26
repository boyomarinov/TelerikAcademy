using System;

namespace _1_Point3D
{
    //Structure to hold 3D-coordinate in 3D Euclidian space
    struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        //Field to hold the start of our Euclidian 3D space
        private static readonly Point3D start;
        public Point3D Start
        {
            get { return start; }
        }

        //custom ToString() method to print a 3D point
        public override string ToString()
        {
            return "{ " + X +  ", " + Y + ", " + Z + " }" ;
        }
    }


}
