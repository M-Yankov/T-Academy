namespace DictionaryTwoKeys
{
    using System;

    public class NoTimeForHomework
    {
        public static void Main()
        {
            BiDictionary<int, string, decimal> mixMash = new BiDictionary<int, string, decimal>();
            mixMash.Add(1, "DJ Ivan", 2.31M);
            mixMash.Add(5, "DJ Doncho", 91321.123M);
            mixMash.Add("DJ Dobry", 239401.233M);
            mixMash.Add(2, 2.31M);
            mixMash.Add("DJ LoopTheVoice", 3.14159M);

            Console.WriteLine("{0:C2}", mixMash["DJ Dobry"]);
            Console.WriteLine("{0:C2}", mixMash[5]);
            Console.WriteLine("{0:C2}", mixMash[7]);
        }
    }
}
