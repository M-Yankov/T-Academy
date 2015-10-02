namespace DeleteAlbums
{
    using System;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Task 4
    ///  Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
    /// </summary>
    public class Deleter
    {
        internal static void Main()
        {
            const int MinPrice = 20;
            XmlDocument xmlCatalogs = new XmlDocument();
            xmlCatalogs.Load("../../../catalogue.xml");
            XmlNodeList albums = xmlCatalogs.ChildNodes[1].ChildNodes[0].ChildNodes;

            for (int i = 0; i < albums.Count; i++)
            {
                XmlNode currentAlbum = albums[i];
                int priceAlbum = int.Parse(currentAlbum["price"].InnerXml);
                if (priceAlbum < MinPrice)
                {
                    XmlNode parent = currentAlbum.ParentNode;
                    parent.RemoveChild(currentAlbum);
                    i--;
                }
            }

            xmlCatalogs.Save("../../filteredAlbums.xml");
            Console.WriteLine("You can view results in filteredAlbums.xml");
        }
    }
}
