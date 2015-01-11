/*Problem 12. Null Values Arithmetic

    Create a program that assigns null values to an integer and to a double variable.
    Try to print these variables at the console.
    Try to add some number or the null literal to these variables and print the result.
*/

using System;


namespace NullValuesArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            int? nullinteger = null;
            Console.WriteLine("This is null interer ->" + nullinteger);
            nullinteger = 9;
            Console.WriteLine("This is integer with value of number nine: ->" + nullinteger);
            double? nullDouble = null;
            Console.WriteLine("This is double with null value ->" + nullDouble);
            nullDouble = 74.54;
            Console.WriteLine("This is double with some value ->" + nullDouble);
        }
    }
}
