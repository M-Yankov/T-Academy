namespace CSharpExam1.RefactoredSolutions
{
    using System;

    class RefactoredDecoding
    {
        const int NUMBER_FOR_LETTER = 1000;
        const int NUMBER_FOR_DIGIT = 500;
        const int ONE_HUNDRED = 100;

        static void ToBeMain()
        {
            int theSaltNumber = int.Parse(Console.ReadLine());
            string theTextToConver = Console.ReadLine();
            string[] results = DecodeText(theSaltNumber, theTextToConver);

            PrintResults(results);
        }

        static string[] DecodeText(int saltNumber, string text)
        {
            string workingText = text.Replace("@", "");
            string[] decodedResults = new string[workingText.Length];

            for (int index = 0; index < workingText.Length; index++)
            {
                int charcode = (int)workingText[index];
                int decodedValue;

                if (Char.IsLetter(workingText[index]))
                {
                    decodedValue = (charcode * saltNumber) + NUMBER_FOR_LETTER;
                }
                else if (Char.IsDigit(workingText[index]))
                {
                    decodedValue = charcode + saltNumber + NUMBER_FOR_DIGIT;
                }
                else
                {
                    decodedValue = charcode - saltNumber;
                }

                decodedResults[index] = CalculateDependIndex(index, decodedValue);
            }

            return decodedResults;
        }

        static string CalculateDependIndex(int index, double value)
        {
            string result;

            if (index % 2 == 0)
            {
                result = String.Format("{0:0.00}", value / ONE_HUNDRED);
            }
            else
            {
                result = String.Format("{0}", value * ONE_HUNDRED);
            }

            return result;
        }

        static void PrintResults(string[] decodes)
        {
            foreach (string decodedValue in decodes)
            {
                Console.WriteLine(decodedValue);
            }
        }
    }
}
