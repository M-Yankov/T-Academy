namespace ValidAndInvalidXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;

    public class XMLDocumnetValidator
    {
        internal static void Main()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../correctXML.xml");
            doc.Schemas.Add("urn:catalogueSchema", "../../../catalogueSchema.xsd");


            ValidationEventHandler eventhandler = new ValidationEventHandler(ValidateEventHandler);
            doc.Validate(eventhandler);

            // I Just delete albums element.
            doc.Load("../../../invalidXML.xml");
            doc.Validate(eventhandler);

        }

        static void ValidateEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }
    }
}
