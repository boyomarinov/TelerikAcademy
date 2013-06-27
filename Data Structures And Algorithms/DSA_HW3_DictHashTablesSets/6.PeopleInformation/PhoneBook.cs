using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _6.PeopleInformation
{
    public class PhoneBook
    {
        //private HashSet<Contact> contacts;
        MultiDictionary<string, Contact> contactsByName;
        MultiDictionary<Tuple<string, string>, Contact> contactsByNameAndTown;

        public PhoneBook()
        {
            this.contactsByName = new MultiDictionary<string, Contact>(true);
            this.contactsByNameAndTown = new MultiDictionary<Tuple<string, string>, Contact>(true);
        }

        public int Count
        {
            get
            {
                return this.contactsByName.KeyValuePairs.Count;
            }
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("Contact is empty!");
            }

            this.contactsByName.Add(contact.Name, contact);
            Tuple<string, string> nameAndTown = new Tuple<string, string>(contact.Name, contact.Town);
            this.contactsByNameAndTown.Add(nameAndTown, contact);

            Debug.Assert(this.contactsByName.KeyValuePairs.Count == this.contactsByNameAndTown.KeyValuePairs.Count);
        }

        public bool RemoveContact(Contact contact)
        {
            if (!contactsByName.Contains(contact.Name, contact))
            {
                throw new ArgumentException("Phone book does not contain such contact.");
            }

            Contact removedContact = contact;
            bool byName = this.contactsByName.Remove(contact.Name, contact);

            Tuple<string, string> nameAndTown = new Tuple<string, string>(contact.Name, contact.Town);
            bool byNameAndTown = this.contactsByNameAndTown.Remove(nameAndTown, contact);

            Debug.Assert(byName == byNameAndTown);

            return byName && byNameAndTown;
        }

        public List<Contact> Find(string name)
        {
            List<Contact> result = new List<Contact>();
            result.AddRange(this.contactsByName[name]);

            return result;
        }

        public List<Contact> Find(string name, string town)
        {
            Tuple<string, string> nameAndTown = new Tuple<string, string>(name, town);
            var matchesByNameAndTown = this.contactsByNameAndTown[nameAndTown];

            return matchesByNameAndTown.ToList();
        }

        public void Parse(string path)
        {
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] parsedData = line.Split('|');

                    string name = parsedData[0].Trim();
                    string town = parsedData[1].Trim();
                    string phone = parsedData[2].Trim();

                    Contact toBeAdded = new Contact(name, town, phone);
                    this.AddContact(toBeAdded);

                    line = reader.ReadLine();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Phone Book:");
            foreach (var contact in this.contactsByName.Values)
            {
                sb.AppendLine(contact.ToString());
            }

            return sb.ToString();
        }
    }
}