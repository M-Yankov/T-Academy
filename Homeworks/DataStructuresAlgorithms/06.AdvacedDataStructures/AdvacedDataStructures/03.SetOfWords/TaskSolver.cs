namespace SetOfWords
{
    using System;
    using System.IO;
    using System.Linq;
    using Triepocalypse;

    /// <summary>
    /// Source: http://geekyisawesome.blogspot.bg/2010/07/c-trie.html
    /// Task 03.
    /// </summary>
    public class TaskSolver
    {
        public static void Main()
        {
            Trie<int> trie = new Trie<int>();

            using (StreamReader reader = new StreamReader("..\\..\\PasswordsFromFaceBook.txt"))
            {
                while (!reader.EndOfStream)
                {
                    reader
                        .ReadLine()
                        .Split(' ', '.', ',', '?', '!', ':')
                        .ToList()
                        .ForEach(word =>
                        {
                            if (!trie.ContainsKey(word))
                            {
                                trie.Add(word, 1);
                            }
                            else
                            {
                                trie[word] += 1;
                            }
                        });
                }
            }

            //// Search is case sensitive.
            //// For reference open NotePad++ > Ctrl+F > 'lorem' > [√] MatchCase > Click Count
            trie.Matcher.Next("lorem");

            int countOfLorem = 0;

            if (trie.Matcher.IsMatch())
            {
               countOfLorem = trie.Matcher.GetExactMatch();
            }

            Console.WriteLine(countOfLorem);
            //// PF OMG that works 
        }
    }
}
