namespace First50Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 09.We are given the following sequence:
    ///     ○ S1 = N;
    ///     ○ S2 = S1 + 1;
    ///     ○ S3 = 2*S1 + 1;
    ///     ○ S4 = S1 + 2;
    ///     ○ S5 = S2 + 1;
    ///     ○ S6 = 2*S2 + 1;
    ///     ○ S7 = S2 + 2;
    ///     ○ ... 
    ///     ○ Using the Queue<T> class write a program to print its first 50 members for given N.
    ///     ○ Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    public class FirstNumbersByFormula
    {
        private const int Length = 50;
        private static readonly string TextFormatErrorMessage = "Cannot parse [{0}] to " + new int().GetType().Name;

        public static void Main()
        {
            Console.Write("Enter the first number: ");

            Queue<int> queue = new Queue<int>();
            int number = 0;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                string message = string.Format(TextFormatErrorMessage, input);
                throw new InvalidCastException(message);
            }

            queue.Enqueue(number);
            int counter = 1;

            List<int> result = new List<int>();

            while (counter < Length)
            {
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue((2 * queue.Peek()) + 1);
                queue.Enqueue(queue.Peek() + 2);
                result.Add(queue.Dequeue());
                counter += 3;
            }

            while (queue.Count != 0)
            {
                result.Add(queue.Dequeue());
            }

            Console.WriteLine(string.Join(", ", result.Take(50)));
        }
    }
}
