namespace OddTimesWords
{
    using System.Collections.Generic;
    using System.Linq;
    using Helper;

    public class WordsSolution
    {
        private const string StringFormatForResult = "│{0,-20}│{1,-20}│\n└{2}{3}{2}┘";

        public static void Main()
        {
            string[] words =
                new string[] { "Java", "C#", "JavaScript", "Ajax", "SQL", "PHP", "Ajax", "Java", "PHP", "JavaScript", "SQL", "SQL", "Java", "JavaScript", "JavaScript", "Ajax", "Java" };
            IDictionary<string, int> pairs = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (pairs.ContainsKey(words[i]))
                {
                    pairs[words[i]]++;
                }
                else
                {
                    pairs.Add(words[i], 1);
                }
            }

            IDictionary<string, int> oddOccour = new Dictionary<string, int>();
            pairs.Where(x => x.Value % 2 == 1).ToList().ForEach(x => oddOccour.Add(x));

            string result = Formater.FormatPairsForTemplate(StringFormatForResult, oddOccour);
            System.Console.WriteLine(result);
        }
    }
}
