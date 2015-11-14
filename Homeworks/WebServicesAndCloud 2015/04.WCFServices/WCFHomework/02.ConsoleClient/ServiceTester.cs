namespace ConsoleClient
{
    using System;
    using DayOfWeekServiceReference;

    /// <summary>
    /// Task 2. Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
    /// </summary>
    public class ServiceTester
    {
        public static void Main()
        {
            DayOfWeekServiceClient a = new DayOfWeekServiceClient();
            string result = a.DayOfWeekInBulgarianAsync(DateTime.Now).Result;
            Console.WriteLine(result);
        }
    }
}
