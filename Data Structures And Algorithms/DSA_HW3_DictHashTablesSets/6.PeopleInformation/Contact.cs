using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PeopleInformation
{
    public class Contact
    {
        private string name;
        private string town;
        private string phoneNumber;

        public Contact(string name, string town, string phoneNumber)
        {
            this.Name = name;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be missing!");
                }

                this.name = value;
            }
        }

        public string Town
        {
            get
            {

                return this.town;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Town cannot be missing!");
                }

                this.town = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        public override int GetHashCode()
        {
            return new { x = this.name, y = this.town, z = this.phoneNumber }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (this.GetHashCode() == obj.GetHashCode());
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.Name, this.Town, this.PhoneNumber);
        }
    }
}
