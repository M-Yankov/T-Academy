/*Problem 4. Triangle surface

    Write methods that calculate the surface of a triangle by given:
        Side and an altitude to it;
        Three sides;
        Two sides and an angle between them;
    Use System.Math.
*/
using System;
using System.Text;
using System.Globalization;
using System.Threading;

namespace P04TriangleSurface
{
    class TiangleProgmar
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(@"
      /\
      /|\
     / | \
    /  |  \
 c /   |ha \ b
  /    |    \
 / β   |     \
/_)____|______\
         a");
            Console.WriteLine("1.Side and an altitude to it");
            Console.WriteLine("2.Three sides");
            Console.WriteLine("3.Two sides and an angle between them");
            Console.WriteLine("How do you want to find surface?");
            int choice = int.Parse(Console.ReadLine());
            Triangle tester = new Triangle();                // new object from class Triangle
            double surface;
            if(choice == 1)
            {
                Console.Write("Enter side = ");
                tester.sideA = double.Parse(Console.ReadLine());
                Console.Write("Enter altitude to side = ");
                tester.altitude = double.Parse(Console.ReadLine());
                surface = tester.Surface1();
                Console.WriteLine("Surface is {0:0.00}cm\u00B2" , surface);
            }
            else if (choice == 2)
            {
                Console.Write("Enter a = ");
                tester.sideA = double.Parse(Console.ReadLine());
                Console.Write("Enter b = ");
                tester.sideB = double.Parse(Console.ReadLine());
                Console.Write("Enter c = ");
                tester.sideC = double.Parse(Console.ReadLine());
                surface = tester.Surface2();
                Console.WriteLine("Surface is {0:0.00}cm\u00B2", surface);

            }
            else if (choice == 3)
            {
                Console.Write("Enter first side = ");
                tester.sideA = double.Parse(Console.ReadLine());
                Console.Write("Enter second side = ");
                tester.sideB = double.Parse(Console.ReadLine());
                Console.Write("Enter angle between = ");
                tester.angle = double.Parse(Console.ReadLine());
                if (tester.angle > 179)
                {
                    Console.WriteLine("This is not na angle!");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                }
                surface = tester.Surface3();
                Console.WriteLine("Surface is {0:0.00}cm\u00B2", surface);
            }
            else
            {

                Console.WriteLine("Bad choice!!!");
                Console.ReadLine();
                Console.Clear();
                Main();
            }
        }
    }
    class Triangle
    {
       
        public double sideA { get; set; }
        public double sideB { get; set; }
        public double sideC { get; set; }
        public double altitude { get; set; }
        public double angle { get; set; }
        
        public double Surface1()   // (a * ha) /2 
        {
            double surface = (sideA * altitude) / 2;
            return surface;
        }
        public double Surface2()  // a b c 
        {
            double p = sideA + sideB + sideC;
            double surface = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            return surface;
        }
        public double Surface3()
        {
            angle = Math.Sin(angle);
            double surface = (sideA * sideB * angle) / 2;
            return surface;
        }
    }
}
