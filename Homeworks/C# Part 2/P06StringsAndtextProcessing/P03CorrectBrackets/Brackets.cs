/*Problem 3. Correct brackets

    Write a program to check if in a given expression the brackets are put correctly.

Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
 */
using System;


class Brackets
{
    static void Main()
    {
        Console.Write("Enter expresson: "); // "(a+b)-(a*(a-b)*(a-c)*(a*2))"
        string s = Console.ReadLine();
        int result = Correct(s);
        if (result == 0 && Check(s))
        {
            Console.WriteLine("{0} is correct format." ,s);
        }
        else
        {
            Console.WriteLine("{0} is NOT correct format.", s);
        }
    }
    static int Correct(string str)
    {
        int counter = 0;
        char[] arr = str.ToCharArray();
        foreach (var ch in arr)
        {
            if (ch == '(')
            {
                counter++;
            }
            else if (ch == ')' && counter != 0)
            {
                counter--;
            }
        }
        return counter;
    }
    static bool Check(string s)
    {
        if (s.IndexOf("(") > s.IndexOf(")"))
        {
            return false;
        }
        else
        {
            return true;

        }

    }

}
