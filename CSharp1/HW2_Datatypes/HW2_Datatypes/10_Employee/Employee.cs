using System;

class Employee
{
    static void Main()
    {
        string firstName, lastName, personalID;
        ushort employeeID;
        byte age;
        char gender;

        firstName = "Pesho";
        lastName = "Petrov";
        personalID = "9001011234";
        employeeID = 123; //27560000 + employeeID
        age = 22;
        gender = 'm';

        Console.WriteLine("Employee's info:");
        Console.WriteLine();
        Console.WriteLine("First name: {0}", firstName);
        Console.WriteLine("Last name: {0}", lastName);
        Console.WriteLine("Personal ID: {0}", personalID);
        Console.WriteLine("Employee ID: {0}", employeeID + 27560000);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Gender: {0}", gender);
    }
}

