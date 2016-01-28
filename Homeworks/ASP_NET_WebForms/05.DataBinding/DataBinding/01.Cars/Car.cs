namespace Cars
{
    using System;

    public class Car
    {
        public Car(Engine engine, Producer prod, CarModel model, int year, decimal price, Condition condition)
        {
            this.Engine = engine;
            this.Producer = prod;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Condition = condition;
        }

        public Engine Engine { get; set; }

        public Producer Producer { get; set; }

        public CarModel Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public Condition Condition { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Producer: {1}{0}Model: {2}{0}Year: {3}{0}Price: ${4}{0}Condition: {5}{0}Engine: {6}{0}",
                Environment.NewLine,
                this.Producer.Name,
                this.Model.Name,
                this.Year,
                this.Price,
                this.Condition.ToString(),
                this.Engine);
        }
    }
}