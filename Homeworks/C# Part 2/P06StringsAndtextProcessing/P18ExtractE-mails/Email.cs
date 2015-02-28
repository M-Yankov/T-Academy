/*Problem 18. Extract e-mails

    Write a program for extracting all email addresses from given text.
    All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Email
{
    static void Main()
    {
        Console.Write("Input text: ");
        string input = Console.ReadLine();
        input += " ";
        StringBuilder some = new StringBuilder();
        int indexAT = 0;
        int i = 0;
        int space;
        int end;
        while (indexAT != -1)
        {
            indexAT = input.IndexOf("@", i);
            if (indexAT == -1)
            {
                break;
            }
            space = input.LastIndexOf(" ", indexAT);
            end = input.IndexOf(" ", indexAT);
            string a = input.Substring(space + 1, end - space);
            
            if (Correct(a))
            {
                some.Append(a);

            }
            i = end;
        }
        char[] arr = { ',', '!', '?' };
        
        foreach (var ch in arr)
        {
            
            some.Replace(ch, ' ');
            
        }
        Console.WriteLine(string.Join("", some)); //mail adresses
    }
    static bool Correct(string n)  // must fix code... because some mails are valid like: user@mail , @mail , @ , a@a.b  more time need ....
    {
        int maimynka = n.IndexOf("@");
        if (n[0] == ' ' || n[maimynka + 1] == ' ')
        {
            return false;
        }
        else if (n[n.Length - 1] == '.')
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
