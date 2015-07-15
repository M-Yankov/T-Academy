namespace CSharpExam1.RefactoredSolutions
{
    using System;
    using System.Collections.Generic;

    class RefactoredSearchInBits
    {
        static void Main()
        {
            int patternNumber = int.Parse(Console.ReadLine());
            int numbersLength = int.Parse(Console.ReadLine());

            List<string> numbersInbits = new List<string>();

            for (int i = 0; i < numbersLength; i++)
            {
                long numberFromConsole = long.Parse(Console.ReadLine());
                numbersInbits.Add(Convert.ToString(numberFromConsole, 2).PadLeft(16, '0'));
            }

            string numberToFindInBits = Convert.ToString(patternNumber, 2).PadLeft(4, '0');

            int matches = FindMatches(numberToFindInBits, numbersInbits);
            Console.WriteLine(matches);
        }

        private static int FindMatches(string patternNumber, List<string> numbersInbits)
        {
            int countMatches = 0;

            for (int number = 0; number < numbersInbits.Count; number++)
            {
                string currentBinaryNumber = numbersInbits[number];

                for (int ch = 0; ch < currentBinaryNumber.Length - 3; ch++)
                {
                    string fourBits = currentBinaryNumber.Substring(ch, 4);

                    if (fourBits == patternNumber)
                    {
                        countMatches++;
                    }
                }
            }

            return countMatches;
        }
    }
}
