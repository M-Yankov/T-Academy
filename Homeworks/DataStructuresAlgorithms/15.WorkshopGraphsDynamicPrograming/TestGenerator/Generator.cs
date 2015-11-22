namespace TestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    public class Generator
    {
        private const int NumberOfRecords = 250;
        private static Random generator = new Random();
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string[] interests = new string[]
        {
            "ski", "football", "tv", "batman", "jackass", "9gag", "batman", "music", "robin", "love", "opera", "mask", "hello", "world",
            "plane", "thinf", "programing", "java", "javascript", "c++", "superman", "cominc", "peteich", "drink", "muesum", "horo", "personality", "test",
            "more", "come", "video", "youtube", "intiger", "double", "decimal", "float", "lory", "number", "complex", "api", "webapi", "asp.Net",
            "mvc", "baseball", "kors", "next", "main", "void", "static", "string", "private", "protected", "public", "internal", "interface", "class",
            "while", "for", "if", "hashset", "name", "length", "dictionary", "using", "namespace", "system", "continue", "break", "train", "yield"
        };

        public static void Main()
        {
            HashSet<string> names = new HashSet<string>();

            while (names.Count < 250)
            {
                int lengthName = generator.Next(5, 15);
                string name = GenerateStringName(lengthName);
                names.Add(name);
            }

            List<string> names2 = names.ToList();
            for (int i = 0; i < 10; i++)
            {
                using (StreamWriter writer = new StreamWriter("..\\..\\test"+i+".txt", false))
                {
                    writer.WriteLine(NumberOfRecords);

                    for (int z = 0; z < NumberOfRecords; z++)
                    {
                        string genre = generator.Next(5, 11) % 2 == 0 ? "f" : "m";
                        int numberOfInterests = 0;
                        if (genre == "m")
                        {
                            numberOfInterests = generator.Next(1, interests.Length / 2);
                        }
                        else
                        {
                            numberOfInterests = generator.Next(1, i == 0 ? interests.Length / 4: i );
                        }
                        string personInterests = GenerateInterests(numberOfInterests);

                        writer.WriteLine(names2[z]);
                        writer.WriteLine(genre);
                        writer.WriteLine(numberOfInterests);
                        writer.WriteLine(personInterests);
                    }
                }
            }
        }

        private static string GenerateInterests(int length)
        {
            HashSet<string> resultInterests = new HashSet<string>();
            while (resultInterests.Count < length)
            {
                int index = generator.Next(0, interests.Length);
                string interest = interests[index];
                resultInterests.Add(interest);
            }

            return string.Join(" ", resultInterests);
        }


        private static string GenerateStringName(int length)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int indexLetter = generator.Next(0, alphabet.Length);
                word.Append(alphabet[indexLetter]);
            }

            return word.ToString();
        }
    }
}
