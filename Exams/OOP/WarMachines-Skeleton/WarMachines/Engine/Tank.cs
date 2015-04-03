namespace WarMachines.Engine
{

    using System;
    using WarMachines.Interfaces;

    public class Tank : Machine, IMachine, ITank
    {
        private bool tankDefenseMode;
       public Tank(string name, double atackPts ,double defensePts )
       {
           this.Name = name;
           this.AttackPoints = atackPts;
           this.DefensePoints = defensePts;
           this.HealthPoints = 100;
           this.DefenseMode = false;  // to check if works with default false and the toogle it.
           this.ToggleDefenseMode();
           
        }


       /*public IPilot Pilot   //<-- I will try without it.
       {
           get;
           set;
       }*/

        /*public void Attack(string target)
        {
            base.Attack(target); /// to check if it works on this way.
        }*/

        public bool DefenseMode
        {
            get { return this.tankDefenseMode; }
            set { this.tankDefenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.DefensePoints = this.DefensePoints - 30;
                this.AttackPoints = this.AttackPoints + 40;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints = this.DefensePoints + 30;
                this.AttackPoints = this.AttackPoints - 40;
            }
        }
    }
}
