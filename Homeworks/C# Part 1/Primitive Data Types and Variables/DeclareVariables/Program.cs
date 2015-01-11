/* Problem 1. Declare Variables
represent the following values: 52130, -115, 4 825 932, 97, -10 000  using:  byte, sbyte, short, ushort, int, uint, long, ulong */

using System;


namespace DeclareVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            byte varByte = 97;
            sbyte varSbyte = -115;
            short varShort = -10000;
            long varLong = 4825932;
            int varInt = 52130;
            Console.WriteLine("Byte  = {0} ;\nSbyte = {1} ;\nShort = {2} ;\nLong  = {3} ; \nInt   = {4};" ,varByte, varSbyte, varShort, varLong, varInt);
        }
    }
}
