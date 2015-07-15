using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Problem03
{
    static void OldMain()
    {
        //StreamReader reader = new StreamReader("..\\..\\enter.txt");
        //Console.SetIn(reader);
        int count = 0;
        List<long> numbers = new List<long>();
        List<long> products = new List<long>();
        string inputNum;
        for (int i = 0; ; i++)
        {
            inputNum = Console.ReadLine();
            if (inputNum == "END")
            {
                break;
            }
            long temp = long.Parse(inputNum);
            numbers.Add(temp);
            // If number is on odd position

            long product = 1;
            for (int z = 0; z < inputNum.Length; z++)
            {

                string sub = inputNum.Substring(z, 1);
                int currentDigit = Convert.ToInt32(sub);

                if (currentDigit == 0) // Think about it if number starts with 0 ????
                {
                    product = 1;
                    break;
                }
                else
                {
                    product *= currentDigit;
                }
                if (z == inputNum.Length - 1)
                {
                    products.Add(product);
                }
            }


        }
        long final = 1;

        if (products.Count < 10)
        {
            for (int s = 1; s < products.Count; s += 2)
            {
                final *= products[s];
            }
            Console.WriteLine(final);
        }
        else
        {
            long firstTen = 1;

        }
        //foreach (long num in oddNumbers)
        //{
        //    Console.WriteLine(num);
        //}
    }
}