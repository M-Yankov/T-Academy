using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Neutrons
{
    class Program
    {
        static void Main()
        {
            //StreamReader reader = new StreamReader("..\\..\\input.txt");
            //Console.SetIn(reader);
            long input = 0;
            List<int> numbers = new List<int>();
            List<int> output = new List<int>();
            while (true)
            {
                input = long.Parse(Console.ReadLine());
                if (input == -1)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (((input >> i) & 1) == 1)
                        {
                            numbers.Add(i);
                        }
                    }
                    //foreach (int i in numbers)
                    //{
                    //    Console.Write(i + " ");
                    if (numbers.Count > 2)                         //-------------- new added
                    {
                        for (int p = numbers.Count - 1; p > 1; p--)
                        {
                            if (numbers[p] - numbers[p - 1] == 1)
                            {
                                numbers.RemoveAt(p);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int m = 0; m < numbers.Count -1 ; m++)
                        {
                            if (numbers[m] - numbers[m + 1] == -1)
                            {
                                numbers.RemoveAt(m);
                                m = -1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }                                                    //--------------
                    //}
                    int lenght = 0;
                    if (numbers.Count == 2)
                    {
                        if (numbers[0] - numbers[1] == 1)
                        {
                            numbers.Clear();
                            output.Add(0);
                        }
                        lenght = numbers[1] - numbers[0] - 1;
                        int mask = (int)Math.Pow(2, lenght) - 1;
                        int convertnum = mask << numbers[0] + 1;
                        output.Add(convertnum);
                        numbers.Clear();
                    }
                    else
                    {
                        numbers.Clear();
                        output.Add(0);
                    }

                }
            }
            foreach (int f in output)
            {
                Console.WriteLine(f);
            }
        }
    }
}