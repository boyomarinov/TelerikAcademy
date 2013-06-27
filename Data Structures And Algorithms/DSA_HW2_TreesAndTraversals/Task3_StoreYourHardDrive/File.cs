using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_StoreYourHardDrive
{
    public class File
    {
        private string name;
        private long size;

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
                    throw new ArgumentNullException("File name cannot be empty!");
                }

                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
