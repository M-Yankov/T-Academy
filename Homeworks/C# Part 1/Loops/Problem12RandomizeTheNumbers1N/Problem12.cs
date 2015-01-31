/*Problem 12.* Randomize the Numbers 1…N

    Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Problem12
{
    static void Main()
    {
        
        
        Console.Write("Enter n: ");
        int range = int.Parse(Console.ReadLine());
        int[] randomized = new int[range];
        Random generator = new Random();
        List<int> numerics = Enumerable.Range(1, range).ToList();
        int index ;
        for (int i = 0; i < range; i++)
        {
            index = generator.Next(0, numerics.Count);
            randomized[i] = numerics[index];
            numerics.RemoveAt(index);
        }
        foreach (var i in randomized)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        
        // That's was litle difficult // I use source from --> http://stackoverflow.com/questions/14884934/filling-an-array-randomly-with-no-repetitions#answer-14885145
        // warring will shows up

    }
}

