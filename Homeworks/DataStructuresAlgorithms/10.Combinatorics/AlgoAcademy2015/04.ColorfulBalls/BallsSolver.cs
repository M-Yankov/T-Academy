namespace ColorfulBalls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class BallsSolver
    {
        public static void Main()
        {
            string ballChars = Console.ReadLine();
            SortedList<char, int> charsRepetitions = new SortedList<char, int>();

            for (int i = 0; i < ballChars.Length; i++)
            {
                if (!charsRepetitions.ContainsKey(ballChars[i]))
                {
                    charsRepetitions.Add(ballChars[i], 0);
                }

                charsRepetitions[ballChars[i]]++;
            }

            IList<int> divisorsFactoriesls = charsRepetitions.Values;
            BigInteger result = 1;
            BigInteger tempResult = 1;
            int indexOfdivisFac = 0;

            BigInteger bigResult = 1;
            
            for (int i = 1, len = divisorsFactoriesls[indexOfdivisFac], currLen = 1; i <= ballChars.Length; i++, currLen++)
            {
                result *= i;
                tempResult *= currLen;

                if (currLen == len && divisorsFactoriesls.Count > indexOfdivisFac)
                {
                    bigResult *= result / tempResult;

                    if (divisorsFactoriesls.Count - 1 > indexOfdivisFac)
                    {
                        indexOfdivisFac++;
                        len = divisorsFactoriesls[indexOfdivisFac];
                    }

                    currLen = 0;
                    tempResult = 1;
                    result = 1;
                }
            }

            Console.WriteLine(bigResult);
        }
    }
}
