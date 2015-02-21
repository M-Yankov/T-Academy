/*Problem 14. Integer calculations

    Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
    Use variable number of arguments.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Calculations
    {
        static void Main()
        {
            int[] myArray = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();
            
            Console.WriteLine("Max is {0}",myArray.Max());
            Console.WriteLine("Min is {0}", myArray.Min());
            Console.WriteLine("Average is {0:0.00}", myArray.Average());
            Console.WriteLine("Sum is {0}" , myArray.Sum());
            Console.WriteLine("Product is {0}" , Product(myArray));
            // If understand the description of the problem.
        }
        static int Product(int[] arr) 
        {
            int pr = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                pr *= arr[i];
            }
            return pr;
        }
    }
