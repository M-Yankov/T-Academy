namespace Mediator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            ControlCenter controlTower = new ControlCenter();

            AirCraftMachine mamboNo5 = new Plane("Mambo No.5");
            controlTower.Register(mamboNo5);
            mamboNo5.FlyOut();

            AirCraftMachine stealth = new Plane("Invisible");
            controlTower.Register(stealth);
            stealth.FlyOut();

            AirCraftMachine striker = new Plane("Big Foot");
            controlTower.Register(striker);
            striker.FlyOut();

            AirCraftMachine boeing = new Plane("Boeing");
            controlTower.Register(boeing);
            boeing.FlyOut();
            boeing.Land();

            AirCraftMachine heli = new Helicopter("Four rotor blade");
            controlTower.Register(heli);
            heli.FlyOut();
            heli.Move(0, 1);

            striker.Move(0, 0);
            striker.Move(3, 4);
            mamboNo5.Move(2, 2);
            striker.Move(0, 0);

            Console.WriteLine("\n\nLet's add some traffic");
            // OK it works. Lets add some traffic.
            for (int i = 0; i < 50; i++)
            {
                AirCraftMachine testMchine;
                if (i % 2 == 0)
                {
                    testMchine = new Plane("Test #" + i + " from even's group.");
                }
                else
                {
                    testMchine = new Helicopter("Test #" + i + " from odd's group");
                }

                controlTower.Register(testMchine);
                testMchine.FlyOut();
            }


        }
    }
}
