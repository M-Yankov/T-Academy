namespace Helper
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Formater
    {
        public static string FormatPairsForTemplate<TKey, Value>(string template, IDictionary<TKey, Value> pairsCollection)
             where Value : IComparable
        {
            StringBuilder result = new StringBuilder();

            string header = string.Format(template, "Value", "Times", new string('─', 20), "┴");
            result.AppendLine(header);
            pairsCollection.ToList().ForEach(pair => 
                {
                    string contentRow = string.Format(template, pair.Key, pair.Value, new string('─', 20), "┴");
                    result.AppendLine(contentRow);
                });

            return result.ToString();
        }
    }
}
