namespace CompareAdvacedMath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Task 3. Compare advanced Maths
    /// 
    /// Write a program to compare the performance of:
    ///     square root, natural logarithm, sinus
    /// for the values:
    ///     float, double and decimal
    ///     
    /// </summary>
    class CompareAdvacedMathOperations
    {
        private static void DisplayExecutionTime(Action function)
        {
            Stopwatch mesurement = new Stopwatch();
            mesurement.Start();
            function();
            mesurement.Stop();
            Console.WriteLine(mesurement.Elapsed);
        }

        private static void AdvacedMathOperations<T>(T operationValue)
        {
            int countCycles = 1000000;
            double value = Convert.ToDouble(operationValue);

            Console.Write("\tSquare root  \t\t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < countCycles; i++)
                {
                    Math.Sqrt(value);
                }
            });

            Console.Write("\tNatural logarithm \t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < countCycles; i++)
                {
                    Math.Log(value);
                }
            });

            Console.Write("\tSinus\t\t\t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < countCycles; i++)
                {
                    Math.Sin(value);
                }
            });
        }

        static void Main()
        {
            float operateWithFloat = 981573.13455232314f;
            double operateWithDouble = Math.PI;
            decimal operateWithDecimal = 2364444.230643454044m;

            Console.WriteLine("Float");
            AdvacedMathOperations(operateWithFloat);
            Console.WriteLine("Double");
            AdvacedMathOperations(operateWithDouble);
            Console.WriteLine("Decimal");
            AdvacedMathOperations(operateWithDecimal);
        }
    }
}
