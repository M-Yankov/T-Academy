namespace Albums5YearsAgo
{
    using System;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Task 11: Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. 
    ///     ○ Use XPath query.
    /// </summary>
    public class FiveYearsAgo
    {
        internal static void Main()
        {
            int currentYear = DateTime.Now.Year;
            int yearsLongAgo = 5;
            string xPathQuery = "catalogue/albums/album";

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            XmlDocument resultDocument = new XmlDocument();
            resultDocument.AppendChild(resultDocument.CreateNode(XmlNodeType.Element, "albums", string.Empty));

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                if (currentYear > int.Parse(album["year"].InnerXml) + yearsLongAgo)
                {
                    XmlNode newAlbum = resultDocument.CreateNode(XmlNodeType.Element, "album", string.Empty);

                    XmlNode albumName = resultDocument.CreateNode(XmlNodeType.Element, "name", string.Empty);
                    albumName.InnerText = album["name"].InnerXml;

                    XmlNode albumPrice = resultDocument.CreateNode(XmlNodeType.Element, "price", string.Empty);
                    albumPrice.InnerText = album["price"].InnerXml;

                    XmlNode albumYear = resultDocument.CreateNode(XmlNodeType.Element, "year", string.Empty);
                    albumYear.InnerText = album["year"].InnerXml;

                    newAlbum.AppendChild(albumName);
                    newAlbum.AppendChild(albumPrice);
                    newAlbum.AppendChild(albumYear);

                    resultDocument.DocumentElement.AppendChild(newAlbum);
                }
            }

            resultDocument.Save("../../result.xml");
            Console.WriteLine("See results in results.xml");
        }
    }
}
