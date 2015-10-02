
namespace TransformStyleSheet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Xsl;

    /// <summary>
    /// Task 14: Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
    /// </summary>
    public class SheetTransformer
    {
        internal static void Main()
        {
            /* this is deprecated, but only for homework purposes */
            XslTransform sheetTransrormer = new XslTransform();
            sheetTransrormer.Load("../../../styleXSLT.xslt");
            sheetTransrormer.Transform("../../../catalogue.xml", "../../transformedCatalogue.html");
            Console.WriteLine("Result is in folder solution.");

            /*I leave on you to find difference with last task...*/
        }
    }
}
