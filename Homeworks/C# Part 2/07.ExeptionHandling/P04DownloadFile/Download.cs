/*Problem 4. Download file

    Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
    Find in Google how to download files in C#.
    Be sure to catch all exceptions and to free any used resources in the finally block.
*/
using System;

using System.Text;
using System.Net;


class Download
{
    static void Main()
    {
        WebClient Client = new WebClient();
        try
        {
            
            Client.DownloadFile("http://telerikacademy.com/Content/Images/news-img01.png", "..//..//image.png");
            Console.WriteLine("Image was successfully downloaded.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("String can't be empty!");
        }
        catch(WebException)
        {
            Console.WriteLine("Problem while accessing URL address!");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("Not suupported");
        }
        finally
        {
            GC.Collect(); // Carbage Collector Collects the rubish
            Console.WriteLine("Memory was cleared");
        }

    }
}
