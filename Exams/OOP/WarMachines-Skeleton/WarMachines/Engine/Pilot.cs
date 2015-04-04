

namespace WarMachines.Engine
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using WarMachines.Interfaces;
    using System;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> pilotEngagedMachnes; // to implement class machine.
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Pilot(string name)
        {
            this.Name = name;
            pilotEngagedMachnes = new List<IMachine>();
        }
        public void AddMachine(IMachine machine)
        {
            this.pilotEngagedMachnes.Add(machine); // to sort by health in report 
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            if (this.pilotEngagedMachnes.Count == 0)
            {
                result.AppendFormat("{0} - no machines", this.Name);
            }
            else if (this.pilotEngagedMachnes.Count == 1)
            {
                result.AppendLine(String.Format("{0} - 1 machine", this.Name));
            }
            else
            {
                result.AppendLine(String.Format("{0} - {1} machines", this.Name, this.pilotEngagedMachnes.Count));
            }
            foreach (var machine in pilotEngagedMachnes
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name))
            {
                if (this.pilotEngagedMachnes.Count == 1)
                {
                    result.Append(machine.ToString()); //AppentLine??
                }
                else
                {
                    result.AppendLine(machine.ToString()); //AppentLine??

                }
            }



            return result.ToString().Trim(); // 
        }
    }
}
