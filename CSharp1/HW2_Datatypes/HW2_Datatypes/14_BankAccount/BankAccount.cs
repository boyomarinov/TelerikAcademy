using System;

class BankAccount
{
    static void Main()
    {
        string firstName;
        string lastName;
        decimal accountBalance;
        string bankName;
        string IBAN;
        string[] creditCards = new string[3];

        firstName = "Pesho";
        lastName = "Petrov";
        accountBalance = 1234567.89M;
        bankName = "Shans Bank";
        IBAN = "LU28 0019 4006 4475 0000";// offshore account in Luxembourg : )
        creditCards[0] = "4222222222222"; // VISA example
        creditCards[1] = "5610591081018250"; // Australian BankCard example
        creditCards[2] = "371449635398431"; // American Express example

        Console.WriteLine("Personal Account Information");
        Console.WriteLine();
        Console.WriteLine("Name: {0} {1}", firstName, lastName);
        Console.WriteLine("Current account balance: {0}", accountBalance);
        Console.WriteLine("Account in bank: {0}", bankName);
        Console.WriteLine("IBAN: {0}", IBAN);
        Console.WriteLine("Credit card numbers:");
        for (byte i = 0; i < 3; i++)
        {
            Console.WriteLine("Account {0}: {1}", i+1, creditCards[i]);
        }
        Console.WriteLine();
    }
}

