/*Problem 7. Selection sort

    Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
    Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the 
 *  smallest from the rest, move it at the second position, etc.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sorting
{
    static void Main()
    {
        Console.Write("Enter elements int[] to sort separeted by space: ");
        int[] myArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int temp;
        for (int i = 0; i < myArray.Length -1  ; i++)
        {
            
            int min =i;
            for (int j = i+1; j < myArray.Length ; j++)
            {
                if(myArray[j] < myArray[min])
                {
                    min = j;
                }
            }
            if(min != i)
            {
                // swaping
                temp = myArray[i];
                myArray[i] = myArray[min];
                myArray[min] = temp;
            }
        }




        Console.WriteLine(string.Join(", ", myArray));  // first Printig 

        Console.WriteLine();
        // Second way to print.
        for (int g = 0; g < myArray.Length; g++ )
        {
            if (g != (myArray.Length - 1))
            {
                Console.Write(myArray[g] + ", ");
            }
            else
            {
                Console.Write(myArray[g]);
            }
        }
            Console.WriteLine();
        


        // List<int> numbers = new List<int>();
        // List<int> sorted = new List<int>();
        // string input ;
        // while (true)
        // {
        //     //type end to exit
        //     Console.Write("Enter num or \"end' to exit\" ");
        //     input = Console.ReadLine();
        //     if(input == "end")
        //     {
        //         break;
        //     }
        //     else
        //     {
        //         numbers.Add(Convert.ToInt32(input));
        //
        //     }
        //     
        // }
        // while(numbers.Count != 0)
        // {
        //     sorted.Add(numbers.Min());
        //     numbers.Remove(numbers.Min());
        // }
        // foreach (int s in sorted)
        // {
        //     Console.Write(s + " ");
        //
        // }
        // // is not at right algorithm
    }
}

