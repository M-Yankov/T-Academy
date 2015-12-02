namespace RepetingPattern
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length == 1)
            {
                Console.WriteLine(input);
                return;
            }

            string text = input + input;

            int[] failLinks = new int[input.Length + 1];

            failLinks[0] = -1;
            failLinks[1] = 0;

            for (int i = 1; i < input.Length; i++)
            {
                int j = failLinks[i];
                while (j >= 0 && input[i] != input[j])
                {
                    j = failLinks[j];
                }
            }

            int matched = 0;
            for (int i = 1; i < text.Length; i++)
            {
                while (matched >= 0 && text[i] != input[matched]) 
                {
                    matched = failLinks[matched];
                }

                matched++;

                if (matched == input.Length)
                {
                    Console.WriteLine(input.Substring(0 , i - input.Length + 1));
                    return;
                }
            }
        }
    }
}
