namespace PeshoFriends
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Vertex
    {
        public Vertex(int value, int w)
        {
            this.Value = value;
            this.Weight = w;
        }

        public int Value { get; set; }

        public int Weight { get; set; }
    }

    public class Pesho
    {
        static int pointOnMap;
        static int streetsCount;
        static int hospitalsCount;
        static int[] hospitals;

        static Dictionary<int, List<Vertex>> vertexes;

        public static void Main()
        {
            vertexes = new Dictionary<int, List<Vertex>>();

            //Console.SetIn(new StringReader(GetInput()));
            ReadInput();
            Solve();
        }

        private static void Solve()
        {
            int minLengthToCurrentHospital = int.MaxValue;

            for (int i = 0; i < hospitals.Length; i++)
            {
                int lengthToCurrnetHospital = Dijkstra(hospitals[i]);
                if (minLengthToCurrentHospital > lengthToCurrnetHospital)
                {
                    minLengthToCurrentHospital = lengthToCurrnetHospital;
                }
            }

            Console.WriteLine(minLengthToCurrentHospital);
        }

        private static int Dijkstra(int vertexValue)
        {
            Dictionary<int, int> best = new Dictionary<int, int>(); //int[] best = Enumerable.Repeat(int.MaxValue, pointOnMap + 1).ToArray(); // hashset KeyValuePair<int, int>();
            HashSet<int> visited = new HashSet<int>();

            best.Add(vertexValue, 0);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertexValue);

            while (queue.Count != 0)
            {
                int current = queue.Dequeue();
                visited.Add(current);

                foreach (var vertex in vertexes[current])
                {
                    if (!best.ContainsKey(vertex.Value))
                    {
                        best.Add(vertex.Value, best[current] + vertex.Weight);
                        queue.Enqueue(vertex.Value);
                    }
                    else if (best[vertex.Value] > best[current] + vertex.Weight)
                    {
                        best[vertex.Value] = best[current] + vertex.Weight;
                        queue.Enqueue(vertex.Value);
                    }
                }
            }

            //// Calculate sum of min paths. From currentHospital (vertexValue) to other friends of Pesho.
            int sum = 0; //// long
            foreach (var item in best)
            {
                if (!ContainsHospital(item.Key))
                {
                    sum += item.Value;
                }
            }

            return sum;
        }

        private static bool ContainsHospital(int value)
        {
            for (int start = 0, end = hospitals.Length - 1; start <= end; start++, end--)
            {
                if (hospitals[start] == value || hospitals[end] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private static void ReadInput()
        {
            int[] firsline = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            pointOnMap = firsline[0];
            streetsCount = firsline[1];
            hospitalsCount = firsline[2];

            hospitals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < streetsCount; i++)
            {
                int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                AddVertex(currentLine[0], currentLine[1], currentLine[2]);
                AddVertex(currentLine[1], currentLine[0], currentLine[2]);
            }
        }

        private static void AddVertex(int from, int to, int weight)
        {

            if (!vertexes.ContainsKey(from))
            {
                vertexes.Add(from, new List<Vertex>());
            }

            vertexes[from].Add(new Vertex(to, weight));
        }

        private static string GetInput()
        {
            return @"5 8 2
1 2
1 2 2
4 1 2
1 3 5
3 4 10
4 5 5
2 4 17
5 2 3
2 3 1";
        }
    }
}
