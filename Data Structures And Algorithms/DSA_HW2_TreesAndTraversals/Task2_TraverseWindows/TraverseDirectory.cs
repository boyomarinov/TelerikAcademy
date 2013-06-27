using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Task2_TraverseWindows
{
    public static class TraverseDirectory
    {
        public static List<string> FindFilesWithExtension(DirectoryInfo dir, string pattern)
        {
            List<string> files = new List<string>();
            FindFilesWithExtension(dir, pattern, files);

            return files;
        }

        private static void FindFilesWithExtension(DirectoryInfo dir, string pattern, List<string> files)
        {
            if (dir == null)
            {
                return;
            }

            try
            {
                var currentDirectoryFiles = dir.GetFiles(pattern);
                foreach (var file in currentDirectoryFiles)
                {
                    files.Add(file.FullName);
                }

                DirectoryInfo[] subDirectories = dir.GetDirectories();
                foreach (var subdir in subDirectories)
                {
                    FindFilesWithExtension(subdir, pattern, files);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("{0} cannot be accessed!", dir.FullName);
                return;
            }
        }

        public static void Main()
        {
            List<string> winDirExecutables = new List<string>();
            FindFilesWithExtension(new DirectoryInfo("C:\\"), "*.exe", winDirExecutables);


            foreach (var file in winDirExecutables)
            {
                Console.WriteLine(file);
            }
        }
    }
}
