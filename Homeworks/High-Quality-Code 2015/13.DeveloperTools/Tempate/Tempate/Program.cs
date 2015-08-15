using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Language studentMarks = new Language(1,2,3,5,6,7);
            
            Console.WriteLine(studentMarks.CSharp);
        }
    }
}
