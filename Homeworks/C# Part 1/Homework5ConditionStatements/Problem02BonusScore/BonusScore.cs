/*5.5 	4.5 	4.5 5.5
Problem 2. Bonus Score

    Write a program that applies bonus score to given score in the range [1…9] by the following rules:
        If the score is between 1 and 3, the program multiplies it by 10.
        If the score is between 4 and 6, the program multiplies it by 100.
        If the score is between 7 and 9, the program multiplies it by 1000.
        If the score is 0 or more than 9, the program prints “invalid score”.

*/
using System;


class BonusScore
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter integer score: ");
            int score = int.Parse(Console.ReadLine());
            switch (score)
            {
                case 1:                     //from 1-3 *10 
                case 2:
                case 3:
                    score *= 10; Console.Write("Score | Result\n");
                        Console.Write(score/10+ "\t" +score + "\n"); break;     
                case 4:                     //from 4-6 *100
                case 5:
                case 6:
                    score *= 100; Console.Write("Score | Result\n");
                        Console.Write(score/100 + "\t" +score + "\n"); break;
                case 7:                     //from 7-9 *1000
                case 8:
                case 9:
                    score *= 1000; 
                    Console.Write("Score | Result\n");
                        Console.Write(score/1000 + "\t" +score + "\n"); break;
                default: Console.WriteLine("Invalid score"); break; //else Error message
            }
            
        }
    }
}

