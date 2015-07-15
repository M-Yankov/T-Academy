namespace ChiefClass
{
    using System;

    public class Chief
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl = GetBowl();

            Peel(potato);
            Peel(carrot);

            Cut(potato);
            Cut(carrot);

            bowl.Add(potato);
            bowl.Add(carrot);
        }
        private Potato GetPotato()
        {
            return new Potato();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }
        private Carrot GetCarrot()
        {
            return new Carrot();
        }
        private void Cut(Vegetable peeledVegetable)
        {
            //...
        }

        private void Peel(Vegetable vegetable)
        {
            //..
        }
        
    }
}
