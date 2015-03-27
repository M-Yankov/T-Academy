

namespace P03AnimalHierarhy
{
    using System;
    class TomCat : Cat ,ISound
    {
        public TomCat(string name, int age, Sex sex)
            :base(name, age,sex)
        {
            if(sex == Sex.female)
            {   
                throw new ArgumentException("TomCat must be male!"); // to check if it works
            }
        }
    
        
}
}
