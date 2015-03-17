/*continue from problem 4*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Defining_Classes_Part2
{
    static class PathStorage
    {
        public static void Save(Path sequence) // List<Point>
        {
            StreamWriter writer = new StreamWriter("..\\..\\SequencePoints.txt");
            string abc; //= string.Join("\n\r", sequence.SequnecePoints);
            using (writer)
            {
                for (int i = 0; i < sequence.SequnecePoints.Count; i++)
                {
                    abc = sequence.SequnecePoints[i].ToString();
                    writer.WriteLine(abc);
                }
            }
        }
        public static List<Point> Load()
        {
            List<Point> sequencePoints = new List<Point>();
            StreamReader reader = new StreamReader("..\\..\\SequencePoints.txt");
            string abc = "s";
            using (reader)
            {
                Regex rexX = new Regex("Point X: [-0-9]+"); // to add dot  (Point : [-0-9]+)
                Regex rexY = new Regex("Point Y: [-0-9]+");
                Regex rexZ = new Regex("Point Z: [-0-9]+");
                while (true)
                {

                    abc = reader.ReadLine();
                    if (string.IsNullOrEmpty(abc))
                    {
                        break;
                    }
                    Match maaat = rexX.Match(abc);
                    int valueX = int.Parse(maaat.ToString().Substring(9));
                    maaat = rexY.Match(abc);
                    int valueY = int.Parse(maaat.ToString().Substring(9));
                    maaat = rexZ.Match(abc);
                    int valueZ = int.Parse(maaat.ToString().Substring(9));
                    sequencePoints.Add(new Point(valueX, valueY, valueZ));
                }
            }
            return sequencePoints;
        }

    }
}
