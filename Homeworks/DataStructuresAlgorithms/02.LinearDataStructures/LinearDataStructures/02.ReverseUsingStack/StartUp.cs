namespace ReverseUsingStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task1. Write a program that reads N integers from the console and reverses them using a stack.
    ///     ○ Use the Stack<int> class.
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("How many numbers will add? ");
            int size = 0;
            if (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Wrong input!");
                return;
            }

            Stack<int> numbers = new Stack<int>(); 
            int current;
            string input = " ";

            for (int i = 0; i < size; i++)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out current))
                {
                    numbers.Push(current);
                }
                else
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.Write("Your numbers: ");
            Console.WriteLine(string.Join(", ", numbers));
            //// It can be done with another loop using numbers.Pop();
        }
    }
}
