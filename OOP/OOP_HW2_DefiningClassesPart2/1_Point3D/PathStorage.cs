using System;
using System.Collections.Generic;
using System.IO;

namespace _1_Point3D
{
    //Implements functionality to load paths from and SAVE them in text file
    static class PathStorage
    {
        //Method for parsing a line to 3D point
        static Point3D ParseToPoint(string input)
        {
            string[] splited = input.Split('{', '}', ',');

            Point3D result = new Point3D();
            result.X = int.Parse(splited[1]);
            result.Y = int.Parse(splited[2]);
            result.Z = int.Parse(splited[3]);

            return result;
        }

        //Method for reading paths from a file
        static Path LoadPaths(string pathToFile)
        {
            Path path = new Path();
            try
            {
                StreamReader input = new StreamReader(pathToFile);
                using (input)
                {
                    string line = input.ReadLine();
                    while (line != null)
                    {
                        Point3D point = ParseToPoint(line);
                        path.AddPoint(point);
                        line = input.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Loading paths from file completed successfully!");
            return path;
        }

        //Method for saving paths to a file
        static void SavePaths(Path path, string pathToFile)
        {
            StreamWriter writer = new StreamWriter(pathToFile);
            using (writer)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    writer.WriteLine(path[i]);
                }
                writer.WriteLine();
            }
        }

        static void Main()
        {
            //read paths from file
            Path input = LoadPaths(@"../../input.txt");

            //save paths to a file
            SavePaths(input, @"../../output.txt");
        }
    }
}
