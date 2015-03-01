/*Problem 2. Enter numbers

    Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
        If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Numbers
{
    static List<int> ReadNumber(int start, int end)
    {
        List<int> numbers = new List<int>();
        string errMess = String.Format("Your number must be in range {0} - {1}", start, end);
        int temp;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter index [{0}] number: ", i);
            temp = int.Parse(Console.ReadLine());

            if (temp < start || temp > end)
            {
                throw new ArgumentOutOfRangeException("",errMess);
            }
            else
            {
                if (i==0)
                {
                    numbers.Add(temp);
                }

                else if (numbers.Count != 0 && temp > numbers[i - 1])
                {
                    numbers.Add(temp);

                }
                else
                {
                    Console.WriteLine("Must be bigger than previous. Try again:");
                    i--;
                }
            }


        }
        return numbers;
    }
    static void Main()
    {
        int downBoundary = 1;
        int upBoundary = 100;
        List<int> nums = new List<int>();
        try
        {

           nums =  ReadNumber(downBoundary, upBoundary);
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Bad input!");
        }
        Console.WriteLine(string.Join(", " , nums));
    }
}
