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

    /// <summary>
    /// • Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:
    ///     
    ///     i. The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
    ///    ii. Download the content of the feed programatically 
    ///             ■ You can use WebClient.DownloadFile()
    ///   iii. Parse teh XML from the feed to JSON
    ///    iv. Using LINQ-to-JSON select all the video titles and print the on the console 
    ///     v. Parse the videos' JSON to POCO
    ///    vi. Using the POCOs create a HTML page that shows all videos from the RSS 
    ///             ■ Use <iframe>
    ///             ■ Provide a links, that nagivate to their videos in YouTube
    /// </summary>
    public class Program
    {
        internal static void Main()
        {
            string pathToFile = "../../RSSNews.xml";

            // do not waste time of downloading
            if (!File.Exists(pathToFile))
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw", pathToFile);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathToFile);

            string result = JsonConvert.SerializeObject(xmlDocument, Newtonsoft.Json.Formatting.Indented);

            JObject json = JObject.Parse(result);

            PrintRSSTitleVideos(json);
            HtmlBuilder(json);

            Console.WriteLine("see result html verySlowLoading.hmtl");
        }

        private static void PrintRSSTitleVideos(JObject json)
        {
            int index = 1;
            IEnumerable<string> titles = json["feed"]["entry"].Select(
                entry => string.Format("Title #{0}: {1}", index++, entry["title"]));

            Console.OutputEncoding = Encoding.Unicode;
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }
 
        private static void HtmlBuilder(JObject json)
        {
            IList<Entry> entries = new List<Entry>();

            foreach (JObject item in json["feed"]["entry"])
            {
                entries.Add(JsonConvert.DeserializeObject<Entry>(item.ToString()));
            }

            XmlWriterSettings settignsWriter = new XmlWriterSettings();
            settignsWriter.Indent = true;
            settignsWriter.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlTextWriter.Create("../../verySlowLoafingRSS.html", settignsWriter))
            {
                writer.WriteDocType("HTML5", null, null, null);

                writer.WriteStartElement("html");

                /* head */
                writer.WriteStartElement("head");

                writer.WriteStartElement("style");
                writer.WriteAttributeString("type", "text/css");
                writer.WriteValue(@"
        body {
        	font: Arial;
        	}
        	
        iframe {
            witdh: 250px;
            height: 175px; 
        }
        
        .container {
            display: inline-block;
            margin: 10px;
            width: 300px;
            height: 250px;
            overflow: auto;
        }
        
        .container h3 {
            text-align:center;
            font-size: 15px;
        }
        
        .container h3 a {
            text-decoration: none;
        }
        
        .container h3 a:hover {
            text-decoration: underline;
        }
");
                writer.WriteEndElement();
                writer.WriteStartElement("title");
                writer.WriteValue("RSS Youtube Channel - Telrik Academy");
                writer.WriteEndElement();
                writer.WriteEndElement();
                /* end head */

                /* body */
                writer.WriteStartElement("body");
                writer.WriteStartElement("main");

                foreach (Entry entry in entries)
                {
                    writer.WriteStartElement("div");
                    writer.WriteAttributeString("class", "container");

                    writer.WriteStartElement("iframe");
                    writer.WriteAttributeString("src", entry.VideoLink.Href);
                    writer.WriteAttributeString("frameborder", "0");
                    writer.WriteAttributeString("allowfullscreen", "allowfullscreen");
                    writer.WriteValue(string.Empty);
                    writer.WriteEndElement();

                    writer.WriteStartElement("h3");
                    writer.WriteStartElement("a");
                    writer.WriteAttributeString("href", entry.VideoLink.Href);
                    writer.WriteValue(entry.Title);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                /* end body */

                writer.WriteEndElement();
            }
        }
    }
}
