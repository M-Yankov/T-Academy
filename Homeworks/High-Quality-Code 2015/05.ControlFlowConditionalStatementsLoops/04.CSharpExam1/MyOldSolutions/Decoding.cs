using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem2
{
    class Program
    {
        static void OldSolutionTask2()
        {
            //StreamReader reader = new StreamReader("..\\..\\inputdata.txt");
            //Console.SetIn(reader);
            int saltNumber = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();  // I@ 
            string sub;
            char ch;
            for (int i = 0; i < text.Length; i++)
            {
                sub = text.Substring(i, 1);
                ch = Convert.ToChar(sub);
                double charCode = (int)ch;
                if (sub == "@")
                {
                    break;
                }
                // Is BIgleter 
                if (charCode >= 65 && charCode <= 90)
                {
                    charCode = ((charCode * saltNumber) + 1000);

                }
                //is small digit
                else if (charCode >= 97 && charCode <= 122)
                {
                    charCode = ((charCode * saltNumber) + 1000);

                }
                //is digit 
                else if (charCode >= 48 && charCode <= 57)
                {
                    charCode = ((charCode + saltNumber) + 500);

                }
                //others
                else
                {
                    charCode = charCode - saltNumber;

                }
                if (i % 2 == 0)
                {
                    charCode /= 100;
                    Console.WriteLine("{0:0.00}", charCode);

                }
                else
                {
                    charCode *= 100;
                    Console.WriteLine("{0}", charCode);

                }

            }





            //{
            //    char pesho = '0';
            //    Console.WriteLine((int)pesho); // with this code we prints code character 
        }
    }
}
