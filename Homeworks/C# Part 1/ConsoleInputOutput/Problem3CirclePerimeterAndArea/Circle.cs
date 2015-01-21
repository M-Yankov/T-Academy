/*Problem 3. Circle Perimeter and Area

    Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

 * 
 */

using System;
using System.Globalization;
using System.Text;

    class Circle
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Enter radius of the circle: ");
            double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Perimeter of circle is: {0:F2}cm \nArea of circle is: {1:F2}cm\u00B2", radius * 2 * Math.PI, radius * radius * Math.PI);
        }
    }
