namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Solver
    {
        public static void Main()
        {
//            StringReader reader = new StringReader(
//@"7
//p4 p2 p3 m1 k2 p1 k1");

//            Console.SetIn(reader);

            Queue<string> meditates = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();

            int length = int.Parse(Console.ReadLine());
            string[] warriors = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (warriors.Length != length)
            {
                throw new InvalidProgramException("Wrong algorithm");
            }

            for (int i = 0; i < length; i++)
            {
                switch (warriors[i][0])
                {
                    case 'k':
                        knights.Enqueue(warriors[i]);
                        break;
                    case 'p':
                        padawans.Enqueue(warriors[i]);
                        break;
                    case 'm':
                        meditates.Enqueue(warriors[i]);
                        break;
                    default:
                        throw new InvalidProgramException("Wrong algorithm");
                }
            }

            string result = string.Format("{0} {1} {2}", string.Join(" ", meditates), string.Join(" ", knights), string.Join(" ", padawans));
            Console.WriteLine(result);
        }
    }
}
