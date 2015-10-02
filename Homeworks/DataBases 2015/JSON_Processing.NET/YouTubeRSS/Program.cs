namespace YouTubeRSS
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class Program
    {
        internal static void Main()
        {
            string pathToFile = "../../RSSNews.xml";

            // to not open network connection
            if (!File.Exists(pathToFile))
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw", pathToFile);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathToFile);

            string result = JsonConvert.SerializeObject(xmlDocument, Newtonsoft.Json.Formatting.Indented);

            //Console.WriteLine(result);

            /* till now OK */

            JObject json = JObject.Parse(result);
            //Console.WriteLine(json["feed"]["entry"]);

            int index = 1;

            IEnumerable<string> titles = json["feed"]["entry"].Select(
                entry => String.Format("Title #{0}: {1}", index++, entry["title"]));

            Console.OutputEncoding = Encoding.Unicode;
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
            
        }
    }
}
