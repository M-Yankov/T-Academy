namespace CSharpExam2.Refactored
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RefactoredMathProblem
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 10;

        private static List<string> letters = 
            new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };

        internal static void RefMain()
        {
            string input = Console.ReadLine();
            ValidateInputText(input);

            string[] words = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            ValidateWords(words);
           
            Stack<int> numbers = new Stack<int>();
            List<long> sumsOfNumbers = new List<long>();
            Stack<int> valuesOfCodeSystem = new Stack<int>();

            long currentSum = 0;

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int indexOfCodeSystem = letters.IndexOf(word[i].ToString());
                    numbers.Push(indexOfCodeSystem);
                }

                int counter = 0;

                while (numbers.Count != 0)
                {
                    if (counter == 0)
                    {
                        currentSum += numbers.Pop();
                    }
                    else
                    {
                        currentSum += numbers.Pop() * (long)Math.Pow(19, counter);
                    }

                    counter++;
                }

                sumsOfNumbers.Add(currentSum);
                currentSum = 0;
            }

            long bigSum = sumsOfNumbers.Sum();
            long backupOfBigSum = bigSum;
            int codeSystemIndex;

            while (bigSum >= 19)
            {
                codeSystemIndex = (int)bigSum % 19;
                bigSum /= 19;
                valuesOfCodeSystem.Push(codeSystemIndex);
            }

            valuesOfCodeSystem.Push((int)bigSum);

            StringBuilder strBuild = new StringBuilder();

            while (valuesOfCodeSystem.Count != 0)
            {
                codeSystemIndex = valuesOfCodeSystem.Pop();
                strBuild.Append(letters[codeSystemIndex]);
            }

            Console.WriteLine("{0} = {1}", strBuild.ToString(), backupOfBigSum);
        }

        private static void ValidateInputText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("Please enter a text!");
            }

            if (text.Length < MIN_LENGTH || 10 < MAX_LENGTH)
            {
                throw new ArgumentOutOfRangeException("Lenght of text must be between " + MIN_LENGTH + " and " + MAX_LENGTH + "!");
            }

            if (text[0] == 'a')
            {
                throw new ArgumentException("The text can NOT begin with character 'a' !");
            }
        }

        private static void ValidateWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (!word.All(x => char.IsLower(x)))
                {
                    throw new ArgumentException("All letters must be lowercase!");
                }
            }
        }
    }
}
