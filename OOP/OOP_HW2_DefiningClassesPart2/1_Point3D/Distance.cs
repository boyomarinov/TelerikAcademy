using System;


namespace _1_Point3D
{
    //Class to calculate distance betwwen to points in 3D
    static class Distance
    {
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            double dx = Math.Abs(first.X - second.X);
            double dy = Math.Abs(first.Y - second.Y);
            double dz = Math.Abs(first.Z - second.Z);
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
