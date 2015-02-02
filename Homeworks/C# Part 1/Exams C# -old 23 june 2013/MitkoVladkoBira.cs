using System;
class Piyanici
{
    static void Main()
    {
        int round = int.Parse(Console.ReadLine());
        int drunkenNumber = 0;  
        string input;
        int lenghtt = 0;
        int mitko = 0;
        int vladko = 0;
        for (int i = 0; i < round; i++)
        {
            drunkenNumber = Math.Abs(int.Parse((Console.ReadLine())));
            lenghtt = drunkenNumber.ToString().Length;
            if (lenghtt % 2 == 0)  // 1234
            {
                for (int z = 0; z < lenghtt / 2; z++)
                {
                    vladko += drunkenNumber % 10;
                    drunkenNumber /= 10;
                }
                for (int p = 0; p < lenghtt / 2; p++)
                {
                    mitko += drunkenNumber % 10;
                    drunkenNumber /= 10;
                }
            }
            else //12345
            {
                for (int y = 0; y < (lenghtt/2) +1; y++)
                {
                    vladko += drunkenNumber % 10;
                    if(y== lenghtt/2)
                    {
                        break;
                    }
                    drunkenNumber /= 10;
                }
                for (int t = 0; t < (lenghtt/2) +1; t++)
                {
                    mitko += drunkenNumber % 10;
                    drunkenNumber /= 10;
                }
            }

            //Console.WriteLine("Mitko: " + mitko);
            //Console.WriteLine("vladko " + vladko);
            
        }
        int differance;
        if(mitko > vladko)
        {
            differance = mitko - vladko;
            Console.WriteLine("M {0}",differance);
        }
        else if(vladko > mitko)
        {
            differance = vladko - mitko;
            Console.WriteLine("V {0}", differance);
        }
        else
        {
            differance = mitko + vladko;
            Console.WriteLine("No {0}",differance);
        }
        //Console.WriteLine("Mitko: " + mitko);
        //Console.WriteLine("vladko " + vladko);

    }

}