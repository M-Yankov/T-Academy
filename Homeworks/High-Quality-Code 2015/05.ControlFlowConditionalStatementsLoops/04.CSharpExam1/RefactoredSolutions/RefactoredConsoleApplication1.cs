namespace CSharpExam1.RefactoredSolutions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;

    class RefactoredConsoleApplication1
    {
        static void AnotherMain()
        {
            List<string> inputNumbers = CollectNumbersFromInput();
            List<BigInteger> productsOfNumbers = CallculateSummaryProduct(inputNumbers);

            foreach (BigInteger number in productsOfNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static List<string> CollectNumbersFromInput()
        {
            string inputNumber = "";
            List<string> allNumbers = new List<string>();

            while (true)
            {
                inputNumber = Console.ReadLine();

                if (inputNumber == "END")
                {
                    break;
                }
                else
                {
                    allNumbers.Add(inputNumber);
                }
            }

            return allNumbers;
        }

        static List<BigInteger> CallculateSummaryProduct(List<string> allNumbers)
        {
            BigInteger productOfFirstTenNumbers = 1;
            BigInteger productOfRestnumbers = 1;
            List<BigInteger> productsOfNumbers = new List<BigInteger>(); 
            int lengthOfNumbers = allNumbers.Count;

            if (lengthOfNumbers <= 10)
            {
                productOfFirstTenNumbers = CalculateProductFromTo(allNumbers, 0, lengthOfNumbers);

                productsOfNumbers.Add(productOfFirstTenNumbers);
            }
            else
            {
                productOfFirstTenNumbers = CalculateProductFromTo(allNumbers, 0, 10);
                productOfRestnumbers = CalculateProductFromTo(allNumbers, 10, lengthOfNumbers);

                productsOfNumbers.Add(productOfFirstTenNumbers);
                productsOfNumbers.Add(productOfRestnumbers);
            }

            return productsOfNumbers;
        }

        static BigInteger CalculateProductFromTo(List<string> allNumbers, int startIndex, int endIndex)
        {
            BigInteger product = 1;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (i % 2 == 1)
                {
                    product *= Product(allNumbers[i]);
                }
            }

            return product;
        }

        // return product of "97741" something like that
        static BigInteger Product(string numberAsString)
        {
            BigInteger product = 1;

            if (0 == BigInteger.Parse(numberAsString))
            {
                return product;
            }

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int number = int.Parse(numberAsString[i].ToString());

                if (number == 0)
                {
                    continue;
                }

                product *= number;
            }

            return product;
        }
    }
}
