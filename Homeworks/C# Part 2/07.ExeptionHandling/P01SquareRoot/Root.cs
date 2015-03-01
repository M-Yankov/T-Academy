/*Problem 1. Square root

    Write a program that reads an integer number and calculates and prints its square root.
        If the number is invalid or negative, print Invalid number.
        In all cases finally print Good bye.
    Use try-catch-finally block.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;


class Root
{
    public static string mess = "Invalid number";
    public static double Sqrt(double value)
    {
        if (value < 0)
        { 
            throw new ArgumentOutOfRangeException("",mess);
        }
        return Math.Sqrt(value);
    }
    static void Main()
    {
        Console.Write("Enter a number: ");
        try
        {

            Console.WriteLine(Sqrt(double.Parse(Console.ReadLine()))); ;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message); 
            
        }
        catch(FormatException)
        {
            Console.WriteLine(mess);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
