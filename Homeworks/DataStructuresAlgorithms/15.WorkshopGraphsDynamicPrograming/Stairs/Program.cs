using System;
using System.Linq;

namespace Stairs
{
    public class Program
    {
        static long[,] count;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            count = new long[n + 1, n + 1];

            count[0, 0] = 1;
            count[1, 1] = 1;
            count[2, 2] = 1;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k < j && i - j >= k; k++)
                    {
                        count[i, j] += count[i - j, k];
                    }
                }
            }

            long answer = 0;
            for (int i = 1; i < n; i++)
            {
                answer += count[n, i];
            }

            Console.WriteLine(answer);
        }
     }
}