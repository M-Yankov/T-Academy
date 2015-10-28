namespace ShortestSequnce
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 10. We are given numbers N and M and the following operations: a) N = N+1 b) N = N+2 c) N = N*2
    ///     ○ Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
    ///     ○ Hint: use a queue.
    ///     ○ Example: N = 5, M = 16
    ///     ○ Sequence: 5 → 7 → 8 → 16
    /// </summary>
    public class FromNToM
    {
        private static readonly Stack<Action> Actions = new Stack<Action>();

        public static void Main()
        {
            //// I'm not using Queue<T>. Just Stack it's easy. And my logic is to start from M. (from end to the beginning i.e. reverse) 
            int theN = 3;
            int theM = 501;
            int steps = 0;

            if (theN > theM)
            {
                throw new ArgumentException();
            }

            while (theN != theM)
            {
                if (theM / 2 >= theN && theM % 2 == 0)
                {
                    theM = OperationC(theM, false);
                    Actions.Push(() => theN = OperationC(theN, true));
                }
                else if (theM - 2 >= theN && theM % 2 == 0)
                {
                    theM = OperationB(theM, false);
                    Actions.Push(() => theN = OperationB(theN, true));
                }
                else
                {
                    theM = OperationA(theM, false);
                    Actions.Push(() => theN = OperationA(theN, true));
                }

                steps++;
            }

            Console.WriteLine("Steps: {0}", steps);

            Console.Write(theN + " → ");
            while (Actions.Count != 0)
            {
                Action action = Actions.Pop();
                action.Invoke();
                if (Actions.Count == 0)
                {
                    Console.Write(theN);
                }
                else
                {
                    Console.Write(theN + " → ");
                }
            }

            Console.WriteLine();
        }

        private static int OperationC(int n, bool isPositive)
        {
            if (isPositive)
            {
                return n * 2;
            }

            return n / 2;
        }

        private static int OperationB(int n, bool isPositive)
        {
            if (isPositive)
            {
                return n + 2;
            }

            return n - 2;
        }

        private static int OperationA(int n, bool isPositive)
        {
            if (isPositive)
            {
                return n + 1;
            }

            return n - 1;
        }
    }
}
