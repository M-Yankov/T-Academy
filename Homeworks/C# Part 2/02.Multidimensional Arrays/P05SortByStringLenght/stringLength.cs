/*Problem 5. Sort by string length

    You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringLength
{
    static void Main()
    {
        List<string> textStrings = new List<string>();
        textStrings.Add("Ivan");
        textStrings.Add("Georgi_Traktora");
        textStrings.Add("Pi");
        textStrings.Add("Strahil"); // You can add many more strings here
        var result = textStrings.OrderBy(x => x.Length); // Lambda expresion . I wrote this code for 3 mins :)
        Console.WriteLine("Sorting...");
        foreach (var i in result)
        {
            Console.WriteLine(i);
        }
    }
}