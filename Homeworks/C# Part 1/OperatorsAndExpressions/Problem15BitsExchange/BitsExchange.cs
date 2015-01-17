/*Problem 15.* Bits Exchange

    Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

 */
using System;



class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter your number: ");
        uint num = uint.Parse(Console.ReadLine());
        //Console.WriteLine("Your number in bits " + Convert.ToString(num, 2).PadLeft(16, '0'));
        uint mask = 7;
        uint result1 = num & (mask << 3);
        result1 >>= 3;
        //Console.WriteLine("res1= " + Convert.ToString(result1, 2).PadLeft(16, '0'));
        uint result2 = num & (mask << 24);
        result2 >>= 24;
        //Console.WriteLine("res2= " + Convert.ToString(result2, 2).PadLeft(16, '0'));
        num &= ~(mask << 3);
        num &= ~(mask << 24);
        //Console.WriteLine("num= " + Convert.ToString(num,2).PadLeft(16,'0'));
        num |= (result2 << 3);
        num |= (result1 << 24);
        Console.WriteLine("Your numbe after bits exchange: " + num);


        //My socond method is below
        
        /*
        uint number = uint.Parse(Console.ReadLine());
        string textNumber = Convert.ToString(number, 2).PadLeft(32, '0');
        char[] masivFromSymbols =textNumber.ToCharArray();
        for (int i = 0; i < textNumber.Length; i++)
        {
            //masivFromSymbols[i] = textNumber[i];
            Console.Write(masivFromSymbols[i]);
            if (i == 7 || i == 15 || i == 23)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();

        Console.WriteLine("Lenght = {0}", masivFromSymbols.Length);
        char temp;
        for (int i = 0, k = masivFromSymbols.Length - 1; i < k; i++, k--)
        {
            temp = masivFromSymbols[i];
            masivFromSymbols[i] = masivFromSymbols[k];
            masivFromSymbols[k] = temp;
        }
        Console.WriteLine("reversed");
        for (int i = 0; i < masivFromSymbols.Length; i++)
        {
            Console.Write(masivFromSymbols[i]);

            if (i == 7 || i == 15 || i == 23)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
        char digitFirts;
        char digitSecond;
        char digitThird;

        for (int i = 0; i < masivFromSymbols.Length; i++)
        {
            if (i== 3)
            {
                digitFirts = masivFromSymbols[i];
                masivFromSymbols[i] = masivFromSymbols[24];
                masivFromSymbols[24] = digitFirts;
            }
            if (i== 4)
            {
                digitSecond = masivFromSymbols[i];
                masivFromSymbols[i] = masivFromSymbols[25];
                masivFromSymbols[25] = digitSecond;
            }
            if (i == 5)
            {
                digitThird = masivFromSymbols[i];
                masivFromSymbols[i] = masivFromSymbols[26];
                masivFromSymbols[26] = digitThird;
            }
        }
        Console.WriteLine("Exchanged bits");
        for (int i = 0; i < masivFromSymbols.Length; i++)
        {
            Console.Write(masivFromSymbols[i]);

            if (i == 7 || i == 15 || i == 23)
            {
                Console.Write(" ");
            }
        }
       
        Console.WriteLine();
        uint number2 = 0;
        for (int i = 0; i < masivFromSymbols.Length; i++)
        {
            
            number2 += (uint)((Math.Pow(2,i))*(int.Parse(masivFromSymbols[i].ToString())));
        }
        Console.WriteLine("number2= " + number2);////////////
        */
    }
}
