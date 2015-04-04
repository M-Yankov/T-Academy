
using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;
namespace WarMachines.Engine
{
    public abstract class Machine : IMachine // to be abstract or not
    {
        private string machineName;
        private IPilot pilotEngaged;
        private double machineHealthPoints;
        private double machineAtackPoints;
        private double machineDefensePoints;
        private IList<string> machineTargets = new List<string>(); // idk
        public string Name
        {
            get
            {
                return this.machineName;
            }
            set
            {
                this.machineName = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilotEngaged;
            }
            set
            {
                this.pilotEngaged = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.machineHealthPoints;
            }
            set
            {
                this.machineHealthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.machineAtackPoints;
            }
            set
            {
                this.machineAtackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.machineDefensePoints;
            }
            set
            {
                this.machineDefensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.machineTargets;
            }
            set
            {
                this.machineTargets = value;//??
            }
        }

        public void Attack(string target)
        {
            this.machineTargets.Add(target);
        }
        /*public override string ToString() // override Machine To String
        {
            string targetsString;
            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format("- {0}", this.Name));
            var temp = this.GetType().Name;
            object mytype;
            if (temp == "Tank")
            {
                mytype = (Tank)this;
            }
            else
            {
                mytype = (Fighter)this;
            }
            //var Realtype = typeof(IMachine).;
            if (mytype is Tank) //? should works
            {
                result.AppendLine(" *Type: Tank");
            }
            else
            {
                result.AppendLine(" *Type: Fighter");
            }
            result.AppendLine(String.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(String.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(String.Format(" *Defense: {0}", this.DefensePoints));
            if (this.Targets.Count == 0)
            {
                targetsString = "None";
            }
            else
            {
                targetsString = string.Join(", ", this.Targets);
            }
            result.AppendLine(String.Format(" *Targets: {0}", targetsString)); 
            if (mytype is Tank)
            {
                var obj = (Tank)(IMachine)mytype; // <--- Hahahahah  nema takova  neshto :D
                if (obj.DefenseMode)
                {
                    result.Append(" *Defense: ON");
                }
                else
                {
                    result.Append(" *Defense: OFF");
                }
            }
            else
            {
                var obj = (Fighter)(object)mytype;
                if (obj.StealthMode)
                {
                    result.Append(" *Stealth: ON");
                }
                else
                {
                    result.Append(" *Stealth: OFF");
                }
            }
            return result.ToString();
        }*/
    }
}
