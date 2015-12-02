namespace MaxIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SolverMaxSubSequence
    {
        public static void Main()
        {
            int[] numbers = new[] { 1, 8, 2, 7, 3, 4, 1, 6, 1, 8, 2, 7, 3, 4, 1, 6, 1, 8, 2, 7, 3, 4, 1, 6, 1, 8, 2, 7, 3, 4, 1, 6 };

            int bestLength = 0;
            int indexOfBestLength = 0;

            int[] maxLength = new int[numbers.Length];
            int[] predecessor = new int[numbers.Length];

            maxLength[0] = 1;
            predecessor[0] = -1;
            for (int i = 1; i < numbers.Length; i++)
            {
                maxLength[i] = 1;
                predecessor[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[j] < numbers[i] && maxLength[j] + 1 > maxLength[i])
                    {
                        maxLength[i] = maxLength[j] + 1;
                        predecessor[i] = j;
                    }
                }

                if (bestLength < maxLength[i])
                {
                    bestLength = maxLength[i];
                    indexOfBestLength = i;
                }
            }

            Console.WriteLine("Max increasing subsequent: {0}", bestLength);
            Console.WriteLine(FindTheMaxIncreasingNumbers(numbers, maxLength, predecessor));
        }

        private static string FindTheMaxIncreasingNumbers(int[] numbers, int[] lengths, int[] predecessors)
        {
            Stack<int> result = new Stack<int>();
            int index = predecessors.Length - 1;

            while (index != -1)
            {
                result.Push(numbers[index]);
                index = predecessors[index];
            }

            StringBuilder stringNumbers = new StringBuilder();
            while (result.Count != 0)
            {
                stringNumbers.Append(result.Pop() + " ");
            }

            return stringNumbers.ToString().TrimEnd();
        }
    }
}
