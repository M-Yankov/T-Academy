/*Problem 10. Find sum in array

    Write a program that finds in given array of integers a sequence of given sum S (if present).
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FindSum
{
    static void Main()
    {
        Console.Write("Enter int[] numbers in array separeted by space: ");
        int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.Write("You search for sequence with sum of ... ");
        int sum = int.Parse(Console.ReadLine());
        int search = 0;
        int count = 0;
        int lastindex = 0;
        int lentgth = 0;
        bool exit = false;
        //  1, 2, 4, 5, -10, 5, 4;  // we search 11 and sum of all elements is equal to 11 so answer must be all elements:
        // 12 , 2 ,2 , -4  --  Answer:  There is no sequence
        // 5 -8 9 6 8 -5 3     answer: 6 8
        //4, 3, 1, 4, 2, 5, 8 -- answer: 4, 2, 5
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            search += numbers[i];
            count++;
            if (search == sum)
            {
                lentgth = count;
                lastindex = i;
                exit = true;
                break;
            }
            for (int j = i + 1; j < numbers.Length; j++)
            {

                search += numbers[j];
                count++;
                if (search == sum)
                {
                    lentgth = count;
                    lastindex = j;
                    exit = true;
                    break;
                }
            }
            if (exit)
            {
                break;
            }
            count = 0;
            search = 0;
        }
        if (count < 2) // the program can find a number equal to input sum , but it must be more that one number
        {
            Console.WriteLine(" There is no sequence !");
        }
        else
        {

            for (int indexium = lastindex - lentgth + 1; indexium <= lastindex; indexium++)
            {
                Console.Write(numbers[indexium] + " ");
            }
            Console.WriteLine();
        }
    }

}
