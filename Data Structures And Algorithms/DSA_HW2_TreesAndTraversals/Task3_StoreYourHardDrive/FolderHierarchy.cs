using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_StoreYourHardDrive
{
    public class FolderHierarchy
    {
        private Folder root;

        public Folder Root
        {
            get
            {
                return this.root;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root cannot be null!");
                }

                this.root = value;
            }
        }

        public FolderHierarchy(Folder root)
        {
            this.Root = PopulateFileTree(root);
        }

        private Folder PopulateFileTree(Folder root)
        {
            string[] files = Directory.GetFiles(root.Name);
            IEnumerable<string> folders = Directory.EnumerateDirectories(root.Name);

            AddFilesToFolder(root, files);
            AddSubfoldersToFolder(root, folders);

            for (int i = 0; i < root.ChildFoldersCount; i++)
            {
                try
                {
                    root.ChildFolders[i] = PopulateFileTree(root.GetChildFolderAtIndex(i));
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("{0} cannot be accessed!", root.GetChildFolderAtIndex(i));
                }
            }

            return root;
        }

        private void AddSubfoldersToFolder(Folder root, IEnumerable<string> folders)
        {
            List<Folder> subfolders = new List<Folder>();
            foreach (var folder in folders)
            {
                Folder currentFolder = new Folder(folder);
                subfolders.Add(currentFolder);
            }

            root.ChildFolders = subfolders.ToArray();
        }

        private void AddFilesToFolder(Folder root, string[] files)
        {
            List<File> currentDirectoryFiles = new List<File>();

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                long size = info.Length;
                File currentFile = new File(file.ToString(), size);
                currentDirectoryFiles.Add(currentFile);
            }

            root.Files = currentDirectoryFiles.ToArray();
        }

        public long CalculateWholeTreeSize()
        {
            long sum = 0;
            CalculateFolderSize(this.Root, ref sum);

            return sum;
        }

        public void CalculateFolderSize(Folder folder, ref long sum)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("Folder cannot be null!");
            }

            for (int i = 0; i < folder.Files.Length; i++)
            {
                if (folder.Files[i] != null)
                {
                    sum += folder.Files[i].Size;
                }
            }

            for (int i = 0; i < folder.ChildFoldersCount; i++)
            {
                Folder currentFolder = folder.GetChildFolderAtIndex(i);
                CalculateFolderSize(currentFolder, ref sum);
            }
        }

        private Folder FindFolder(Folder start, string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path cannot be null");
            }

            if (start.Name == path)
            {
                return start;
            }

            for (int i = 0; i < start.ChildFoldersCount; i++)
            {
                Folder currentFolder = start.GetChildFolderAtIndex(i);
                FindFolder(currentFolder, path);
            }

            throw new ArgumentException("Folder not found in tree hierarchy!");
        }
    }
}
