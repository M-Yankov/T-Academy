namespace WordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Helper;

    public class CountWordsFromFileClass1
    {
        private const string StringFormaterResult = "│{0,-20}│{1,-20}│\n└{2}{3}{2}┘";

        public static void Main()
        {
            IDictionary<string, int> pairs = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("..\\..\\words.txt"))
            {
                reader
                    .ReadToEnd()
                    .Split(new char[] { '?', ' ', '.', '-', ',', '!', '\n', '"', '\'', ';', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(word =>
                    {
                        string lowerWord = word.ToLower();
                        if (pairs.ContainsKey(lowerWord))
                        {
                            pairs[lowerWord]++;
                        }
                        else
                        {
                            pairs.Add(lowerWord, 1);
                        }
                    });
            }

            IDictionary<string, int> orderedPairs = new Dictionary<string, int>();
            pairs.OrderBy(x => x.Value).ToList().ForEach(x => orderedPairs.Add(x));

            string result = Formater.FormatPairsForTemplate(StringFormaterResult, orderedPairs);
            Console.WriteLine(result);
        }
    }
}
