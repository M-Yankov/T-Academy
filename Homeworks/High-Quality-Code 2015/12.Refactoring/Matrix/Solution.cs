namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Solution
    {
        static void Main()
        {
            Console.Write("Enter a length of a matrix: ");
            int number = -1;

            while (number == -1)
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number < 0 || 100 < number)
                {
                    Console.Clear();
                    Console.Write("Try again: ");
                    number = -1;
                }
            }

            SquareMatrix matrix = new SquareMatrix(number);
            matrix.TraverseMatrix();

            Console.WriteLine(matrix.Print());
            matrix.RecordToTextFile();
        }
    }
}

