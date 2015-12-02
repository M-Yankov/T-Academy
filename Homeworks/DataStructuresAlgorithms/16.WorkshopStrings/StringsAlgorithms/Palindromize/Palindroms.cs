namespace Palindromize
{
    using System;

    public class Palindroms
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (IsPalindrom(input))
            {
                Console.WriteLine(input);
                return;
            }

            var answer = PalindromizeIt(input);
            Console.WriteLine(answer);
        }

        private static bool IsPalindrom(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string PalindromizeIt(string str)
        {
            for (int numOfChars = 0; numOfChars < str.Length; numOfChars++)
            {
                var firstChars = str.Substring(0, numOfChars).ToCharArray();
                Array.Reverse(firstChars);
                var probablyAnswer = str + new string(firstChars);
                if (IsPalindrom(probablyAnswer))
                {
                    return probablyAnswer;
                }
            }

            return null;
        }
    }
}
