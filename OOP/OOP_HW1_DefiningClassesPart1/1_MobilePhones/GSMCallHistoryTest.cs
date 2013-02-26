using System;

class GSMCallHistoryTest
{
    static void Main()
    {
        GSM mobile = new GSM("3310", "Nokia");
        
        //Add some calls
        mobile.AddCallToHistory(new Call(DateTime.Now.AddDays(3), DateTime.Now.TimeOfDay, "0888123123", 120));
        mobile.AddCallToHistory(new Call(DateTime.Now.AddDays(5), DateTime.Now.TimeOfDay, "0888456456", 35));

        //Display call history and total price
        mobile.DisplayCallHistory();
        Console.WriteLine("Total price: {0:F2}", mobile.CalculateTotalPrice(0.37));
        Console.WriteLine();

        //Remove longest call and display total price again
        mobile.RemoveLongestCall();
        Console.WriteLine("Total price: {0:F2}", mobile.CalculateTotalPrice(0.37));
        Console.WriteLine();

        //Clear call history and print it
        mobile.ClearCallHistory();
        mobile.DisplayCallHistory();
    }
}
