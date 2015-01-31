/*
 * Problem 10. Odd and Even Product

    You are given n integers (given in a single line, separated by a space).                                          
    Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
    Elements are counted from 1 to n, so the first element is odd, the second is even, etc.*/
using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.IO;

    class OddAndEven
    {
        static void Main()
        {
            //StreamReader reader = new StreamReader("..\\..\\input.txt");   <-- If you don't know, with this two lines i can read from file called input.txt
            //Console.SetIn(reader);                                            <-- easy check

            char[] charsToTrim = { ' ' };
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.Write("Enter numbers separated by a space in a single line: ");
            string number = Console.ReadLine().TrimEnd(charsToTrim);        // :@ If you enter a spaces after last number this method deletes it.
            
            string[] splitedNums = number.Split(new Char[] { ' ' });
            double oddProduct = 1;                                          // Hint . when we must find product of numbers the variable must start with 1 . Not zero, because 0*n = 0
            double evenproduct = 1;
            for (int i = 0; i <= splitedNums.Length -1; i++)
            {
                if (i % 2 == 0)
                {
                    oddProduct *= double.Parse(splitedNums[i]);
                }
                else
                {
                    evenproduct *= double.Parse(splitedNums[i]);
                }
            }
            bool result = (oddProduct == evenproduct);
            if (result)
            {
                Console.WriteLine("Product = {0}", evenproduct);
                Console.WriteLine("Yes!");
            }
            else
            {
                Console.WriteLine("No!");
                Console.WriteLine("Odd_product = " + oddProduct);
                Console.WriteLine("Even_rpduct = " + evenproduct);
            }
        }
    }

