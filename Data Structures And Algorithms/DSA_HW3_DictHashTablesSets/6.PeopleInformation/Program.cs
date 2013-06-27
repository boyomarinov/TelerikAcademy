using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.PeopleInformation
{
    public static class Program
    {
        public static void Main()
        {
            PhoneBook book = new PhoneBook();
            //book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123456"));
            //book.AddContact(new Contact("Jorko Barborko", "Dupnica", "088123458"));
            //book.AddContact(new Contact("Jorko Barborko", "Sofia", "088123456"));

            //List<Contact> matched = book.Find("Jorko Barborko");
            //List<Contact> matchedByBoth = book.Find("Jorko Barborko", "Dupnica");

            book.Parse("../../input.txt");

            Console.WriteLine(book.ToString());
            
        }
    }
}
