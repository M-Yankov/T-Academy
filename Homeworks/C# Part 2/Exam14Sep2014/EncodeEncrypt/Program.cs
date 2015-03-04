using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodingDecoding
{
    static string alphabetLatin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static string Encrypt(string mess, string cypher)
    {
        StringBuilder result = new StringBuilder();
        if (mess.Length >= cypher.Length)
        {

            for (int i = 0, j = 0; i < mess.Length; i++, j++)
            {
                if (j == cypher.Length)
                {
                    j = 0;
                }
                int a = alphabetLatin.IndexOf(mess[i]);
                int b = alphabetLatin.IndexOf(cypher[j]);
                int temp = a ^ b;
                temp = temp + 'A'; // + 65 
                result.Append(Convert.ToChar(temp));
            }

        }
        else //if (mess.Length < cypher.Length)
        {
            bool passed = false;
            for (int j = 0, i = 0; j < cypher.Length; j++, i++)
            {
                if (i == mess.Length)
                {
                    i = 0;
                    mess = result.ToString();
                    //result.Clear();
                    passed = true;
                }
                int a = alphabetLatin.IndexOf(mess[i]);
                if (a < 0)
                {
                    a = (char)mess[i] - 'A'; /// Никъде в условието не пише че трябва да вадим от кода на буквата 'А'
                }
                int b = alphabetLatin.IndexOf(cypher[j]);
                int temp = a ^ b;
                temp = temp + 'A';
                if (passed)
                {
                    result[i] = (Convert.ToChar(temp));
                }
                else
                {
                    result.Append(Convert.ToChar(temp));

                }
            }
        }

        return result.ToString();
    }

    static string Encode(string srt) //ABBAABBBBBBARRRRRRRRAAAAAa
    {                                //ABBAA6BARRRRRRRRAAAAA
        StringBuilder result = new StringBuilder();
        result.Append(srt);

        StringBuilder newstrBulinder = new StringBuilder();

        char temp = ' ';
        int counter = 1;
        for (int i = 0; i < result.Length; i++)
        {
            if (temp == result[i])
            {
                counter++;
                if (i == result.Length - 1 && counter > 2) 
                {

                    string zipped = counter + temp.ToString();
                    newstrBulinder.Insert(i - counter, counter.ToString());
                    //newstrBulinder.Append(zipped);
                   //Replaceing(result, temp ,counter);
                   //i = i - counter ;
                }
            }
            else
            {
                if (counter > 2)
                {
                    
                    //Replaceing(result, temp, counter);
                    //i = i - counter - 31;


                    string zipped = counter + temp.ToString();
                    newstrBulinder.Append(zipped);
                    counter = 1;
                }
                else
                {

                    newstrBulinder.Append(result[i]);


                    temp = result[i];
                    counter = 1;
                }
            }
        }

        return newstrBulinder.ToString(); //result to string


    }

    static void Replaceing(StringBuilder result, char temp , int counter)
    {
        string neshto = new string(temp, counter);
        string newNeshto = counter + temp.ToString();
        result.Replace(neshto, newNeshto);
    }

    static void Main()
    {

        string input = "JOHNY";// Console.ReadLine();
        string cipher = "DEPPP"; //Console.ReadLine();
        //int temp23 = alphabetLatin.IndexOf("z");

        // P = 80  // cool using Ctrl And Space adding whole name when intelisence is hiden 
        string res =  Encode(Encrypt(input, cipher) + cipher) + cipher.Length;
        
        Console.WriteLine(res);
        //StreamWriter writer = new StreamWriter("..\\..\\results.txt");
        //using (writer)
        //{
        //   writer.Write(res);
        //}
    }
}
