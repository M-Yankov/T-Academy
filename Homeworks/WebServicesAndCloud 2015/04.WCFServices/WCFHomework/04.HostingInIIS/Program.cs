namespace HostingInIIS
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using WordOccurance;
    
    /// <summary>
    /// Open containing solution folder and run .exe as Administrator.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            StartHost();
        }

        private static void StartHost()
        {
            string url = "http://localhost:1948/Occurances";

            ServiceHost selfHost = new ServiceHost(typeof(OccuranceService.OccuranceCountingClient), new Uri(url));

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);
            selfHost.Open();

            Console.WriteLine(url);
            Console.ReadLine();
        }
    }
}
