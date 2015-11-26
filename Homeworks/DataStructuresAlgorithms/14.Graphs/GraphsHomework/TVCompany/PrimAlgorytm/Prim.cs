namespace PrimAlgorytm
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Vertex : IComparable<Vertex>
    {
        public Vertex(string value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public string Value { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Vertex other)
        {
            int compared = this.Weight.CompareTo(other.Weight);
            if (compared == 0)
            {
                return this.Value.CompareTo(other.Value);
            }

            return compared;
        }
    }

    public class Prim
    {
        private static Dictionary<string, List<Vertex>> graph;

        public static void Main()
        {
            graph = new Dictionary<string, List<Vertex>>();

            Console.SetIn(new StringReader(ProvideINput()));
            ReadInput();
            Solve();
        }

        private static void Solve()
        {
            Dictionary<string, List<Vertex>> result = new Dictionary<string, List<Vertex>>();
            HashSet<Vertex> connected = new HashSet<Vertex>();

            foreach (var vertex in graph)
            {
                if (!result.ContainsKey(vertex.Key))
                {
                    result.Add(vertex.Key, new List<Vertex>());
                }

                SortedSet<Vertex> c = new SortedSet<Vertex>();
                //// just see the demos in the github there are already there.
                //// https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/tree/master/13.%20Graph-Algorithms/demos/PrimAlgrithm 
            }
        }

        private static void ReadInput()
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                AddVertex(line[0], line[1], int.Parse(line[2]));
                AddVertex(line[1], line[0], int.Parse(line[2]));
            }
        }

        private static void AddVertex(string from, string to, int weight)
        {
            if (!graph.ContainsKey(from))
            {
                graph.Add(from, new List<Vertex>());
            }

            graph[from].Add(new Vertex(to, weight));
        }

        private static string ProvideINput()
        {
            return @"8
A B 4
A C 5
A D 9
B D 2
C D 20
C E 7
D E 8
E F 12";
        }
    }
}