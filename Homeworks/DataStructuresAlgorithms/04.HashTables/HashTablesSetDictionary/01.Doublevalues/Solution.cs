namespace Doublevalues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helper;

    public class Solution
    {
        private const string StringFormatForResult = "│{0,-20}│{1,-20}│\n└{2}{3}{2}┘";

        public static void Main()
        {
            double[] arrayOfValues = new double[] { 0.09444, 3, 4, 4, -2.5, -3.14, 3, 4, 3, -2.5, 3, -3.14, 4, -2.5, 3, 3, 9, 3, -2.5, 3, 9, 9, -2.5, 3.123, 3.123, 9, 3, -3.14, 000.09444 };
            IDictionary<double, int> pairs = new Dictionary<double, int>();
            
            for (int i = 0; i < arrayOfValues.Length; i++)
            {
                if (pairs.ContainsKey(arrayOfValues[i]))
                {
                    pairs[arrayOfValues[i]]++;
                }
                else
                {
                    pairs.Add(arrayOfValues[i], 1);
                }
            }

            string result = Formater.FormatPairsForTemplate(StringFormatForResult, pairs);
            Console.WriteLine(result);
        }
    }
}
