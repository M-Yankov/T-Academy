using System;
using System.Numerics;
namespace BinaryTreees
{
    public class Program
    {
        static long[] memo;

        private static long Pesho(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            if (memo[number] > 0)
            {
                return memo[number];
            }

            long result = 0;

            for (int i = 0; i < number; i++)
            {
                result += Pesho(i) * Pesho(number - 1 - i);
            }

            memo[number] = result;
            return result;
        }


        public static void Main()
        {

            int[] letters = new int[26];
            var balls = Console.ReadLine();

            foreach (var ball in balls)
            {
                letters[ball - 'A']++;
            }

            int n = balls.Length;
            memo = new long[n + 1];

            long[] factoriels = new long[n + 1];
            factoriels[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factoriels[i + 1] = factoriels[i] * (i + 1);
            }

            long result = factoriels[n];

            foreach (var item in letters)
            {
                result /= factoriels[item];
            }

            BigInteger total = result;
            total *= Pesho(n);
            Console.WriteLine(total);
        }
    }
}
