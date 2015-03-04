using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green
{
    class Program
    {
        static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            char[] array = new char[k];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToChar(Console.ReadLine());
            }

            int n = array.Length;
            char[] resulting = new char[k];
            //int counter = 0;
            List<int> counter = new List<int>();
            Various(0, array, resulting, k, n, counter);
            Console.WriteLine(counter.Count);
            
        }
        static void Various(int index, char[] input, char[] result, int k, int n, List<int> counter)
        {
            
            if (index == k)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write("{0,3}", result[i]);
                    
                }
                if (Check(result))
                {
                    Console.Write("\t true");
                    counter.Add(1);
                }
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                result[index] = input[i];
                Various(index + 1, input, result, k, n, counter);
            }
        }
        static bool Check(char[] symbols)
        {
            char temp = ' ';
            bool value = true;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (temp == symbols[i])
                {
                    value = false;
                    break;
                }
                temp = symbols[i];
            }
            return value;
        }
    }
}
