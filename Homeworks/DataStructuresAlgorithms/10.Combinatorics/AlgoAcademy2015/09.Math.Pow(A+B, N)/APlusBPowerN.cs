namespace APlusBPowerNDefaultNameSpace
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// (A + B)^N = 
    /// Hint: http://www.sparknotes.com/math/algebra2/binomialexpansion/section2.rhtml
    /// </summary>
    public class APlusBPowerN
    {
        public static void Main()
        {
            string inputline = Console.ReadLine();

            //// Error in test format!
            Console.ReadLine();

            char firstDataMember = inputline[1];
            char secondDataMember = inputline[3];
            string theNumberOfThePowerOfTheDarkSideOfTheMoonWhere = Console.ReadLine().Trim();
            int power = int.Parse(theNumberOfThePowerOfTheDarkSideOfTheMoonWhere);

            PrintExtendedPolynom(firstDataMember, secondDataMember, power);
        }

        private static void PrintExtendedPolynom(char firstDataMember, char secondDataMember, int power)
        {
            List<string> polynoms = new List<string>();
            int length = power + 1;
            BigInteger factorielOfPower = Factorial(power);
            BigInteger[] factoriels = CalcFactorielsTo(power);

            for (int i = 0, fPow = power, sPow = 0; i < length; i++, fPow--, sPow++)
            {
                BigInteger coefficient = 1;

                if (fPow >= sPow)
                {                                                
                    coefficient = factorielOfPower / (factoriels[sPow] * factoriels[fPow]);
                }
                else
                {
                    coefficient = factorielOfPower / (factoriels[fPow] * factoriels[sPow]);
                }
               
                string coeffToString = coefficient <= 1 ? string.Empty : coefficient + string.Empty;
                string first = fPow == 0 ? string.Empty : "(" + firstDataMember + "^" + fPow + ")";
                string second = sPow == 0 ? string.Empty : "(" + secondDataMember + "^" + sPow + ")";
                string polynomString = coeffToString + first + second;

                polynoms.Add(polynomString);
            }

            string result = string.Join("+", polynoms);
            Console.WriteLine(result);
        }

        private static BigInteger Factorial(int number)
        {
            BigInteger result = 1;
            for (int i = 2; i <= number; i++)
            {
                result = result * i;
            }

            return result;
        }

        private static BigInteger[] CalcFactorielsTo(int toNumber)
        {
            BigInteger[] result = new BigInteger[toNumber + 1];
            result[0] = 1;

            for (int i = 1; i <= toNumber; i++)
            {
                result[i] = result[i - 1] * i;
            }

            return result;
        }
    }
}