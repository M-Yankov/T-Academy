/*Problem 5. Third Digit is 7?

    Write an expression that checks for given integer if its third digit from right-to-left is 7.
*/

using System;


class ThirdDigitSeven
{
    static void Main(string[] args)
    {
        int numberint = 86443711;
        Console.WriteLine(numberint);
        string s = numberint.ToString();    // converting to string
        string sub = s.Substring(s.Length - 3, 1);   // make a substring from "numberint" that takes third digit from right-to-left
        bool isSeven = (Convert.ToInt16(sub) == 7); // bool expression
        Console.WriteLine(isSeven);   // output result
        Console.Write("Enter integer number that third digit is 7 from right-to-left: ");
        int number = int.Parse(Console.ReadLine());
        string str = number.ToString();
        bool isItSeven;
        if (str.Length >= 3)
        {
            string newsub = str.Substring(str.Length - 3, 1); // make a substring from numebr
            isItSeven = (Convert.ToInt32(newsub) == 7);
        }
        else
        {
            isItSeven = false;
        }
        Console.WriteLine(isItSeven);
    }
}

