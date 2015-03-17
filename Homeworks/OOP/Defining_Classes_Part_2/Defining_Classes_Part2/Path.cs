/*Problem 4. Path

    Create a class Path to hold a sequence of points in the 3D space.
    Create a static class PathStorage with static methods to save and load paths from a text file.
    Use a file format of your choice.  
 * */

using System;
using System.Collections.Generic;


namespace Defining_Classes_Part2
{
    class Path
    {
        private List<Point> sequencePoints;

        public Path()
        {
            this.sequencePoints = new List<Point>();
        }
        public List<Point> SequnecePoints 
        {
            get { return this.sequencePoints; }
            set { this.sequencePoints = value; }
        }
    }
}
