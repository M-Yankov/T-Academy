namespace CSharpExam1.MyOldSolutions
{
    using System;
    using System.Collections;
    using System.Linq;

    class RefactoredThreeNumbers
    {
        static void ToMain()
        {
            long[] numbers = new long[3];

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = long.Parse(Console.ReadLine());
            }

            long largestNumber = numbers.Max();
            long smallestNumber = numbers.Min();
            double averageNumber = double.Parse(numbers.Average().ToString());

            Console.WriteLine(largestNumber);
            Console.WriteLine(smallestNumber);
            Console.WriteLine("{0:0.00}", averageNumber);
        }
    }
}