namespace CompareTasks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Task 2. Compare simple Maths
    ///
    /// Write a program to compare the performance of:
    ///    add, subtract, increment, multiply, divide
    /// for the values:
    ///    int, long, float, double and decimal 
    /// </summary>
    internal class ComaringMathMethods
    {
        private static void DisplayExecutionTime(Action function)
        {
            Stopwatch mesurement = new Stopwatch();
            mesurement.Start();
            function();
            mesurement.Stop();
            Console.WriteLine(mesurement.Elapsed);
        }

        private static void SampleMathOperations<T>(T operateValue)
        {
            T result = default(T);
            int cyclesCount = 1000000;

            Console.Write("\tAdding   \t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < cyclesCount; i++)
                {
                    // hack
                    result += (dynamic)operateValue;
                }
            });

            Console.Write("\tSubtracting \t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < cyclesCount; i++)
                {
                    result -= (dynamic)operateValue;
                }
            });

            Console.Write("\tIncrement \t");
            DisplayExecutionTime(() =>
            {   
                dynamic a = (dynamic)result;

                for (int i = 0; i < cyclesCount; i++)
                {
                    a++;
                }
            });

            Console.Write("\tMultiply \t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < cyclesCount; i++)
                {
                    result *= (dynamic)operateValue;
                }
            });

            Console.Write("\tDivide: \t");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < cyclesCount; i++)
                {
                    result /= (dynamic)operateValue;
                }
            });
        }

        static void Main()
        {
            Console.WriteLine("Integer operations:");
            int operateWithIntegerValue = 200;
            SampleMathOperations(operateWithIntegerValue);
            //Console.WriteLine("\tSecond time calling method.");
            //SampleMathOperations(operateWithIntegerValue);

            Console.WriteLine("Long operations:");
            long operateWithLongValue = 22;
            SampleMathOperations(operateWithLongValue);
            //Console.WriteLine("\tSecond time calling method");
            //SampleMathOperations(operateWithLongValue);

            Console.WriteLine("Float operations:");
            float opeatateWithFloatValue = 0.999939419515943565343543251263234345546363f;
            SampleMathOperations(opeatateWithFloatValue);
            //Console.WriteLine("\tSecond time calling method");
            //SampleMathOperations(opeatateWithFloatValue);

            Console.WriteLine("Double operations: with Math.PI");
            double operateWithDoubleValue = Math.PI;
            SampleMathOperations(operateWithDoubleValue);
            //Console.WriteLine("\tSecond time calling method");
            //SampleMathOperations(operateWithDoubleValue);

            Console.WriteLine("Decimal operation");
            decimal operateWithDecimalValue = -9788.098020494958283993m;
            SampleMathOperations(operateWithDecimalValue);
            //Console.WriteLine("\tSecond time calling method");
            //SampleMathOperations(operateWithDoubleValue);
        }
    }
}
