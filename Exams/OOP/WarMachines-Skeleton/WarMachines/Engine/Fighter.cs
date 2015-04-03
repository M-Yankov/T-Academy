

namespace WarMachines.Engine
{
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
    }
}
