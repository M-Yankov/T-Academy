using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class OMathProblem
{
    static List<string> letters = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };
    static void OldMainMethod()
    {
        string input = Console.ReadLine(); //"grrrr miao miao";
        string[] myArray = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Stack<int> numbers = new Stack<int>();

        List<long> sums = new List<long>();

        long sum = 0;
        foreach (var item in myArray)       // suming
        {
            for (int i = 0; i < item.Length; i++)
            {
                int temp = letters.IndexOf(item[i].ToString());
                numbers.Push(temp);
            }
            int counter = 0;
            while (numbers.Count != 0)
            {
                if (counter == 0)
                {
                    sum += numbers.Pop();
                }
                else
                {
                    sum += numbers.Pop() * (long)Math.Pow(19, counter);

                }
                counter++;
            }
            sums.Add(sum);
            sum = 0;
        }

        numbers.Clear(); // principno e izlishno
        long result = sums.Sum();
        long final = result;
        // convert to animal system
        int tempo;
        while (result >= 19) // to check = 
        {
            tempo = (int)result % 19;
            result /= 19;
            numbers.Push(tempo);
        }
        numbers.Push((int)result);

        StringBuilder strBuild = new StringBuilder();
        while (numbers.Count != 0)
        {
            tempo = numbers.Pop();
            strBuild.Append(letters[tempo]);
        }

        Console.WriteLine("{0} = {1}", strBuild.ToString(), final);
        //Console.ReadLine();
    }
}
