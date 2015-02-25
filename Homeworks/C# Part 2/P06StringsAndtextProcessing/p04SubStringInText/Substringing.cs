/*Problem 4. Sub-string in text

    Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

Example:

The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The result is: 9*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Substringing
{
    static void Main()
    {
        Console.Write("Enter some text: ");
        string s = Console.ReadLine();
        Console.Write("Search for substring: ");
        string search = Console.ReadLine();
        int counter = 0;
        int index = 0;
        while (s.IndexOf(search, index) != -1)
        {

            counter++;
            index = s.IndexOf(search, index) + 1;
        }
        Console.WriteLine(@"'{0}' appears {1} times.", search, counter);
    }
}
