using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07Selectionsort
{
    class Sorting
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            List<int> sorted = new List<int>();
            string input ;
            while (true)
            {
                //type end to exit
                Console.Write("Enter num or \"end' to exit\" ");
                input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                else
                {
                    numbers.Add(Convert.ToInt32(input));

                }
                
            }
            while(numbers.Count != 0)
            {
                sorted.Add(numbers.Min());
                numbers.Remove(numbers.Min());
            }
            foreach (int s in sorted)
            {
                Console.Write(s + " ");
         
            }
            // is not at right algorithm
        }
    }
}
