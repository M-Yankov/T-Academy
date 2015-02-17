/*Problem 4. Binary search

    Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


class BinaryS
{
    static void Main()
    {
        Console.Write("Enter int[] elemnts separeted by space: ");
        int[] myArray = Console.ReadLine().Split(new string[] { ",", " ", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        
        Array.Sort(myArray);
        Console.WriteLine("Your array after sort: ");
        Print(myArray);
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("I will find the largest element witch is <= K ");
        int index = Array.BinarySearch(myArray, k);
        int counter = 0;
        while (index < 0 )
        {
            if (counter > myArray.Length)
            {
                Console.WriteLine("Sorry not found");
                return;
            }
            k--;
            index = Array.BinarySearch(myArray, k);
            counter++;
        }
        Console.WriteLine(myArray[index]);

    }
    static void Print(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
    
}
