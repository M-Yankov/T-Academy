namespace AlbumsAndAuthors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Task 8: Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
    /// in which stores in appropriate way the names of all albums and their authors.
    /// </summary>
    public class Program
    {
        internal static void Main()
        {
            IList<string> albums = new List<string>();
            IList<string> artists = new List<string>();

            using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType.ToString() == "Element" && reader.Name == "name")
                    {
                        // name
                        string albumName = reader.ReadInnerXml(); 
                        Console.WriteLine(albumName);
                        albums.Add(albumName);
                    }

                    if (reader.NodeType.ToString() == "Element" && reader.Name == "artist")
                    {
                        // artist
                        string artist = reader.ReadInnerXml();
                        Console.WriteLine(new string(' ', albums.Last().Length - 2) + "╘------->  " + artist + "\n");
                        artists.Add(artist);
                    }
                }
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;

            /* XmlTextReader inherits xmlReader and 
             * XmlTextWriter inherits xmlWriter 
             * :@@@@@@@@@@@@@@@@@@@ kajete po-rano be !*/
            using (XmlTextWriter xmlWriter = new XmlTextWriter("../../albums.xml", Encoding.Unicode))
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.Indentation = 1;
                xmlWriter.IndentChar = '\t';

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("albums");

                /* if (albums.Count() != artists.Count() { //you are fucked up! }*/
                for (int i = 0; i < albums.Count; i++)
                {
                    xmlWriter.WriteStartElement("album");
                    xmlWriter.WriteElementString("name", albums[i]);
                    xmlWriter.WriteElementString("artist", artists[i]);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }
    }
}
