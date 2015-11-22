namespace FriendsTask
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Vertex : IComparable<Vertex>
    {
        public int Value { get; set; }

        public int Weight { get; set; }

        public Vertex(int val, int we)
        {
            this.Value = val;
            this.Weight = we;
        }

        public int CompareTo(Vertex other)
        {
            int compared = this.Weight.CompareTo(other.Weight);
            if (compared == 0)
            {
                return this.Value.CompareTo(other.Value); // are be oshte li spim be are nai nakraq da se sabudya.
            }

            return compared;
        }
    }

    public class FriendsSolver
    {
        static int m;
        static int n;
        static int start;
        static int end;
        static int m1;
        static int m2;

        static List<Vertex>[] vertexes;

        public static void Main(string[] args)
        {
            Console.SetIn(new StringReader(ReturnInput()));

            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = nm[0];
            m = nm[1];

            int[] se = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            start = se[0] ;
            end = se[1]  ;

            int[] m1m2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            m1 = m1m2[0]  ;
            m2 = m1m2[1]  ;

            vertexes = new List<Vertex>[n + 1];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0] ;
                var to = edge[1] ;
                var weight = edge[2];

                AddEdge(from, to, weight);
                AddEdge(to, from, weight);
            }
        }

        private static void Solve()
        {
            int beginToM1 = Dijkstra(start, m1, m2, end);
            int beginToM2 = Dijkstra(start, m2, m1, end);

            int M1ToM2 = Dijkstra(m1, m2, start, end);

            int M1ToEnd = Dijkstra(m1, end, m2, start);
            int M2ToEnd = Dijkstra(m2, end, m1, start);

            int min = Math.Min(beginToM1 + M1ToM2 + M2ToEnd, beginToM2 + M1ToM2 + M1ToEnd);
            Console.WriteLine(min);
        }

        private static int Dijkstra(int start, int end, int exclude1, int exclute2)
        {
            //HashSet<int> visited = new HashSet<int>();
            bool[] visited = new bool[n + 1];
            int[] best = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();  /// int[] best = new int[n] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue int.MaxValue, ..... n }
            best[start] = 0;

            SortedSet<Vertex> queue = new SortedSet<Vertex>();
            //Vertex[] queueArr = new Vertex[n + 1];
            //queueArr[0] = new Vertex(start, 0);

            queue.Add(new Vertex(start, 0));

            while (queue.Count > 0) // true
            {
                var current = queue.Min; 
                /*var tempcurrent = queueArr.FirstOrDefault(c => c != null && c.Weight < int.MaxValue && !visited[c.Value]);
                if (tempcurrent == null)
                {
                    break;
                }

                var current = new Vertex(tempcurrent.Value, tempcurrent.Weight);
                if (queueArr[current.Value] != null)
                {
                    queueArr[current.Value].Weight = int.MaxValue;
                } */
                queue.Remove(current);  // 
                //visited.Add(current.Value);
                visited[current.Value] = true;


                foreach (var next in vertexes[current.Value])
                {
                    //todo chekc is visited?
                    if (exclude1 == next.Value || exclute2 == next.Value)// if it's the vertex that should not be visited
                    {
                        continue;
                    }

                    if (best[next.Value] > best[current.Value] + next.Weight)
                    {
                        best[next.Value] = best[current.Value] + next.Weight;
                        //queueArr[next.Value] = new Vertex(next.Value, best[next.Value]);
                        
                        queue.Add(new Vertex(next.Value, best[next.Value])); //add if not visited
                    }
                }

                while (queue.Count > 0 && visited[queue.Min.Value])
                {
                    queue.Remove(queue.Min);
                }
            }

            return best[end];
        }

        private static Vertex GetNextMin(bool[] visited, Vertex[] nextverexToTraverse)
        {
            int indexOfMin = 0;
            int foundedMinWeight = int.MaxValue;
            for (int i = 0; i < nextverexToTraverse.Length; i++)
            {
                if (visited[i] == false && nextverexToTraverse[i].Weight < foundedMinWeight)
                {
                    if (nextverexToTraverse[i].Weight == foundedMinWeight)
                    {
                        indexOfMin = nextverexToTraverse[indexOfMin].Value < nextverexToTraverse[i].Value ? indexOfMin : i;
                    }
                    else
                    {
                        indexOfMin = i;
                    }
                }
            }

            return nextverexToTraverse[indexOfMin];
        }

        private static void AddEdge(int from, int to, int w)
        {
            if (vertexes[from] == null)
            {
                vertexes[from] = new List<Vertex>();
            }

            vertexes[from].Add(new Vertex(to, w));
        }

        private static string ReturnInput()
        {
            return @"18 30
1 17
11 4
1 8 15
1 9 1
1 14 100
2 4 100
2 8 10
2 9 100
3 9 100
3 10 3
3 14 1
4 9 1
4 10 3
4 11 1
5 11 6
5 16 7
6 7 1
6 11 1
6 15 7
6 16 1
7 11 3
7 15 2
7 18 1
8 18 1
10 12 4
10 13 6
11 12 5
12 13 10
12 17 100
13 14 2
15 16 10
16 17 2";
        }
    }


}
