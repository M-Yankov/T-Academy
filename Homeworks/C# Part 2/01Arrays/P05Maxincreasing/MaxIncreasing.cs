/* Problem 5. Maximal increasing sequence

   Write a program that finds the maximal increasing sequence in an array.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaxIncreasing
{
    static void Main()
    {
        Console.Write("Array Items: ");
        int[] myList = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int temp = 0; /// as length
        int lastIndex = 0;
        int count = 1;
        for (int j = 0; j < myList.Length - 1; j++)
        {
            if (myList[j] + 1 == (myList[j + 1]))
            {
                count++;

                if (count > temp)
                {
                    temp = count;
                    lastIndex = j;
                }
            }
            else
            {
                count = 1;
            }
        }
        lastIndex++;
        int startIndex =  (lastIndex -(temp -1));
        string finres = "";// string.Join(", ", finito);
        for (int i = startIndex ; i <= lastIndex; i++)
        {
            finres += myList[i] + " ";
        }
        Console.WriteLine(finres); // bah mama my i zadacha znam si algoritama no ne moga da go implementiram  :X //DA si popravq predishanta zadacha
    }
}

