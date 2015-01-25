/*Problem 4. Multiplication Sign

    Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
        Use a sequence of if operators.
spored tova kakvoto sum razbral tryabwa da se proveri dali umnojenieto na trite chisla dava znak + ili - bez da se presmyatat. Ako ima 0 saotvetno 0..... */

using System;
using System.Globalization;

class NekuvZnak
{
    static void Main()
    {
        Console.Write("Enter a = ");
        double numberA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter b = ");
        double numberB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter c = ");
        double numberC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        string result;
        bool zero = numberA == 0 || numberB == 0 || numberC == 0;
        bool allPlus = ((numberA > 0) && (numberB > 0) && (numberC > 0));
        bool abMinus = ((numberA < 0) && (numberB < 0) && numberC > 0);
        bool bcMinus = ((numberB < 0) && (numberC < 0) && numberA > 0);
        bool acMinus = ((numberA < 0) && (numberC < 0) && numberB > 0);
        if (zero)
        {
            result = "0";
        }
        else if (allPlus || abMinus || bcMinus || acMinus)
        {
            result = "+";
        }
        else
        {
            result = "-";
        }
        Console.WriteLine("{0}*{1}*{2}  result: {3}", numberA, numberB, numberC, result);
    }
}
