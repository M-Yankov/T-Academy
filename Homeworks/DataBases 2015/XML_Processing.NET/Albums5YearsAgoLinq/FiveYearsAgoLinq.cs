namespace Albums5YearsAgoLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Task 12: Rewrite the previous(task 11) using LINQ query.
    /// </summary>
    public class FiveYearsAgoLinq
    {
        internal static void Main()
        {
            int currentYear = DateTime.Now.Year;
            int yearsLongAgo = 5;

            XDocument xmlCatalogue = XDocument.Load("../../../catalogue.xml");
            var albums =
                from album in xmlCatalogue.Descendants("album")
                where currentYear > int.Parse(album.Element("year").Value) + yearsLongAgo
                select new XElement("album",
                    new XElement("name", album.Element("name").Value),
                    new XElement("price", album.Element("price").Value),
                    new XElement("year", album.Element("year").Value));

            XDocument fiveYearsAgoAlbums = new XDocument(new XElement("albums", albums));
            fiveYearsAgoAlbums.Save("../../oldAlbumsLinq.xml");
            Console.WriteLine("See result in oldAlbumsLinq.xml");
        }
    }
}
