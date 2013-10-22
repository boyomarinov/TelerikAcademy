using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using CountSubstringLibrary;

namespace CountSubstringClient
{
    public static class Program
    {
        public static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:1234/count");
            ServiceHost selfHost = new ServiceHost(typeof(CountSubstring), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                Console.WriteLine("The service is started at endpoint " + serviceAddress);

                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
