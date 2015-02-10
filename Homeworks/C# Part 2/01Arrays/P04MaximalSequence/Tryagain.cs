/*Problem 4. Maximal sequence

    Write a program that finds the maximal sequence of equal elements in an array.
 */

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;


class LetsTryAgain
{
    static void Main()
    {
        Console.Write("Array Lenght: ");
        int range = int.Parse(Console.ReadLine());
        int[] myArray = new int[range];
        int count = 1;
        int lastindex = 0;
        for (int i = 0; i < range; i++)
        {
            Console.Write("Enter " + i + " index: ");
            myArray[i] = int.Parse(Console.ReadLine());
        }
        int temp = 0;
        for (int j = 0; j < myArray.Length - 1; j++)
        {
            if (myArray[j] == myArray[j + 1])
            {
                count++;
                if (count > temp)
                {
                    temp = count;
                    lastindex = j;
                }

            }
            else
            {
                count = 1;
            }
        }
        lastindex++;
        //string finres = string.Join(", ", final);
        string result = "";
        int startIndex = (lastindex - (temp - 1));
        for (int i = startIndex; i <= lastindex; i++)
        {
            result += myArray[i] + " ";
        }
        //Console.WriteLine(finres);
        if (result.Length > 1)
        {
            Console.WriteLine(result);// (string.Join(", ", result));

        }
        else
        {
            Console.WriteLine("No Sequence" );
        }///               string[] numberStrigs = Console.REadLine().Split(' ');
        // int[] numbres = Console.ReadLine().split(' ').Select(int.parse).ToArray();

    }
}