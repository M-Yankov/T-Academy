using System;
using System.Collections.Generic;
using System.Linq;


class SumOfDiff
{
    static void OLderMain()
    {
        //long a = 4000000000;
        string input = Console.ReadLine();
        long[] myArray = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
        List<long> differences = new List<long>();
        for (int i = 1; i < myArray.Length; i++)
        {
            long diff = Math.Abs(myArray[i] - myArray[i - 1]);
            if (diff % 2 == 0)
            {
                i++;
            }
            else
            {
                differences.Add(diff);
            }
        }
        Console.WriteLine(differences.Sum());
        //Console.ReadLine();
    }
}
