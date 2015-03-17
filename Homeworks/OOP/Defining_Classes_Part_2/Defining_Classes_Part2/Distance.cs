/*Problem 3. Static class

    Write a static class with a static method to calculate the distance between two points in the 3D space.
 */
using System;


namespace Defining_Classes_Part2
{
    static class Distance
    {
        public static double CalculateDistance(Point a, Point b)
        {
            var res = Math.Pow(a.X, 2) + Math.Pow(a.Y, 2) + Math.Pow(a.Z, 2);
            var res2 = Math.Pow(b.X, 2) + Math.Pow(b.Y, 2) + Math.Pow(b.Z, 2);
            var final = Math.Abs(Math.Sqrt(res) - Math.Sqrt(res2));
            return final;
        }
    }
}
