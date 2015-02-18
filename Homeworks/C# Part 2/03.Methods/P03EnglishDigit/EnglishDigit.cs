/*Problem 3. English digit

    Write a method that returns the last digit of given integer as an English word.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EnglishDigit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Last digit of {0} is {1}.",number,Word(number));
    }
    static string Word(int a)
    {
        int b = a % 10;
       switch(b)
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
           default: return "not a number!";
       }
    }
}

