/*Problem 12. Parse URL

    Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.

Example: 
 -http://telerikacademy.com/Courses/Courses/Details/212 
 [protocol] = http
[server] = telerikacademy.com
[resource] = /Courses/Courses/Details/212
 */
using System;
using System.Diagnostics;

class Url
{
    static void Main()
    {
        Console.Write("Input url: ");
        string s = Console.ReadLine();
        int twoDots = s.IndexOf(":");
        ErrorInput(twoDots);
        string protokol = s.Substring(0, twoDots); // take protocol
        int slashSlash = s.IndexOf("//");
        ErrorInput(slashSlash);
        slashSlash+=2;
        int onlySlash = s.IndexOf("/" , slashSlash );
        ErrorInput(onlySlash);
        string server = s.Substring(slashSlash , onlySlash - slashSlash);  // take server
        string resource = s.Substring(onlySlash + 1);   // take rest
        Console.WriteLine("[protocol] = {0}\n[server] = {1}\n[resourse] = {2}", protokol, server , resource);

        Console.WriteLine("Opening browser...");
        try
        {

         Process.Start(s);  // Watch out ... this code sentence opens your link in browser
        }
        catch(System.ComponentModel.Win32Exception)
        {
            Console.WriteLine("Try not break program");
            Console.ReadLine();
            Console.Clear();
            Main();
        }
    }
    static void ErrorInput(int a)
    {
        if(a < 0)
        {
            Console.WriteLine("Invalid Url! ");
            Console.ReadLine();
            Console.Clear();
            Main();
        }
    }
}