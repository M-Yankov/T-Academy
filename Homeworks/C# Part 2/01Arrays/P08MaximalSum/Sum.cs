/*Problem 8. Maximal sum

    Write a program that finds the sequence of maximal sum in given array.
 * 
    Can you do it with only one loop (with single scan through the elements of the array)?
2, 3, -6, -1, 2, -1, 6, 4, -8, 8
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Sum
    {
        static void Main()
        {
            Console.Write("Enter elements int[] in Array --> \n--> Separeted by space: "); // 1 , -7 , 3 ,4 , -10 , 9 
            int[] elements = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int sum = 0;
            int maximus = 0;
            int lastindex = 0;
            int count = 0;
            int length = 0;

            for (int i = 0; i <= elements.GetUpperBound(0); i++) // GetUpperBound(0) = last index from array. 0 means of the row . 1 means for col if Array is with two dimesions 
            {
                sum += elements[i];
                count++;
                if(sum > maximus)
                {
                    maximus = sum;
                    length = count;
                    lastindex = i;
                }
                if(sum < 0)
                {
                    sum = 0;
                    count = 0;
                }
            }
            //int[] something = elements.TakeWhile(n => n <= lastindex).ToArray();
            //elements.ToList().ForEach(delegate(int name) { Console.WriteLine(name); }); // 
            List<int> final = new List<int>();
            for (int d = lastindex - length +1; d <= lastindex; d++)
            {
                final.Add(elements[d]);
            }
            Console.WriteLine(string.Join(", ", final));
            Console.WriteLine();
        }
    }
