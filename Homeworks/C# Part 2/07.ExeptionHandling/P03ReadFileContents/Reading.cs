/*Problem 3. Read file contents

    Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
    Find in MSDN how to use System.IO.File.ReadAllText(…).
    Be sure to catch all possible exceptions and print user-friendly error messages.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Security;


class Reading
{
    static void CheckNull(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException("", "Path can't be empty of white space");
        }
    }
    static void Main()
    {
        //FileIOPermission access = new FileIOPermission(, @"C:\Intel\Logs");

        //It's dangerous when access windows files
        string text;
        Console.Write("Enter path: ");
        string path = Console.ReadLine();

        try
        {
            CheckNull(path);
            text = File.ReadAllText(path);

            Console.WriteLine("\n\n\n" + text);

        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Bad input string path!");
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("Path length or File name is too long!");
        }
        catch(DirectoryNotFoundException)
        {
            Console.WriteLine("Not such directory!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("This file doesn't exist");
        }
        catch(IOException)
        {
            Console.WriteLine("Error while opening file!"); // C:\Windows\WindowsUpdate.log
        }
        catch(UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have access to operate with this file!");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("Path is invalid or wroong format!");
        }
            
        catch(SecurityException)
        {
            Console.WriteLine("You don't have required permissions");
        }


    }
}
