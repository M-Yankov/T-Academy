/*Problem 2. Random numbers

    Write a program that generates and prints to the console 10 random values in the range [100, 200].
*/

using System;

namespace P02RandomNumbers
{
    class RanNumbers  // <----- Don't rename this class to Random !!! Rename it to see why. 
    {
        static void Main()
        {
            Console.WriteLine("\t\t ToTo");
            Console.WriteLine("\t 10 Random numbers from 100 to 200");
            DateTime end;
            TimeSpan twoSeconds = new TimeSpan(0, 0, 2);
            Random num = new Random();
            int ramdomizedNum;
            TimeSpan result = new TimeSpan(0, 0, 0);
            for (int i = 0, j = 0; i < 10; i++, j += 5)
            {
                DateTime start = DateTime.Now;
                while (twoSeconds > result)       // after first iteration result must be reset
                {
                    ramdomizedNum = num.Next(100, 200);
                    Console.SetCursorPosition(j, 3);   // print number
                    Console.WriteLine(ramdomizedNum);
                    end = DateTime.Now;
                    result = end.Subtract(start);
                }
                result = new TimeSpan(0, 0, 0);   // reset result
            }
        }
    }
}
