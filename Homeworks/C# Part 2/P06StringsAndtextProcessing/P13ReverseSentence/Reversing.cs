/*Problem 13. Reverse sentence

    Write a program that reverses the words in given sentence.
 * Example:
 * Input:  C# is not C++, not PHP and not Delphi!
 * Output: Delphi not and PHP, not C++ not is C#!
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Security.Principal;


class Reversing
{
    static void Main()
    {
        Stack<string> sentence = new Stack<string>();
        Console.Write("Enter sentence: ");
        string[] myArray = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
        
        foreach (var item in myArray)
        {
            sentence.Push(item);
        }
        Console.WriteLine(string.Join(" " , sentence));
        Array.Reverse(myArray);
        Console.WriteLine(string.Join(" " , myArray));
        
    }
}
