/*Problem 3. Range Exceptions

    Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].
    Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/

namespace P03RangeExeption
{
    using System;
    class MainMethod
    {
        static DateTime lowerBoundary = new DateTime(1980, 1, 1); 
        static DateTime uppedBoundary = new DateTime(2013, 12, 31);
        static int lowerIntBoundary = 1;
        static int uppedIntBoundary = 100;
        static void Main()
        {
            DateTime date = new DateTime(2013, 3, 31);
            Console.WriteLine("This date is {0:dd.MM.yyyy}" , date);
            Check(date);
            date =  date.AddYears(1);
            Console.WriteLine("Adding 1 year to this date.");
            try
            {

                Check(date);
            }
            catch (InvalidRangeException<DateTime> dataEx)
            {

                Console.WriteLine(dataEx.Message);
            }

            // Work with Integers
            int two = 2;
            Console.WriteLine("int = {0}",two);
            Check(two);
            two += 100;
            Console.WriteLine("Add 100 to this integer.");
            try
            {
                Check(two);
            }
            catch (InvalidRangeException<int> intEx)
            {

                Console.WriteLine(intEx.Message);  
            }

        }
        public static void Check<T>(T value)
        {
            switch (value.GetType().Name)
            {
                case "DateTime":
                    DateTime value1 = Convert.ToDateTime(value);
                    if (value1 > uppedBoundary || value1 < lowerBoundary)
                    {
                        throw new InvalidRangeException<DateTime>(lowerBoundary, uppedBoundary);
                    }
                    Console.WriteLine("Date is ok!");
                    break;
                case "Int32":
                    int valueInt32 = Convert.ToInt32(value);
                    if (valueInt32 < lowerIntBoundary || valueInt32 > uppedIntBoundary)
                    {
                        throw new InvalidRangeException<int>(" My message" ,lowerIntBoundary, uppedIntBoundary);
                    }
                    Console.WriteLine("Ineger is ok!");
                    break;
                default:
                    break;
            }

        }
    }
}
