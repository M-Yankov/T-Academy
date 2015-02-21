/*Problem 9. Sorting array

    Write a method that return the maximal element in a portion of array of integers starting at given index.
    Using it write another method that sorts an array in ascending / descending order.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortingArray
{
    static void Main()  // The logic is simple , just sort and print last element ( or first depends of sorting).
    {
        Console.Write("Enter int[] array elemnts separated by space: ");
        int[] myArray = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        Console.WriteLine("Witch variant: (type 1 or 2)\n1.Ascending\n2.Descending");
        Console.SetCursorPosition(30, 1);
        int choice = int.Parse(Console.ReadLine());
        Console.SetCursorPosition(0, 5);
        if (choice == 1)
        {
            //SortAsc(myArray);
            var ascending = SortAsc(myArray);
            Console.WriteLine("After sort:");
            Print(ascending);
            Max(ascending);

        }
        else if (choice == 2)
        {
            //SortDesc(myArray);
            var descending = SortDesc(myArray);
            Console.WriteLine("After sort:");
            Print(descending);
            MaxDesc(descending);
        }
        else
        {
            Console.WriteLine("Bad Input!");
        }

    }
    static List<int> SortAsc(int[] a)    // Order by small to bigger - ascending
    {
        List<int> b = new List<int>();
        foreach (var el in a.OrderBy(x => x))
        {
            b.Add(el);   // 
        }
        return b;
    }
    static List<int> SortDesc(int[] a)
    {
        List<int> myList = new List<int>();
        foreach (var el in a.OrderByDescending(x => x))
        {
            myList.Add(el);
        }
        return myList;
    }
    static void Print(List<int> a)
    {
        Console.WriteLine(string.Join(", ", a));
        /*foreach (var i in a)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();*/
    }
    static void Max(List<int> a)
    {
        Console.WriteLine("Max is {0}", a.Max());
        //or
        Console.WriteLine("2-nd way Max is {0}", a[a.Count - 1]);
    }
    static void MaxDesc(List<int> a)
    {
        Console.WriteLine("Max is {0}", a.Max());
        //or 
        Console.WriteLine("Max is {0}" , a[0]);
    }
}
