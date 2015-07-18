/*Task 1. Quality Methods
    Take the VS solution Methods and refactor its code to follow the guidelines of high-quality methods.
    Ensure:
        you handle errors correctly
            when the methods cannot do what their name says, throw an exception (do not return wrong result).
        good cohesion and coupling
        good naming
        no side effects, etc.
 * 
 * About styleCop - it's good, but when parameters are on separate lines, it wants first parameter to be on the next line - it's bullshits!
 * It's ugly like that 
 *      private static void TestMethod(
 *                                      int firstParam,
 *                                      int secondParam,
 *                                      int lastParam)
        {
 *      }
*/
namespace QualityMethods
{
    using System;

    public class Methods
    {
        private static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("All sides should be positive!");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));

            return area;
        }

        private static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid number!";
            }
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Please add some parameters.");
            }

            int maxValue = int.MinValue;

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        private static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    break;
            }
        }

        private static double CalcDistance(Point startPoint, Point endPoint)
        {
            double firstPointX = startPoint.X;
            double firstPointY = startPoint.Y;
            double secondPointX = endPoint.X;
            double secondPointY = endPoint.Y;

            double distance = Math.Sqrt((secondPointX - firstPointX) * (secondPointX - firstPointX) +
                                        (secondPointY - firstPointY) * (secondPointY - firstPointY));

            return distance;
        }

        private static bool IsHorizontal(Point firstPoint, Point secondPoint)
        {
            return firstPoint.Y == secondPoint.Y;
        }

        private static bool IsVertical(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X == secondPoint.X;
        }

        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Point firstPoint = new Point(3, -1);
            Point secondPoint = new Point(3, 2.5);

            Console.WriteLine(CalcDistance(firstPoint, secondPoint));
            Console.WriteLine("Horizontal? " + IsHorizontal(firstPoint, secondPoint));
            Console.WriteLine("Vertical? " + IsVertical(firstPoint, secondPoint));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia";
            peter.BornDate = new DateTime(1992, 3, 17);

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results";
            stella.BornDate = new DateTime(1993, 11, 3);

            Console.WriteLine("{0} older than {1} -> {2}",
                               peter.FirstName, 
                               stella.FirstName, 
                               peter.IsOlderThan(stella));
        }
    }
}