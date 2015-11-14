namespace ConsoleClientForOccurances
{
    /// <task>
    /// Task 5. Create a console client for the WCF service above.
    ///      ○ Use the svcutil.exe tool to generate the proxy classes.
    /// </task>
    /// <summary>
    /// To complete this task I used self-host from previous task. While service is running open Developer Command Prompt for VS2013
    /// as administrator. Moved to different directory than C:\Windows\  "cd..". Used "svcutilc http://loclahost:port/service" just the uri 
    /// that is configured. Then I add to project generated files "OccuranceCountingConfig.cs" and merge configuration from "output.config"
    /// to "App.config". Then add references: System.RuntimeSerializaton and System.SerciceModel. 
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            string searchTerm = "is";
            string text = "This is very isolated issue.";

            OccuranceCountingClient client = new OccuranceCountingClient();
            int result = client.Occurances(searchTerm, text);
            System.Console.WriteLine("The text: [{0}]\nContains word [{1}] {2} times", text, searchTerm, result);
            //// OK. the service must running to do this.
        }
    }
}
