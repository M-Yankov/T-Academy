namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Rabbits
    {
        public static void Main()
        {

            var line = Console.ReadLine();
            var inputNumbers = line.Split(' ').Select(int.Parse).ToList();
            inputNumbers.RemoveAt(inputNumbers.Count - 1);

            var answer = MinRabbits(inputNumbers);
            Console.WriteLine(answer);
        }

        public static int MinRabbits(IList<int> answers)
        {
            Dictionary<int, int> groups = new Dictionary<int, int>();
            for (int i = 0; i < answers.Count; i++)
            {
                if (!groups.ContainsKey(answers[i] + 1))
                {
                    groups.Add(answers[i] + 1, 0);
                }

                groups[answers[i] + 1]++;
            }

            var result = 0;

            foreach (var group in groups)
            {
                var size = group.Key;
                var rabbitsInGroup = group.Value;

                int currentCount = (int)Math.Ceiling(rabbitsInGroup / (decimal)size);

                result += currentCount * size;
                
            }

            return result;
        }
    }
}
