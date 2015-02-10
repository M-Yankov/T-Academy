/*Problem 9. Frequent number

    Write a program that finds the most frequent number in an array.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Frequenter
{
    static void Main()
    {
        Console.Write("Enter int[] elements separeted with space or comma: ");
        int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int count0 = 0;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;
        int count7 = 0;
        int count8 = 0;
        int count9 = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            switch (numbers[i])
            {
                case 0:
                    count0++; break;
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
                case 7: count7++; break;
                case 8: count8++; break;
                case 9: count9++; break;
                default: break;
            }
        }
        List<int> maximals = new List<int> { count0, count1, count2, count3, count4, count5, count6, count7, count8, count9 };
        // to know index of this maximal count // indexes correspond numbers 
        int maxxxxx = 0;
        for (int a = 0; a < maximals.Count; a++)
        {
            int temp = maximals[a];
            if (temp > maxxxxx)
            {
                maxxxxx = a;
            }
        }
        int max = maximals.Max();
        Console.WriteLine(maxxxxx + " ( " + max + " times.)");
    }
}

