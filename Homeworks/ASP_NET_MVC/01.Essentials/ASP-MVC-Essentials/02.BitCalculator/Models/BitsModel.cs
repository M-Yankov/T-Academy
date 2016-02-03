namespace BitCalculator.Models
{
    using System.Collections.Generic;

    public class BitsModel
    {
        public BitsModel()
        {
            this.Result = new Dictionary<string, string>();
        }

        public Size TypeSize { get; set; }

        public int Value { get; set; }

        public IDictionary<string , string> Result { get; set; }
    }
}