namespace Mediator
{
    using System;

    public abstract class AirCraftMachine
    {
        private string name;
        private BaseMediator controlCenter;

        public AirCraftMachine(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public BaseMediator Mediator
        {
            get
            {
                return this.controlCenter;
            }
            set
            {
                this.controlCenter = value;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void FlyOut()
        {
            this.controlCenter.AddToControlCenter(this);
        }

        public void Move(int x, int y)
        {
            Console.WriteLine("{0}: I want to fly to coordinates: x: {1} - y: {2}", this.Name, x, y);
            this.controlCenter.Communicate(this, x, y);
        }

        public void Land()
        {
            this.controlCenter.AllowToLand(this);
        }
    }
}
