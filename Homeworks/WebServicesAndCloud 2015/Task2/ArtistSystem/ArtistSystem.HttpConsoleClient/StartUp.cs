
namespace ArtistSystem.HttpConsoleClient
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using WebApi.Models;
    using Newtonsoft.Json;
    using System.Text;

    public class StartUp
    {

        public static void Main()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8504/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JsonRequests.ExecuteGetRequests(client);
            JsonRequests.ExecutePostRequests(client);
            Console.WriteLine("Press enter to proceess with updates.");
            // I put this ReadLine because it's async operation
            Console.ReadLine();

            JsonRequests.ExecutePutRequests(client);
            Console.WriteLine("Press enter to proceess with deletes.");
            Console.ReadLine();

            JsonRequests.ExecuteDeleteRequests(client);
            Console.WriteLine("Press enter execute other xml process.");
            Console.ReadLine();

            XmlRequests.ProcessGetCommand(client);
            Console.WriteLine("Press enter execute other xml post.");
            Console.ReadLine();

            XmlRequests.ProcessPostRequests(client);
            Console.WriteLine("Press enter to finish.");
            Console.ReadLine();
        }

    }
}
