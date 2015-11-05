using System.Collections.Generic;
namespace KeyValuePairStructure
{
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            LinkedList<KeyValuePair<int, int>>[] arr = new LinkedList<KeyValuePair<int, int>>[16];
            arr[8] = new LinkedList<KeyValuePair<int, int>>();
            System.Console.WriteLine(arr[8] == null);


            HashTable<string, int> pairs = new HashTable<string, int>();

            for (int i = 0; i < 128; i++)
            {
                pairs.Add(i * i + "Ivan " + i, 2 * i);
            }

            int result = pairs.Find("9Ivan 3");
            
            System.Console.WriteLine(result); 
        }
    }
}
