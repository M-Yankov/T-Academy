/**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace P18Emails
{
    class Extractor
    {
        static void Main()
        {
            Regex email = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}$");
            string input = Console.ReadLine();
            Match mat = email.Match(input);
            Console.WriteLine(mat.ToString());
        }
    }
}
