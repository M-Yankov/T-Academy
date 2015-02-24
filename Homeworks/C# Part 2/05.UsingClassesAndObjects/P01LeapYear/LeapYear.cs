/*Problem 1. Leap year

    Write a program that reads a year from the console and checks whether it is a leap one.
    Use System.DateTime.
*/
using System;


namespace P01LeapYear
{
    class LeapYear
    {
        static void Main()
        {
            Console.Write("Enter a year: ");
            //string today = Console.ReadLine();
            //DateTime date = Convert.ToDateTime(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, 1, 1);
            if(DateTime.IsLeapYear(date.Year))
            {
                Console.WriteLine("{0:yyyy} is leap year." , date);
            }
            else
            {
                Console.WriteLine("{0:yyyy} is NOT leap year.", date);
            }
        }
    }
}
