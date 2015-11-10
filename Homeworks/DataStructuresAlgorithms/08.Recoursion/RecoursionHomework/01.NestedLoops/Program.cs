namespace NestedLoops
{
    using System;
    using System.Text;

    /// <summary>
    /// Task1. Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Loop(3);
        }

        private static void Loop(int count)
        {
            int[] masiv = new int[count];

            SimulateNestedLoops(0, masiv);
        }

        private static void SimulateNestedLoops(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine("[{0}]", string.Join("] [", vector));
                return; 
            }

            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i;
                SimulateNestedLoops(index + 1, vector);
            }
        }
    }
}
