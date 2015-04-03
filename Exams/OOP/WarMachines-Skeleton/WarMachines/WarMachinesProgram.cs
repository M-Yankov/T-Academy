namespace WarMachines
{
    using System;
    using System.IO;
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            /*StreamReader reader = new StreamReader("..\\..\\input.txt");
            Console.SetIn(reader);*/
            WarMachineEngine.Instance.Start();
        }
    }
}
