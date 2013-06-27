using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_StoreYourHardDrive
{
    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder[] ChildFolders
        {
            get
            {
                return this.childFolders;
            }

            set
            {
                this.childFolders = value;
            }
        }

        public File[] Files
        {
            get
            {
                return this.files;
            }

            set
            {
                this.files = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Folder name cannot be empty!");
                }

                this.name = value;
            }
        }

        public Folder(string name)
        {
            this.Name = name;
            this.files = new File[100];
            this.childFolders = new Folder[100];
        }

        public int ChildFoldersCount
        {
            get
            {
                return this.childFolders.Length;
            }
        }

        public Folder GetChildFolderAtIndex(int index)
        {
            if (index < 0 || index > this.childFolders.Length - 1)
            {
                throw new ArgumentOutOfRangeException("Index is invalid!");
            }

            return this.childFolders[index];
        }
    }
}
