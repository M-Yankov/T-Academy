/*Problem 5. Larger than neighbours

    Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Larger
{
    static void Main()
    {
        Console.Write("Enter int[] Elements separeted by space: ");
        int[] myArray = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        Console.Write("Enter index in array: ");
        int index = int.Parse(Console.ReadLine());
        if(index > myArray.Length - 1)
        {
            Console.WriteLine("Out of range");
            return;
        }
        bool final = Bigger(myArray, index);
        if (index == 0 || index == myArray.Length - 1)
        {
            if(final)
            {
                Console.WriteLine("arr[{0}] = {1} is larger than it's neighbour.", index, myArray[index]);
            }
            else
            {
                Console.WriteLine("arr[{0}] = {1} is NOT larger than it's neighbour.", index, myArray[index]);
            }
        }
        else
        {
            if (final)
            {
                Console.WriteLine("arr[{0}] = {1} is larger than its two neighbours.", index, myArray[index]);
            }
            else
            {
                Console.WriteLine("arr[{0}] {1} is NOT larger than its two neighbours.", index, myArray[index]);
            }
        }
    }
    static bool Bigger(int[] a, int index)
    {
        bool result;
        if (index == 0)
        {
            result = a[index] > a[index + 1];
        }
        else if (index == a.Length - 1)
        {
            result = a[index] > a[index - 1];
        }
        else
        {
            result = a[index] > a[index + 1] && a[index] > a[index - 1];
        }
        return result;
    }
}

