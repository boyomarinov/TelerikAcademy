using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3_StoreYourHardDrive
{
    public static class StoreYourHardDrive
    {
        public static void Main()
        {
            Folder windowsFolder = new Folder(@"../../testfolder");
            FolderHierarchy windowsHierarchy = new FolderHierarchy(windowsFolder);
            long sum = windowsHierarchy.CalculateWholeTreeSize();

            Console.WriteLine("{0} bytes", sum);
            Console.WriteLine("{0:F2} MB", (float)sum / 1024 / 1024);
        }
    }
}
