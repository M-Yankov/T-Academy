namespace Catalogue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Task 1: Create a XML file representing catalogue.
    ///     ○ The catalogue should contain albums of different artists.
    ///     ○ For each album you should define: name, artist, year, producer, price and a list of songs.
    ///     ○ Each song should be described by title and duration.
    /// Task 2: Write program that extracts all different artists which are found in the catalog.xml. 
    ///     ○ For each author you should print the number of albums in the catalogue.
    ///     ○ Use the DOM parser and a hash-table.
    /// Task 3: Implement the previous using XPath.
    /// </summary>
    public class ProcessXml
    {
        public static void Main()
        {
            ParseXmlDocument();
        }

        private static void ParseXmlDocument()
        {
            string stars = new string('*', 10) + " {0} " + new string('*', 10);

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            XmlNode root = doc.DocumentElement;
            XmlNode albums = root["albums"];
            
            /* DOMParser */
            Console.WriteLine(string.Format(stars, "DOM Parser"));
            Hashtable tableFromDomParser = new Hashtable();

            tableFromDomParser = CountAlbumOfArtists(albums.ChildNodes);
            PrintArtistsWithAlbums(tableFromDomParser);

            /* XPath */
            Console.WriteLine(string.Format(stars, "XPpath"));
            Hashtable tableFromXpath = new Hashtable();
            string query = "album";

            XmlNodeList list = albums.SelectNodes(query);

            tableFromXpath = CountAlbumOfArtists(list);
            PrintArtistsWithAlbums(tableFromXpath);
        }

        private static Hashtable CountAlbumOfArtists(XmlNodeList listOfNodes)
        {
            Hashtable table = new Hashtable();

            foreach (XmlNode node in listOfNodes)
            {
                string currentArtist = node["artist"].InnerText;
                if (table.ContainsKey(currentArtist))
                {
                    int value = (int)table[currentArtist];
                    table[currentArtist] = value + 1;
                }
                else
                {
                    table.Add(node["artist"].InnerText, 1);
                }
            }

            return table;
        }

        private static void PrintArtistsWithAlbums(Hashtable artists)
        {
            foreach (DictionaryEntry item in artists)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
