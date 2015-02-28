/*Problem 20. Palindromes

    Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20Palindromes
{
    class Palindrome
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Stack<char> myStack = new Stack<char>();            // нов стек
            //polindrom rotor, "Гол аналог"
            string input = Console.ReadLine();
            string str = input.ToLower();              // присвояване на думата в променливата str само с малки букви
            
            List<char> myList = new List<char>();               // нов списък(колекция)
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' '|| str[i] == ',' || str[i] == '!' || str[i] == '.')
                {
                    continue;
                }
                myList.Add(str[i]);                             // добавяне на думата буква по буква в списъка без разтоянията(шпациите)
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || str[i] == ',' || str[i] == '!' || str[i] == '.')
                {
                    continue;
                }
                myStack.Push(str[i]);                           // добавяне на думата буква по буква в стека без разстоянията(шпациите)
            }
            bool polindrom = true;                              // променлива от тип bool
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] != myStack.Pop())
                {
                    Console.Clear();
                    Console.WriteLine("Word {0} is NOT palindrom!", input); // Ако буквите са различни се изписва този текст 
                    polindrom = false;                                                      // тази променлива става лъжа
                    break;              // и се прекъсва цикъла
                }
            }
            if (polindrom)
            {
                Console.WriteLine("Word {0} is Palindrome !", input);  // Ако всичко е точно се изписва това
            }// Copy - Paste from homeworks from my univerccity
        }
    }
}
