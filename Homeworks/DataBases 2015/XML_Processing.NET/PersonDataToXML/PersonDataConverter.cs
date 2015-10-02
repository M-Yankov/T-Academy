namespace PersonDataToXML
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Task 7: In a text file we are given the name, address and phone number of given person (each at a single line).
    ///     ○ Write a program, which creates new XML document, which contains these data in structured XML format.
    /// </summary>
    public class PersonDataConverter
    {
        internal static void Main()
        {
            StreamReader textReader = new StreamReader("../../Person.txt");
            XmlDocument xmlDocument = new XmlDocument();

            XmlNode persons = xmlDocument.CreateNode(XmlNodeType.Element, "persons", string.Empty);

            using (textReader)
            {
                while (!textReader.EndOfStream)
                {
                    XmlNode person = xmlDocument.CreateNode(XmlNodeType.Element, "person", string.Empty);
                    XmlNode personName = xmlDocument.CreateNode(XmlNodeType.Element, "name", string.Empty);
                    XmlNode personAddres = xmlDocument.CreateNode(XmlNodeType.Element, "address", string.Empty);
                    XmlNode personPhone = xmlDocument.CreateNode(XmlNodeType.Element, "phone", string.Empty);
                    
                    personName.InnerText = textReader.ReadLine();
                    personPhone.InnerText = textReader.ReadLine();
                    personAddres.InnerText = textReader.ReadLine();

                    person.AppendChild(personName);
                    person.AppendChild(personAddres);
                    person.AppendChild(personPhone);

                    persons.AppendChild(person);
                }
            }

            xmlDocument.AppendChild(persons);
            xmlDocument.Save("../../saved.xml");
            Console.WriteLine("See results in saved.xml");
        }
    }
}
