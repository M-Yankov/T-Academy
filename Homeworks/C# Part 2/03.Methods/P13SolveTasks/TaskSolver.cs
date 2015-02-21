/*
    Write a program that can solve these tasks:
        Reverses the digits of a number
        Calculates the average of a sequence of integers
        Solves a linear equation a * x + b = 0
    Create appropriate methods.
    Provide a simple text-based menu for the user to choose which task to solve.
    Validate the input data:
        The decimal number should be non-negative
        The sequence should not be empty
        a should not be equal to 0
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13SolveTasks
{
    class TaskSolver
    {
        static void Main()
        {

            int choice = 0;
            while (choice != 1 && choice != 2 && choice != 3)
            {
                Console.Clear();
                Console.WriteLine("Tasks:");
                Console.WriteLine("Your choce is: ");
                Console.WriteLine("\n1. Reverse digits in number.");
                Console.WriteLine("2. Average of sequence.");
                Console.WriteLine("3. a * x + b = 0.");
                Console.SetCursorPosition(20, 1);
                choice = int.Parse(Console.ReadLine());
            }
            Console.SetCursorPosition(0, 7);
            if (choice == 1)
            {
                Reverserr();
            }
            else if (choice == 2)
            {
                Averager();
            }
            else
            {
                Unknown();
            }

        }
        static void Reverserr()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            if (num < 1)
            {
                Console.WriteLine("Number can't be negative!");
                Console.WriteLine("Press any key to return.");
                Console.ReadLine();
                Main();
            }
            List<int> myList = new List<int>();
            int len = num.ToString().Length;
            for (int i = 0; i < len; i++)
            {
                int temp = num % 10;
                myList.Add(temp);
                num /= 10;
            }
            myList.Reverse(0, 0);
            string s = string.Join("", myList);
            Console.WriteLine("Reversed: {0}", s);
            Console.WriteLine();
        }
        static void Averager()
        {
            Console.Write("Enter sequence of integers: ");
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.Write("Please enter a sequence!");
                Console.ReadLine();
                Main();
            }
            int sequence = int.Parse(s);

            int len = sequence.ToString().Length;
            List<int> myList = new List<int>();
            for (int i = 0; i < len; i++)
            {
                int temp = sequence % 10;
                myList.Add(temp);
                sequence /= 10;
            }
            Console.WriteLine("Average is: {0:0.00}", myList.Average());
        }
        static void Unknown()
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.Write("a must not be equal to 0");
                Console.ReadLine();
                Main();
            }
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            double x = b / a;
            
            if (b < 0)
            {
                Console.WriteLine("{0} * x + ({1}) = 0", a, b);

            }
            else
            {
                Console.WriteLine("{0} * x + {1} = 0", a, b);

            }
            Console.WriteLine("x = {0:0.00}", x);
        }
    }
}
