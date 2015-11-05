using System.Collections.Generic;
namespace KeyValuePairStructure
{
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            HashTable<string, int> pairs = new HashTable<string, int>();
            pairs.Remove("9Ivan 3");

            for (int i = 0; i < 12; i++)
            {
                pairs.Add(i * i + "Ivan " + i, 2 * i);
            }

            foreach (var item in pairs)
            {
                System.Console.WriteLine("Key: {0} Value: {1}", item.Key, item.Value);
            }


            var a = pairs.Keys;
            System.Console.WriteLine(a.Count);
            ////System.Console.WriteLine("Count before remove: {0}", pairs.Count);
            //pairs.Remove("9Ivan 3");
            ////System.Console.WriteLine("Count after remove: {0}", pairs.Count);

            //int index = pairs.GetHashCodeOfKey(new KeyValuePair<string, int>("9Ivan 3", 1).Key) % 256;

            //var obj = pairs["9Ivan 3"];
            //System.Console.WriteLine(obj);

            //pairs.Clear();

            //System.Console.WriteLine("Count after clear: {0}", pairs.Count);


        }
    }
}
