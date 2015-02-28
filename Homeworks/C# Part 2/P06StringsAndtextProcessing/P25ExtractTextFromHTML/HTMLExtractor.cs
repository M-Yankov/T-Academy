
/*
    Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

Example input:

<html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skilful .NET software engineers.</p></body>
</html>

Output:

Title: News

Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

class HTMLExtractor
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\input.txt");
        Console.SetIn(reader);
        Console.WriteLine("Enter text below: ");
        using (reader)
        {

            string inputHTML = reader.ReadToEnd();
            //Regex ex = new Regex(@"<[A-Za-z][A-Za-z0-9]*>");
            Regex title = new Regex(@"<title>.+</title>");   // for title 
            Regex body = new Regex(@"<body>.+</body>");    // for body
            Regex aTag = new Regex(@"<a.+?>");     // catch only first path       //<a.+>.+</a> catch whole <a> tag
            Console.WriteLine(inputHTML);

            Match matchtitle = title.Match(inputHTML);
            Match mat = aTag.Match(inputHTML);          // There are more difficults to get some string from several lines .. sometihig like \r\n(w+) must use, but it didn't work

            StringBuilder Stitle = new StringBuilder();
            Stitle.Append(matchtitle);
            Stitle.Replace("<title>", " ");
            Stitle.Replace("</title>", " ");
            Console.WriteLine("Title: {0} " , Stitle);

            Match matbody = body.Match(inputHTML);
            StringBuilder SBody = new StringBuilder();
            SBody.Append(matbody);
            SBody.Replace(mat.ToString(), " ");
            SBody.Replace("<p>", " ");
            SBody.Replace("</p>", " ");
            SBody.Replace("</a>", " ");
            SBody.Replace("<body>", " ");
            SBody.Replace("</body>", " ");


            Console.WriteLine("Text: {0}" , SBody);
        }
    }
}
