/*Problem 11.* Number as Words

    Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
*/

using System;



class NumbersWords
{
    static void Main()
    {

        string txt = "";
        string numb = (Console.ReadLine());
        int a = 0;

        try
        {
            a = int.Parse(numb);
        }
        catch (Exception)
        {
            Console.WriteLine("Not a number");
            return;
        }
        int twodigit = 0;
        if (a >= 0 && a < 100)
        {

            if (a >= 20)
            {
                switch (a / 10)
                {
                    case 2:
                        txt += "Twenty "; break;
                    case 3:
                        txt += "Thirty "; break;
                    case 4:
                        txt += "Fourty "; break;
                    case 5:
                        txt += "Fifty "; break;
                    case 6:
                        txt += "Sixty "; break;
                    case 7:
                        txt += "Seventy "; break;
                    case 8:
                        txt += "Eighty "; break;
                    case 9:
                        txt += "Ninety "; break;
                    default: break;
                }
                switch (a % 10)
                {
                    case 1:
                        txt += "one."; break;
                    case 2:
                        txt += "two."; break;
                    case 3:
                        txt += "three."; break;
                    case 4:
                        txt += "four."; break;
                    case 5:
                        txt += "five."; break;
                    case 6:
                        txt += "six."; break;
                    case 7:
                        txt += "seven."; break;
                    case 8:
                        txt += "eight."; break;
                    case 9:
                        txt += "nine."; break;
                    default: break;
                }
            }
            else
            {
                switch (a)
                {
                    case 0:
                        txt += "Zero."; break; //...
                    case 1:
                        txt += "One."; break;
                    case 2:
                        txt += "Two."; break;
                    case 3:
                        txt += "Three."; break;
                    case 4:
                        txt += "Four."; break;
                    case 5:
                        txt += "Five."; break;
                    case 6:
                        txt += "Six."; break;
                    case 7:
                        txt += "Seven."; break;
                    case 8:
                        txt += "Eight."; break;
                    case 9:
                        txt += "Nine."; break;
                    case 10:
                        txt += "Ten."; break;
                    case 11:
                        txt += "Eleven."; break;
                    case 12:
                        txt += "Tweve."; break;
                    case 13:
                        txt += "Thirteen."; break;
                    case 14:
                        txt += "Fourteen."; break;
                    case 15:
                        txt += "Fiveteen."; break;
                    case 16:
                        txt += "Sixteen."; break;
                    case 17:
                        txt += "Seventeen."; break;
                    case 18:
                        txt += "Eighteen."; break;
                    case 19:
                        txt += "Nineteen."; break;
                    default: break;
                }
            }
        }
        else if (a >= 100 && a < 1000) //-----------------------Hundreds
        {
            switch (a / 100)
            {
                case 1:
                    txt += "One hundred "; break;
                case 2:
                    txt += "Two hundred "; break;
                case 3:
                    txt += "Three hundred "; break;
                case 4:
                    txt += "Four hundred "; break;
                case 5:
                    txt += "Five hundred "; break;
                case 6:
                    txt += "Six hundred "; break;
                case 7:
                    txt += "Seven hundred "; break;
                case 8:
                    txt += "Eight hundred "; break;
                case 9:
                    txt += "Nine hundred "; break;
                default: break;
            }
            twodigit = a % 100;
            if (twodigit >= 20)
            {
                switch (twodigit / 10)
                {
                    case 2:
                        txt += "and twenty "; break;
                    case 3:
                        txt += "and thirty "; break;
                    case 4:
                        txt += "and fourty "; break;
                    case 5:
                        txt += "and fifty "; break;
                    case 6:
                        txt += "and sixty "; break;
                    case 7:
                        txt += "and seventy "; break;
                    case 8:
                        txt += "and eighty "; break;
                    case 9:
                        txt += "and ninety "; break;
                    default: break;
                }
                switch (twodigit % 10)
                {
                    case 1:
                        txt += "one."; break;
                    case 2:
                        txt += "two."; break;
                    case 3:
                        txt += "three."; break;
                    case 4:
                        txt += "four."; break;
                    case 5:
                        txt += "five."; break;
                    case 6:
                        txt += "six."; break;
                    case 7:
                        txt += "seven."; break;
                    case 8:
                        txt += "eight."; break;
                    case 9:
                        txt += "nine."; break;
                    default: break;
                }
            }
            else
            {
                switch (twodigit)
                {
                    /*case 0:
                        txt += "Zero."; break; //...*/
                    case 1:
                        txt += "and one."; break;
                    case 2:
                        txt += "and two."; break;
                    case 3:
                        txt += "and three."; break;
                    case 4:
                        txt += "and four."; break;
                    case 5:
                        txt += "and five."; break;
                    case 6:
                        txt += "and six."; break;
                    case 7:
                        txt += "and seven."; break;
                    case 8:
                        txt += "and eight."; break;
                    case 9:
                        txt += "and nine."; break;
                    case 10:
                        txt += "and ten."; break;
                    case 11:
                        txt += "and eleven."; break;
                    case 12:
                        txt += "and tweve."; break;
                    case 13:
                        txt += "and thirteen."; break;
                    case 14:
                        txt += "and fourteen."; break;
                    case 15:
                        txt += "and fiveteen."; break;
                    case 16:
                        txt += "and sixteen."; break;
                    case 17:
                        txt += "and seventeen."; break;
                    case 18:
                        txt += "and eighteen."; break;
                    case 19:
                        txt += "and nineteen."; break;
                    default: break;
                }
            }
        }
        else
        {
            Console.WriteLine("Only number in range 0...999!");
            return;
        }

        Console.WriteLine(a + " " + txt);

    }
}
