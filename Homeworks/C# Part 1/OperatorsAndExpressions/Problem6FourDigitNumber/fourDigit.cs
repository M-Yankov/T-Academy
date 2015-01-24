/*
    Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
        Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
        Prints on the console the number in reversed order: dcba (in our example 1102).
        Puts the last digit in the first position: dabc (in our example 1201).
        Exchanges the second and the third digits: acbd (in our example 2101).

The number has always exactly 4 digits and cannot start with 0.*/

using System;


class fourDigit
{
    static void Main()
    {
        Console.Write("Enter Four digit number: ");
        string four = Console.ReadLine();
        if (four.Length < 4 || four.Length > 4)  //Validation for correct number Lenght
        {
            Console.WriteLine("###Error###\n\tTry again.");
            return; //This will cause exit from program
        }
        //string str = four.ToString();
        string substr1 = four.Substring(0, 1);  //I use again substringing for each digit
        string substr2 = four.Substring(1, 1);
        string substr3 = four.Substring(2, 1);
        string substr4 = four.Substring(3, 1);
        int sum = 0;
        sum += int.Parse(substr1) + int.Parse(substr2) + int.Parse(substr3) + int.Parse(substr4);
        Console.WriteLine("{0} + {1} + {2} + {3} = {4}", substr1, substr2, substr3, substr4, sum);
        //Console.WriteLine(Convert.ToString(four, 2).PadLeft(16 , '0'));
        string reversed = substr4 + substr3 + substr2 + substr1;
        Console.WriteLine("Reversed number: " + reversed);
        string lastDigitInFront = substr4 + substr1 + substr2 + substr3;
        Console.WriteLine("Last Digit in front: " + lastDigitInFront);
        string secondAndThirdExchanged = substr1 + substr3 + substr2 + substr4;
        Console.WriteLine("Second and third digit exchanged: " + secondAndThirdExchanged);
    }
}

