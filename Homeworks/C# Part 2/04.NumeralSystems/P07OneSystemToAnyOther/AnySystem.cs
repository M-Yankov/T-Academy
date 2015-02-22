using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01DecimalToBinary;
using P02;
using P03DectoHeX;
using P04HexToDec;
using P05hexadecimal;
using P06BinaryToHex;

namespace P07OneSystemToAnyOther
{
    class AnySystem
    {
        static void Main()
        {
            
            Console.WriteLine("1. Decimal to Binary");
            Console.WriteLine("2. Binary to Decimal");
            Console.WriteLine("3. Decimal to Hexadecimal");
            Console.WriteLine("4. Hexadecimal to Decimal");
            Console.WriteLine("5. Hexadecimal to Bin");
            Console.WriteLine("6. Binary to Hexadecimal");
            Console.WriteLine("What is your choice ? ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                DecToBin.Main();
            }
            else if (choice == 2)
            {
                BinaryDecimal.Main();
            }
            else if (choice == 3)
            {
                DecHex.Main();
            }
            else if (choice == 4)
            {
                HexDec.Main();

            }
            else if (choice == 5)
            {
                hexadecimal.Main();
            }
            else if(choice == 6)
            {
                BinToHex.Main();
            }
        }
    }
}
