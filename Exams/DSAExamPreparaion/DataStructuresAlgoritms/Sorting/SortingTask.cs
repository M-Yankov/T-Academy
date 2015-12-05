namespace Sorting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.IO;

    public class SortingTask
    {
        public static void Main()
        {
            //Console.SetIn(new StringReader(ProvideInput()));
            Console.ReadLine();
            int[] firstVertex = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numbersToTake = int.Parse(Console.ReadLine());

            int answer = Solve(firstVertex, numbersToTake);
            Console.WriteLine(answer);

        }

        private static string ProvideInput()
        {
            return @"5
1 4 3 2 5
5";
        }

        private static int Solve(int[] firstVertex, int numbersToTake)
        {
            //// hash & steps
            Dictionary<int, int> visited = new Dictionary<int, int>();
            visited.Add(GetHashCode(firstVertex), 0);

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(firstVertex);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                var pathToCurrent = visited[GetHashCode(current)];
                if (IsSorted(current))
                {
                    return pathToCurrent;
                }

                for (int i = 0; i <= current.Length - numbersToTake; i++)
                {
                    var next = current.Clone() as int[];
                    Array.Reverse(next, i, numbersToTake);
                    if (!visited.ContainsKey(GetHashCode(next)))
                    {
                        queue.Enqueue(next);
                        visited.Add(GetHashCode(next), pathToCurrent + 1);
                    }
                }
            }

            return -1;
        }

        //// 1234
        private static int GetHashCode(int[] current)
        {
            int result = 0;
            foreach (var number in current)
            {
                result = (result * 10) + number;
            }

            return result;
        }

        private static bool IsSorted(int[] current)
        {
            for (int i = 0; i < current.Length - 1; i++)
            {
                if (current[i] >= current[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
