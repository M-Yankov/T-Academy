namespace KeyValuePairStructure
{
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            HashTable<string, int> pairs = new HashTable<string, int>();
            pairs.Remove("9Ivan 3");

            for (int i = 0; i < 12; i++)
            {
                pairs.Add((i * i) + "Ivan " + i, 2 * i);
            }

            foreach (var item in pairs)
            {
                System.Console.WriteLine("Key: {0} Value: {1}", item.Key, item.Value);
            }

            var a = pairs.Keys;
            System.Console.WriteLine(a.Count);
        }
    }
}
