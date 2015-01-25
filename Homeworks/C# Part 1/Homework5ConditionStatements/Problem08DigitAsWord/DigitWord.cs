/*Problem 8. Digit as Word

    Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
        Print “not a digit” in case of invalid input.
        Use a switch statement.

 */
using System;

namespace Problem08DigitAsWord
{
    class DigitWord
    {
        static void Main()
        {
            while (true) //endless loop. Can escape from it with (Ctrl + C)
            {
                Console.Write("Enter a number from 1 to 9: ");
                string number =Console.ReadLine();
                switch (number)
                {
                    case "0":
                        Console.WriteLine(number + " zero"); break;
                    case "1":
                        Console.WriteLine(number + " one");break;
                    case "2":
                        Console.WriteLine(number + " two");break;
                    case "3":
                        Console.WriteLine("{0} three",number);break;
                    case "4":
                        Console.WriteLine("{0} four",number);break;
                    case "5":
                        Console.WriteLine("{0} five",number);break;
                    case "6":
                        Console.WriteLine("{0} six",number);break;
                    case "7":
                        Console.WriteLine("{0} seven",number);break;
                    case "8":
                        Console.WriteLine("{0} eight",number);break;
                    case "9":
                        Console.WriteLine("{0} nine",number);break;
                    default:
                        Console.WriteLine("Not a digit."); break;
                }
            }
        }
    }
}
