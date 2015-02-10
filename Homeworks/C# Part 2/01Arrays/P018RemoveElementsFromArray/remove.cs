/* Problem 18.* Remove elements from array

    Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order.
    Print the remaining sorted array.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Remove
{
    static void Main()
    {
        List<int> someArray = new List<int> { 6, 1, 4, 3, 0, 3, 6, 4, 5 }; // I don't know it will work with random numbers 6, 1, 4, 3, 0, 3, 6, 4, 5

        List<int> myList = new List<int>();

        int max = someArray.Max();
        int index = 0;

        for (int i = 0; i < someArray.Count - 1; i++)
        {
            if (someArray[i] < someArray[i + 1])
            {
                index = i;
                myList.Add(someArray[i]);
                break;
            }
        }
        int search = someArray[index];
        while (search <= max)
        {
            search++;
            for (int i = index; i <= someArray.Count -1; i++)
            {
                if(someArray[i] == search)
                {
                    myList.Add(someArray[i]);
                    index = i;
                }
            }
        }
        Console.WriteLine(string.Join(", ", myList));

    }
}
