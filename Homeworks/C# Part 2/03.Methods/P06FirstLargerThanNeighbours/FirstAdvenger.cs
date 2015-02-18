/*Problem 6. First larger than neighbours

    Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
    Use the method from the previous exercise.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FirstAdvenger
{
    static void Main()
    {
        Console.Write("Enter int[] elements separeted by space: ");
        int[] myArray = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        bool check = true;
        for (int i = 0; i < myArray.Length; i++)
        {
            if(Bigger(myArray , i))
            {
                Console.WriteLine("{0} with index {1}", myArray[i] , i);
                check = false;
                break;
            }
            else
            {
                check = true;
            }
        }
        if(check)
        {
            Console.WriteLine(-1);
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
