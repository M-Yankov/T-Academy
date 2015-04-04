

namespace WarMachines.Engine
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;
    public class Fighter : Machine , IMachine , IFighter
    {
        private bool fighterStealthMode;
        public Fighter(string name, double attackPts, double defencePts , bool stealthMode)
        {
            this.Name = name;
            this.AttackPoints = attackPts;
            this.DefensePoints = defencePts;
            this.HealthPoints = 200;
            this.fighterStealthMode = stealthMode;
        }
        public bool StealthMode
        {
            get { return this.fighterStealthMode; }
            set { this.fighterStealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode == true)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }
        public override string ToString()
        {
            string targetsString;
            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format("- {0}", this.Name));
            result.AppendLine(" *Type: Fighter");
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
            if (this.StealthMode)
            {
                result.Append(" *Stealth: ON");
            }
            else
            {
                result.Append(" *Stealth: OFF");
            }
            return result.ToString();
        }
    }
}
