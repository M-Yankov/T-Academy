
namespace TransformCatalogueToHTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Xsl;

    /// <summary>
    ///  Task 13: Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
    /// </summary>
    class Transformer
    {
        static void Main()
        {
            XslCompiledTransform transformator = new XslCompiledTransform();
            transformator.Load("../../../styleXSLT.xslt");
            transformator.Transform("../../../catalogue.xml", "../../catalogue.html");
            Console.WriteLine("HTML is ready... find catalogue.html in solution folder");
        }
    }
}
