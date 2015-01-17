/*Problem 3. Divide by 7 and 5

    Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.
 */

using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("Number:\tDivide by 7 and 5");
        bool sevenFive;
        for (int i = 0; i <= 200; i++)//Again I use a loop to show number from 0 to 200, but through 5 numbers( Like 0,5,10,15,20,25...)
        {
            sevenFive = ((i % 5) == 0) && ((i % 7) == 0);//This is the Boolean expression
            Console.WriteLine(i+"\t"+sevenFive);
            
            i += 4;
        }
    }
}

