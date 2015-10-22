namespace EmploeeTeritories
{
    using System;
    using System.Linq;
    using Norttwind;
    using System.Data.Linq;

    public partial class InheritedEmployee : Employee
    {
        public EntitySet<Territory> ItsTeritories
        {
            get
            {
                var teritories = new EntitySet<Territory>();
                teritories.AddRange(this.Territories);
                return teritories;
            }
        }

        //public EntitySet<T> MyProperty { get; set; }
    }
}
