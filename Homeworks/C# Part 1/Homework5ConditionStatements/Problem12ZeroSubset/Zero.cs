/*
 * Problem 12.* Zero Subset

    We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
    Assume that repeating the same subset several times is not a problem.
*/
using System;
using System.Collections.Generic;
using System.Linq;


class Zero
{
    static void Main()
        {
            Console.WriteLine("Enter five numbers."); // nowhere says that number input must be on one line ( like: 1 2 3 4 ) 
            Console.Write("Enter a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter c = ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Enter d = ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter e = ");
            int e = int.Parse(Console.ReadLine());
            bool subset = false;
            List<int> numbers = new List<int> { a,b,c,d,e}; //It's a list
            
            if (a + b + c + d + e == 0)
            {
                Console.WriteLine("{0} + {0} + {0} +{0} + {0} = 0", a);
                subset = true;
            }
            else
            {
                for (int i = 0; i <= numbers.Count - 1; i++)
                {
                    
                    for (int k = i + 1; k <= numbers.Count - 1; k++)
                    {
                        if (numbers[i] + numbers[k] == 0)
                        {
                            Console.WriteLine("{0} + {1} = 0", numbers[i], numbers[k]);
                            subset = true;
                        }
                        for (int j = k + 1; j <= numbers.Count - 1; j++)
                        {
                            if (numbers[i] + numbers[k] + numbers[j] == 0)
                            {
                                Console.WriteLine("{0} + {1} + {2} = 0", numbers[i], numbers[k], numbers[j]);
                                subset = true;
                            }
                            for (int l = j + 1; l <= numbers.Count - 1; l++)
                            {
                                if (numbers[i] + numbers[k] + numbers[j] + numbers[l] == 0)
                                {
                                    Console.WriteLine("{0} + {1} + {2} + {3} = 0", numbers[i], numbers[k], numbers[j], numbers[l]);
                                    subset = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!subset)
            {
                Console.WriteLine("No zero subset!");        
            }
            
            // Sorry I don't have a time to fix all bugs ... :(
            // For an example a = 5; b = 0; c = -4; d =0; e= -1 ; 
            
            
        }
}

