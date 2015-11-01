namespace ArtistSystem.HttpConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Xml.Linq;
    using WebApi.Models;

    public class XmlRequests
    {
        internal static async void ProcessPostRequests(HttpClient client)
        {
            ResponseAlbumModel album = new ResponseAlbumModel
            {
                Title = "Xml added",
                ProducerName = "Xml Produer",
                Year = 2000
            };

            var httpResponse = await client.PostAsXmlAsync("api/albums", album);
            Console.WriteLine(httpResponse.ReasonPhrase.ToString() + " from albums");
        }

        internal static async void ProcessGetCommand(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            var xmlResponse = await client.GetAsync("api/songs");
            var xmlResult = xmlResponse.Content.ReadAsStringAsync().Result;

            string correct = XDocument.Parse(xmlResult).ToString();
            Console.WriteLine(correct);
        }
    }
}
