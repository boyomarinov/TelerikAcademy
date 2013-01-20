using System;

class CompanyManager
{
    static void Main()
    {
        string name, address, phoneNumber, faxNumber, website;
        string firstName, lastName, age, managerPhone;

        Console.Write("Company name: ");
        name = Console.ReadLine();
        Console.Write("Company address: ");
        address = Console.ReadLine();
        Console.Write("Company phone number: ");
        phoneNumber = Console.ReadLine();
        Console.Write("Company fax number: ");
        faxNumber = Console.ReadLine();
        Console.Write("Company website: ");
        website = Console.ReadLine();
        Console.Write("Manager's first name: ");
        firstName = Console.ReadLine();
        Console.Write("Manager's last name: ");
        lastName = Console.ReadLine();
        Console.Write("Manager's age: ");
        age = Console.ReadLine();
        Console.Write("Manager's phone: ");
        managerPhone = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Company");
        Console.WriteLine("Name: {0}", name);
        Console.WriteLine("Address: {0}", address);
        Console.WriteLine("Phone number: {0}", phoneNumber);
        Console.WriteLine("Fax number: {0}", faxNumber);
        Console.WriteLine("Website: {0}", website);
        Console.WriteLine();
        Console.WriteLine("Manager");
        Console.WriteLine("First Name: {0}", firstName);
        Console.WriteLine("Last Name: {0}", lastName);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Phone Number: {0}", phoneNumber);
    }
}
