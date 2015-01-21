/*Problem 11.* Numbers in Interval Dividable by Given Number

    Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.

 */

using System;



class Numbers
{
    static void Main()
    {
        Console.Write("Enter start number: ");
        uint numA = uint.Parse(Console.ReadLine());
        Console.Write("Enter end number: ");
        uint numB = uint.Parse(Console.ReadLine());
        int count = 0;
        for (uint i = numA; i <= numB; i++ )
        {
            if (i % 5 == 0)
            {
                if(i== numB)
                {
                    Console.Write(i);
                    count++;
                }
                else
                {
                    Console.Write(i + ", ");
                    count++;
                }
            }
        }
        Console.WriteLine();
        if (count == 0)
        {
            Console.WriteLine("There are no numbers between {0} and {1} that can be divided by 5.", numA, numB);
        }
        else
        {
            Console.WriteLine("There are {0} numbers between {1} and {2} that can be devided by 5.", count, numA, numB);
        }
    }
}
