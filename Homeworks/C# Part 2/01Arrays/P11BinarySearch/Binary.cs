/*Problem 11. Binary search

    Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Binary
{
    static void Main()
    {
        // I will use Iterative algorithm
        Console.Write("Enter int[] elements in array separeted by space: ");
        int[] numbers = Console.ReadLine().Split(new string[] { " ", ", ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.Write("Search for element: ");
        int searchedItem = int.Parse(Console.ReadLine());
        Array.Sort(numbers);

        Console.Write("Elements After Sort: ");
        Console.WriteLine(string.Join(", ", numbers));
        int result = Interative(numbers, searchedItem, 0, numbers.Length - 1);
        if (result == -1)
        {
            Console.WriteLine("There is no such element!");
        }
        else
        {
            Console.WriteLine("Index of {0} is: {1} ", searchedItem, result);

        }
    }
    private static int Interative(int[] nums, int element, int min, int max)
    {
        // min = 0;
        // max = nums.Length - 1;
        int midle;
        while (max >= min)
        {
            midle = (min + max) / 2;
            if (nums[midle] == element)
            {
                return midle;
            }
            else if (nums[midle] < element)
            {
                min = midle + 1;
            }
            else
            {
                max = midle - 1;
            }
        }
        return -1;
    }

}


