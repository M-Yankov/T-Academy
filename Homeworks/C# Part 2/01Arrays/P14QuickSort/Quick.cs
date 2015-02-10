/*Problem 14. Quick sort
 * Write a program that sorts an array of strings using the Quick sort algorithm.
 */
/* 3, 6, 3, 7, 2, 9
// 7, 6, 3, 2, 3, 9
 * 3, 6, 2, 7, 3, 9
 * 6, 2, 3, 7, 3, 9 -- 2
 * 2, 6, 3, 7, 3, 9
 * 2, 7, 3, 3, 6, 9
 * 2, 3, 3, 7, 6, 9
 * 2, 3, 3, 6, 7, 9
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Quick
{
    static void Main()
    {
        Console.Write("Enter int[] array elements: ");
        int[] numbers = Console.ReadLine().Split(new string[] { " ", ", ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        // print numbers before sort
        Console.WriteLine(string.Join(", ", numbers));
        QuickSorting(numbers, 0, numbers.Length - 1);
        // after sort
        Console.WriteLine(string.Join(", ", numbers));


        //int i = 0;
        //// first part
        //while (i < last)
        //{
        //    if (myArray[i] > myArray[last])
        //    {
        //        int temp1;
        //        temp1 = myArray[last];
        //        myArray[last] = myArray[i];
        //        myArray[i] = myArray[last - 1];
        //        myArray[last - 1] = temp1;
        //        last--;
        //    }
        //    else
        //    {
        //        i++;
        //    }
        //}
        //// leftPart
        //i = 0;
        //int middle = last;
        //last = last - 1;
        //while (i < last)
        //{
        //    if (myArray[i] > myArray[last])
        //    {
        //        int temp1;
        //        temp1 = myArray[last];
        //        myArray[last] = myArray[i];
        //        myArray[i] = myArray[last - 1];
        //        myArray[last - 1] = temp1;
        //        last--;
        //    }
        //    else
        //    {
        //        i++;
        //    }
        //}
        //// right part
        //i = middle + 1;
        //last = myArray.Length -1;
        //while (i < last)
        //{
        //    if (myArray[i] > myArray[last])
        //    {
        //        int temp1;
        //        temp1 = myArray[last];
        //        myArray[last] = myArray[i];
        //        myArray[i] = myArray[last - 1];
        //        myArray[last - 1] = temp1;
        //        last--;
        //    }
        //    else
        //    {
        //        i++;
          //  }
        //}







        
    }
    public static void QuickSorting(int[] nums, int start, int end)  // copied from http://snipd.net/quicksort-in-c
    {
        int i = start;
        int j = end;
        IComparable midle = nums[(start + end) / 2];
        while (i <= j)
        {
            while (nums[i].CompareTo(midle) < 0)
            {
                i++;
            }
            while (nums[j].CompareTo(midle) > 0)
            {
                j--;
            }
            if (i <= j)
            {
                IComparable temp = nums[i];
                nums[i] = nums[j];
                nums[j] = (int)temp;

                i++;
                j--;
            }
        }
        if (start < j)
        {
            QuickSorting(nums, start, j);
        }
        if (i < end)
        {
            QuickSorting(nums, i, end);
        }
    }
}

