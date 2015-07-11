namespace MethodPrintStatistics
{
    using System;

    public class Statistics
    {
        internal void PrintStatistics(double[] collection)
        {
            double maxValueOfCollection = double.MinValue;
            double minValueOfCollection = double.MaxValue;
            double sumOfAllElements = 0;
            double averageValueOfCollection;

            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] > maxValueOfCollection)
                {
                    maxValueOfCollection = collection[i];
                }

                if (collection[i] < minValueOfCollection)
                {
                    minValueOfCollection = collection[i];
                }

                sumOfAllElements += collection[i];
            }

            averageValueOfCollection = sumOfAllElements / collection.Length;

            PrintMax(maxValueOfCollection);
            PrintMin(minValueOfCollection);
            PrintAvg(averageValueOfCollection);
        }

        private void PrintMax(double maxValueOfCollection)
        {
            Console.WriteLine("The maximum value is: {0}", maxValueOfCollection);
        }

        private void PrintMin(double minValueOfCollection)
        {
            Console.WriteLine("The minimum value is: {0}", minValueOfCollection);
        }

        private void PrintAvg(double averageValueOfCoolection)
        {
            Console.WriteLine("The average value is: {0}", averageValueOfCoolection);
        }
    }
}
