namespace AllSongs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Task 5: Write a program, which using XmlReader extracts all song titles from catalog.xml.
    /// Task 6: Rewrite the same using XDocument and LINQ query.
    /// </summary>
    public class SongExtacter
    {
        private static readonly string TitleTaks = new string('*', 8) + " {0} " + new string('*', 8);

        internal static void Main()
        {
            Console.WriteLine(string.Format(TitleTaks, "Task 5 XML Reader"));
            ExtractAllSongsWithXMLReader();

            Console.WriteLine(string.Format(TitleTaks, "Task 6 XDocument"));
            XDocumentDemo();
        }

        private static void XDocumentDemo()
        {
            XDocument xmlCatalogue = XDocument.Load("../../../catalogue.xml");

            IEnumerable<XElement> nodeElements = xmlCatalogue.Descendants("title");

            int songCounter = 1;
            foreach (XElement node in nodeElements)
            {
                Console.WriteLine(string.Format("#{0}.{1}", songCounter, node.Value));
                songCounter++;
            }

            /************* Second way With LINQ ***********/
            /*
            var songTitles =
                from song in xmlCatalogue.Descendants("title")
                select song.Value;

            songCounter = 1;
            foreach (string songTitle in songTitles)
            {
                Console.WriteLine(string.Format("{0}.{1}", songCounter, songTitle));
                songCounter++;
            }
            */
        }

        private static void ExtractAllSongsWithXMLReader()
        {
            using (XmlReader albumReader = XmlReader.Create("../../../catalogue.xml"))
            {
                int songNumber = 1;
                while (albumReader.Read())
                {
                    if (albumReader.NodeType == XmlNodeType.Element && albumReader.Name == "title")
                    {
                        Console.WriteLine(string.Format("#{0}.{1}", songNumber, albumReader.ReadInnerXml()));
                        songNumber++;
                    }
                }
            }
        }
    }
}
