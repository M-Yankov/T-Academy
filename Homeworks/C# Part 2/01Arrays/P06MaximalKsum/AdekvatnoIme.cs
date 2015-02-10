/*Problem 6. Maximal K sum

    Write a program that reads two integer numbers N and K and an array of N elements from the console.
    Find in the array those K elements that have maximal sum.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AdekvatnoIme
{
    static void Main()
    {                                                         // 0 ,1, 2, 3, 4, 5
        Console.Write("Enter elements separated by space: "); // 1 ,3 ,3 ,7 ,9, 9
        int[] myArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.Write("Enter length of elements to find Max sum: ");
        int inputLong = int.Parse(Console.ReadLine());
        Array.Sort(myArray); // Sorting elements
        for (int i = myArray.Length - inputLong; i < myArray.Length; i++)
        {
            Console.Write(myArray[i] + " " );
        }
        Console.WriteLine();
    }
}

