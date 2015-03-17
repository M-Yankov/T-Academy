/* Problem 1. Structure

    Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    Implement the ToString() to enable printing a 3D point.

Problem 2. Static read-only field

    Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
    Add a static property to return the point O.
*/
using System;
using System.Text;


namespace Defining_Classes_Part2
{
    struct Point
    {
        private static readonly Point pointO;
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x , int y, int z): this()  // constructor
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()  // override method
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Point X: {0}, Point Y: {1}, Point Z: {2}", this.X, this.Y, this.Z);
            return result.ToString();

        }
        static Point()  // static constr
        {
            pointO = new Point(0,0,0);
        }

    }
}
