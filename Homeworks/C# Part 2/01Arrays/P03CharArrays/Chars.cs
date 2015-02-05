/*Problem 3. Compare char arrays

    Write a program that compares two char arrays lexicographically (letter by letter).
 */


using System;


    class Chars
    {
        static void Main( )
        {
            Console.Write("Enter first char array like a text on one line: ");
            string first = Console.ReadLine().TrimEnd(); //delete spaces afet last symbol
            Console.Write("Enter second char array like a text on one line: ");
            string second = Console.ReadLine().TrimEnd();
            char[] myCharArray = first.ToCharArray();
            char[] mySecondArray = second.ToCharArray();
            bool result = true;
            if(myCharArray.Length != mySecondArray.Length)
            {
                Console.WriteLine("Length of text strings are different. So they can't be equal");
            }
            else
            {
                for (int i = 0; i < myCharArray.Length; i++)
                {
                    if (myCharArray[i] != mySecondArray[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            if(result)
            {
                Console.WriteLine("The two strings are equal!");
            }
            else
            {
                Console.WriteLine("Not equal!");
            }
        }
    }

