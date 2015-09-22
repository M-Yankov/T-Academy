namespace Mediator
{
    using System;
    using System.Collections.Generic;

    public class ControlCenter : BaseMediator
    {
        private bool[,] fieldCoodinates;
        private List<AirCraftMachine> planes;

        public ControlCenter()
        {
            this.fieldCoodinates = new bool[5, 5];
            InitField();
            planes = new List<AirCraftMachine>();
        }

        private void InitField()
        {
            for (int i = 0; i < fieldCoodinates.GetLength(0); i++)
            {
                for (int k = 0; k < fieldCoodinates.GetLength(1); k++)
                {
                    fieldCoodinates[i, k] = true;
                }
            }
        }

        public void Register(AirCraftMachine plane)
        {
            plane.Mediator = this;
        }

        public override void AddToControlCenter(AirCraftMachine plane)
        {
            for (int i = 0; i < fieldCoodinates.GetLength(0); i++)
            {
                for (int k = 0; k < fieldCoodinates.GetLength(1); k++)
                {
                    // search for free slot
                    if (fieldCoodinates[i, k] == true)
                    {
                        planes.Add(plane);
                        plane.X = i;
                        plane.Y = k;
                        fieldCoodinates[i, k] = false;
                        Console.WriteLine("{0} says: {1} added to our control center on coordinates x:{2} - y:{3}!", this.GetType().Name, plane.Name, plane.X, plane.Y);
                        return;
                    }
                }
            }

            Console.WriteLine("{0} says: To much traffic try to join later...", this.GetType().Name);
        }

        // hidden communication between planes
        public override void Communicate(AirCraftMachine plane, int x, int y)
        {
            foreach (var pl in planes)
            {
                if (pl.X == x && pl.Y == y)
                {
                    Console.WriteLine("{0} says: You can NOT fly there!", this.GetType().Name);
                    return;
                }
            }

            this.fieldCoodinates[plane.X, plane.Y] = true;
            this.fieldCoodinates[x, y] = false;
            plane.X = x;
            plane.Y = y;
            Console.WriteLine("{0} says: {1} successfully send to coordinates x:{2} - y:{3}!", this.GetType().Name, plane.Name, x, y);
        }

        public override void AllowToLand(AirCraftMachine plane)
        {
            this.fieldCoodinates[plane.X, plane.Y] = true;
            planes.Remove(plane);
            Console.WriteLine("{0} says: {1} removed from our control center movement.", this.GetType().Name, plane.Name);
        }
    }
}
