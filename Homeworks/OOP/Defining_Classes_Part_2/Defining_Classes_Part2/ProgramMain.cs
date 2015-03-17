/*
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Part2
{
    class ProgramMain
    {
        static void Main(string[] args)
        {
            Point a = new Point(-1, 23, -4);
            Point b = new Point(4, 0, 4);
            Point c = new Point(5, 5, 1);
            Point d = new Point(-4, 1, 4);
            Point e = new Point(-9, -7, 0);
            Point f = new Point(11, -3, 11);
            Point g = new Point(10, 5, 9);
            Point h = new Point(0, 1, 5);
            List<Point> list = new List<Point>() { a, b, c, d, e, f, g, h };
            Path address = new Path();
            address.SequnecePoints = list;
            PathStorage.Save(address);

            List<Point> output = new List<Point>();
            Console.WriteLine("Trying to load contents from file");
            output = PathStorage.Load();
            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(new string('#',20));
            Console.WriteLine("# Using geretics!  #");
            Console.WriteLine(new string('#',20));
            Console.WriteLine();
            //Using generetics
            GenericList<int> myList = new GenericList<int>(5);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(5);
            myList.Add(5);
            myList.InsertAt(2, 8); //inserting 8 at middle of list
            var min = myList.Minimal();
            var max = myList.Maximal();
            Console.WriteLine("Min element is {0} at index {1}", min, myList.Finding(min));
            Console.WriteLine("Max element is {0} at index {1}", max, myList.Finding(max));

            myList.InsertAt(2, 3); // inserting 3 at 2 

            Console.WriteLine(myList);

            Console.Write("Search int item: "); // to repair insert method.
            int search = int.Parse(Console.ReadLine());
            int resulting = myList.Finding(search);
            if (resulting == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} not found!" , search);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Index of {0} is {1}", search, resulting);
                Console.ResetColor();
            }
            
            Console.WriteLine(myList);
            myList.Clear();
            Console.WriteLine("List is cleared");
            Console.WriteLine(myList);
            Matricata();

        }
        public static void Matricata()
        {
            Matrix<int> multyArr = new Matrix<int>(2, 2); // matrix a
            multyArr[0, 0] = 12;
            multyArr[0, 1] = 3;
            multyArr[1, 0] = 1;  
            multyArr[1, 1] = 5;
            Console.WriteLine("matrix a) \n" + multyArr);
            Matrix<int> multyArr2 = new Matrix<int>(2, 2);
            multyArr2[0, 0] = 9;
            multyArr2[0, 1] = -2;
            multyArr2[1, 0] = 5;
            multyArr2[1, 1] = 4;
            Console.WriteLine("matrix b) \n" + multyArr2);

            Console.WriteLine("Sum of a + b \n" + (multyArr + multyArr2));
            Console.WriteLine("Result of a - b \n" + (multyArr - multyArr2));
            Console.WriteLine("Result of b - a \n" + (multyArr2 - multyArr));
            if (multyArr) // if this matrix contains only non zero elements. // to see efect change some of values form multyArr to 0. 
            {
                Console.WriteLine("Result of a * b \n" +  (multyArr * multyArr2));
            }
            Matrix<float> floatArr = new Matrix<float>(3, 3);
            floatArr[0, 0] = 5.5F;
            floatArr[0, 1] = 3.152F;
            floatArr[0, 2] = 4.11F;
            floatArr[1, 0] = 0.314F;
            floatArr[1, 1] = 50.52F;
            floatArr[1, 2] = -5.22F;
            floatArr[2, 0] = -1.11F;
            floatArr[2, 1] = 5.15F;
            floatArr[2, 2] = 6.23F;
            Console.WriteLine("A float Matritx 3x3: \n" + floatArr);

            /* Matrix<string> stringArr = new Matrix<string>(2, 2);
            stringArr[0, 0] = "text";
            stringArr[0, 1] = "data";
            stringArr[1, 0] = "string";
            stringArr[1, 1] = "word";
            Console.WriteLine(stringArr); */
        }

        /*public void StringOperate()
        {
            GenericList<string> texts = new GenericList<string>();
            texts.Add("Ivan");
            texts.Add("Gosho");
            texts.Add("Pesho");
            texts.Add("Atanas");
            texts.Add("Strahil");
            texts.Add("Stamat");
            texts.Add("Bai Kolio");
            string value = "Atanas";
            int indexOfAtanas = texts.Finding(value);
            texts.RemoveAt(indexOfAtanas);
            Console.WriteLine("The list should not contains {0}" ,value);
            Console.WriteLine(texts);
        }*/
    }
}
