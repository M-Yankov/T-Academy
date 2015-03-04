using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {                                           //0      1       2       3       4        5     6         7      8       9       10      11      12      13      14
        string[] zergMessages = new string[] { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
        string s = "GruhGruhGruhGruhGruhGruhGruhGruhGruh";
        //long a = 38443359374;
        List<int> numbers = new List<int>();
        string temp;
        int startINdex = s.Length;
        while (startINdex != 0)
        {
            startINdex -= 4;
            temp = s.Substring(startINdex, 4);
            numbers.Add(GetIndex(temp, zergMessages));
        }
        long sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i == 0)
            {
            sum += numbers[i];
                
            }
            else
            {
                sum += numbers[i] * (long)Math.Pow(15, i);
            }
           
        }
        Console.WriteLine(sum);
    }
    static int GetIndex(string text, string[] arr)
    {
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (text == arr[i])
            {
                index = i;
                break;
            }
        }
        return index;
    }

}