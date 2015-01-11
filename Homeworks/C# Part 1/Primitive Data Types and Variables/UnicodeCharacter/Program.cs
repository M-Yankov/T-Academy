using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
           char symbol = '\u002A' ;
           Console.WriteLine("Code of symbol is: " + (int)symbol);
        }
    }
}
