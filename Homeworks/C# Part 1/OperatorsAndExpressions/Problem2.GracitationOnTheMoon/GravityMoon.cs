/*
 * Problem 2. Gravitation on the Moon

    The gravitational field of the Moon is approximately 17% of that on the Earth.
    Write a program that calculates the weight of a man on the moon by a given weight on the Earth.

 * */
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Enter your weight: ");
        double weight = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture); // Can enter double values with dot like 23.334
        weight = (weight * 17) / 100;
        Console.WriteLine("Your weight on the Moon will be: " + Math.Round(weight,3) + "Kg.");
    }
}

