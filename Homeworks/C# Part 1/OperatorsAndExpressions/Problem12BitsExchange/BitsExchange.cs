/*
 * Problem 12. Extract Bit from Integer

    Write an expression that extracts from given integer n the value of given bit at index p.

 */

using System;


class BitsExchange
{
    static void Main() // Maybe this is not a problem from homeworks.... idk :D
    {
        int num = 180;
        Console.WriteLine("180 in bits " + Convert.ToString(num, 2));
        int mask = (1 << 3);
        Console.WriteLine("MASK            " + Convert.ToString(mask, 2));
        int gosho = mask & num;
        Console.WriteLine("Gosho         " + Convert.ToString(gosho, 2));
        gosho >>= 3;
        Console.WriteLine("Gosho            " + Convert.ToString(gosho, 2));
        int finale = num ^ gosho;
        Console.WriteLine("Finale      " + Convert.ToString(finale, 2));
    }
}
