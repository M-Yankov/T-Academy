/*Problem 9. Play with Int, Double and String

    Write a program that, depending on the user’s choice, inputs an int, double or string variable.
        If the variable is int or double, the program increases it by one.
        If the variable is a string, the program appends * at the end.
    Print the result at the console. Use switch statement.

 * */

using System;
using System.Globalization;
using System.Windows.Markup;

class PlayVariables
{
    static void Main()
    {
        Console.WriteLine("Enter your type from list below: ");
        Console.WriteLine("1----> int");
        Console.WriteLine("2----> double");
        Console.WriteLine("3----> string");
        Console.SetCursorPosition(19, 2);
        int type = 0;

        try
        {
            type = int.Parse(Console.ReadLine());
        }
        catch(Exception) // If you try enter somethind like: "ou!@#!%TSDFE^2Dsa#35ASD23" this catch will helps to not break the program
        {

        }
        Console.SetCursorPosition(0, 4);
        int number = 0;
        double someValue = 0.0; // :D
        string txt = "";
        switch (type)
        {
            case 1:
                Console.Write("Please enter a integer: ");
                number = int.Parse(Console.ReadLine());
                number++;
                Console.WriteLine("Your number: {0}", number);
                break;
            case 2:
                Console.Write("Please enter a double value: ");
                 someValue = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                 someValue += 1; // I don't sure is good practice to increment double values ...
                 Console.WriteLine("Your nuymber: {0}", someValue);
                 break;
            case 3:
                 Console.Write("Enter some text: ");
                 txt = Console.ReadLine();
                Console.WriteLine(txt +"*"); break;
            default:
                Console.WriteLine("Incorrect input. Try with 1, 2, 3");break;
        }

    }
}
