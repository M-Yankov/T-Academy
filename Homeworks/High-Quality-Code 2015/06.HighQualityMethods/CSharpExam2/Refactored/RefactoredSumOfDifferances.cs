namespace CSarp.Refactored
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RefactoredSumOfDifferances
    {
        private const int MIN_NUMBER = -2000000000;
        private const int MAX_NUMBER = 2000000000;
        private const byte MIN_LENGTH_OF_NUMBERS = 2;
        private const byte MAX_LENGTH_OF_NUMBERS = 200;

        internal static void ToBeMain()
        {
            string inputFromConsole = Console.ReadLine();
            long[] parsedNumbers = inputFromConsole.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();

            List<long> differences = new List<long>();

            for (int index = 1; index < parsedNumbers.Length; index++)
            {
                long currentNumber = parsedNumbers[index];
                long previousNumber = parsedNumbers[index - 1];

                long differenceBetweenNumbers = Math.Abs(currentNumber - previousNumber);

                if (differenceBetweenNumbers % 2 == 0)
                {
                    index++;
                }
                else
                {
                    differences.Add(differenceBetweenNumbers);
                }
            }

            Console.WriteLine(differences.Sum());
        }

        private static void ValidateNumbers(long[] numbers)
        {
            int lengthOfCollection = numbers.Length;

            if (lengthOfCollection < MIN_LENGTH_OF_NUMBERS || MAX_LENGTH_OF_NUMBERS < lengthOfCollection)
            {
                throw new ArgumentOutOfRangeException("Count of numbers must be between " + MIN_LENGTH_OF_NUMBERS + " and " + MAX_LENGTH_OF_NUMBERS + "!");
            }

            if (numbers.Any(x => x < MIN_NUMBER || MAX_NUMBER < x))
            {
                throw new ArgumentException("All numberes must be between " + MIN_NUMBER + " and " + MAX_NUMBER + "!");
            }
        }
    }
}