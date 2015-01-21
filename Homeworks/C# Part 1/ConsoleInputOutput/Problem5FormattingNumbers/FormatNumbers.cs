/*Problem 5. Formatting Numbers

    Write a program that reads 3 numbers:
        integer a (0 <= a <= 500)
        floating-point b
        floating-point c
    The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
        The number a should be printed in hexadecimal, left aligned
        Then the number a should be printed in binary form, padded with zeroes
        The number b should be printed with 2 digits after the decimal point, right aligned
        The number c should be printed with 3 digits after the decimal point, left aligned.

 * 
 * */

using System;
using System.Globalization;



class FormatNumbers
{
    static void Main()
    {
        Console.Write("Enter value for A (0-500) = ");
        int numberA = int.Parse(Console.ReadLine());
        string hexNumA = numberA.ToString("X"); //Converting NumberA to hexadecimal format
        string binaryNumA = Convert.ToString(numberA, 2); //Convert NumberA to binary
        //-- 
        Console.Write("Enter value for floating-point B = ");
        float floatNumB = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); 
        int someint = (int)floatNumB / 1; //here I get whohe number  before decimal point from floatNumB
        int wholelenghtB = someint.ToString().Length; //I get the lenght of the whole number
        if (wholelenghtB > 7)
        {
            Console.WriteLine("Please enter number with lenght <=7 before decimal point.");
            return;
        }
        
        //--
        Console.Write("Enter value for floating-point C = ");
        float floatNumC = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        int newint = (int)floatNumC / 1;
        int wholelenght = newint.ToString().Length;
        if (wholelenght > 7) //because in the current problem we must use float numbers, so they aren't precision after 7th digit !
        {
            Console.WriteLine("Please enter number with lenght <=7 before decimal point.");
            return;//exit from program
        }
        
        for (int i = 1, k = 12; i <= 7; i++, k--)//It's complicated. I've made a loop that assign number from formula for padding bellow in code.*
        {

            if(i== wholelenghtB)
            {
                wholelenghtB = k; //assign necessary number.
                break; //exit from loop
            }
             
        }
        if (floatNumB < 0)
        {
            wholelenghtB--;
        }
        for (int i = 1, k = 11; i <= 7; i++, k--)
        {
            if (i == wholelenght)
            {
                wholelenght = k;
                break;
            } 

        }
        if (floatNumC < 0)
        {
           wholelenght--;
        }
        Console.WriteLine();
        Console.WriteLine("| A in hex | Binary A |    B     |     C    |");
        Console.WriteLine("|" + hexNumA.PadRight(10, '-') + "|" + binaryNumA.PadLeft(10, '0') + "|" +
             "{0:F2}".PadLeft(wholelenghtB, '-') + "|" + "{1:F3}".PadRight(wholelenght, '-') + "|", floatNumB, floatNumC); //I pad 'cells with '-' so it can be counted.


        /* *Detail explain: I made somthing like a formula for padding , because it can't be a constant number. 
         * We must make 'vurtual cells' that have exactly 10 chars weight. So in "{1:F2}" we have string with 6 chars but {1} may have more
         * depends of lenght of number(before decimal point). and if we enter 1234.3444 and pad right that number (PadRight(10,'-')) it will 
         * shows on the console like "1234.34-" This is not 10 characters. There is my formula:
         * |====================|===================|
         * |whole part lenght   | number for padding|
         * |--------------------|-------------------|
         * |    1               |   12              |
         * |    2               |   11              |
         * |    3               |   10              |
         * |    4               |   9               |
         * |    5               |   8               |
         * |    6               |   7               |
         * |    7               |   6               |
         * |====================|===================|
         * Examples:
         * 3.141592 //Whole part is with lenght 1 so number for padding must be 12
         * result: 3.14------
         * 999.32111 //whole part is with lenght 3 so number for padding must be 10
         * result: 999.32----
         * 42       //Whole part is with lenght 2 so number for padding = 11
         * result: 42.00----- <--this is about two digits after decimal point.
         * I hope you understand me :D
         */
    }
}

