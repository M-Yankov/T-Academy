namespace Directories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Task 9: Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. 
    ///     ○ Use tags <file> and <dir> with appropriate attributes.
    ///     ○ For the generation of the XML document use the class XmlWriter.
    /// Task 10:  Rewrite the last exercises using XDocument, XElement and XAttribute.
    /// 
    /// Some code is get from https://github.com/antoanelenkov/Telerik-Academy-HW/blob/master/DataBases_Homeworks/02.Homewrok.XMLProcessing/09.TraverseDir/Program.cs this colleague.
    /// </summary>
    public class VeryLaggProgram
    {
        /*Replace this field with your path - game, software, something tree like structure.*/
        private const string FavoriteGameLocation = "D:\\Games\\Piercing Blow";

        internal static void Main()
        {
            /* Task 9*/
            StringBuilder consoleText = new StringBuilder();

            using (XmlTextWriter xmlWriter = new XmlTextWriter("../../directoriesAndFiles.xml", Encoding.UTF8))
            {
                xmlWriter.Formatting = Formatting.Indented;

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("game-tree");
                TraverseDirectory(xmlWriter, FavoriteGameLocation, consoleText);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }

            /* Task 10 */
            Console.WriteLine(consoleText.ToString());
            
            XDocument xmlDocument = new XDocument(new XElement("root"));
            TraverseWithXDocument(xmlDocument.Root, FavoriteGameLocation);
            xmlDocument.Save("../../DirectoryAndFilesFromXDocument.xml");
        }

        private static void TraverseDirectory(XmlWriter writer, string path, StringBuilder textToShowinConsole)
        {
            bool inDirectories = true;
            string[] folderDirectories = Directory.GetDirectories(path);

            if (0 == folderDirectories.Length)
            {
                folderDirectories = Directory.GetFiles(path);
                inDirectories = false;
            }

            for (int i = 0; i < folderDirectories.Length; i++)
            {
                textToShowinConsole.AppendLine(folderDirectories[i]);
                if (inDirectories)
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("path", folderDirectories[i]);
                    TraverseDirectory(writer, folderDirectories[i], textToShowinConsole);
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("filename", Path.GetFileName(folderDirectories[i]));
                    writer.WriteEndElement();
                }
            }
        }

        private static void TraverseWithXDocument(XContainer document, string path)
        {
            bool inDirectories = true;
            string[] folderDirectories = Directory.GetDirectories(path);

            if (0 == folderDirectories.Length)
            {
                folderDirectories = Directory.GetFiles(path);
                inDirectories = false;
            }

            for (int i = 0; i < folderDirectories.Length; i++)
            {
                if (inDirectories)
                {
                    XAttribute attribute = new XAttribute("path", folderDirectories[i]);
                    XElement innerNode = new XElement("dir", attribute);
                    TraverseWithXDocument(innerNode, folderDirectories[i]);
                    document.Add(innerNode);
                }
                else
                {
                    XAttribute attribute = new XAttribute("fileName", Path.GetFileName(folderDirectories[i]));
                    XElement innerNode = new XElement("file", attribute);
                    document.Add(innerNode);
                }
            }
        }
    }
}
