using System;
using System.Collections.Generic;



namespace StrangeLanf_and_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {                                               //0     1       2         3           4      5       6
            List<string> numeralSys =  new List<string>{ "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
            string input = "pNWEoBJECbINf";
            string word = "";
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                word += input[i];
                if (numeralSys.Contains(word))
                {
                    numbers.Push(numeralSys.IndexOf(word));
                    word = "";
                }
            }

            const int seven = 7;
            long sum = numbers.Pop();
            int counter = 1;
            while (numbers.Count != 0)
            {
                sum += numbers.Pop() * (long) Math.Pow(seven, counter);
                counter++;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
