using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static string alphabetLatin = "0abcdefghijklmnopqrstuvwxyz";
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\input.txt");
        Console.SetIn(reader);
        //int temp2 = alphabetLatin.IndexOf("z");
        string s = Console.ReadLine();
        string[] myArray = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder letters = new StringBuilder();
        int index = int.MaxValue;
        string temp = "";
        int a = 1;
        int counter = 0;
        while (counter < maxLenght(myArray))
        {

            for (int i = 0; i < myArray.Length; i++)
            {
                temp = myArray[i];
                index = myArray[i].Length - a;
                if (index < 0)
                {
                    continue;
                }
                letters.Append(temp[index]);
            }
            a++;
            counter++;
        }
        //temp = letters.ToString();



        MoveLetters(letters, index, temp);




    }
    static int maxLenght(string[] str)
    {
        int max = 0;
        foreach (var item in str)
        {
            if (item.Length > max)
            {
                max = item.Length;
            }
        }
        return max;
    }
    static void MoveLetters(StringBuilder letters, int index, string temp)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            index = alphabetLatin.IndexOf(letters[i].ToString().ToLower()) + i;
            if (index >= letters.Length)
            {
                index = index % letters.Length;
            }
            temp = letters[i].ToString();
            letters.Remove(i, 1);
            letters.Insert(index, temp);
            //letters[index] = temp[i];
        }
        temp = letters.ToString();
            Console.Write(temp);
    }
}

