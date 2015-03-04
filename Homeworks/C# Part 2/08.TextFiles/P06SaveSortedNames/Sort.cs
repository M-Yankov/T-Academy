using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Sort
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\input.txt");
        List<string> names = new List<string>();
        string name = "n";
        using (reader)
        {
            while (name != null)
            {
                name = reader.ReadLine();
                if (name == null)
                {
                    break;
                }
                names.Add(name);
            }
        }
        StreamWriter writer = new StreamWriter("..\\..\\output.txt");
        using (writer)
        {
            foreach (var item in names.OrderBy(x => x))
            {
                writer.WriteLine(item);
            }
                    
        }
        Console.WriteLine("The homework is very interest but I don't have a time for other problems ... :("); // sroka e ybiistven
        //Console.ReadLine();
        
    }
}

