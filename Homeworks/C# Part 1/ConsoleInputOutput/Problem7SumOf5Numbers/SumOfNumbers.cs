/*Problem 7. Sum of 5 Numbers

    Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

 */

using System;
using System.Globalization;
using System.Linq;
using System.Threading;


class SumOfNumbers
{
    static void Main()
    {
        char[] charsToTrim = {' '};
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Enter numbers separated by a space in a single line: ");
        string number = Console.ReadLine().TrimEnd(charsToTrim);  // :@  If you enter a spaces after last number this method deletes it. 
        
        //Console.WriteLine(number + ".");
        //number = "1 2 3 4 5";

        string[] splited = number.Split(new Char[] { ' ' }); // I saw this from here http://msdn.microsoft.com/en-us/library/b873y76a%28v=vs.110%29.aspx
        // it makes a array with substring. new substring makes after specific character in {}. In this case is {' '}
        double sum = 0;
        int i = 0;
        foreach (string s in splited) // a new loop called foreach
            // it use some variable (in this case: s) to take tour around each substring in this array 
        {
            i++;
            if (s.Trim(charsToTrim) != "") // Trim method deletes white spaces (intervals) before and after subtring 
            {
                
                if (i == splited.Count()) // if it's last substring in array --> http://stackoverflow.com/questions/7476174/foreach-loop-determine-which-is-the-last-iteration-of-the-loop
                {
                    Console.Write(s + " = "); // prints 's' and adds a sigh equal "=" 
                    sum += double.Parse(s);
                }
                else
                {
                    Console.Write(s + " + ");
                    sum += double.Parse(s);
                }
            }
        }
        Console.WriteLine(" " + sum);
    }
}
