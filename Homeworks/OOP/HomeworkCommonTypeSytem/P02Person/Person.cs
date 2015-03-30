

namespace P02Person
{
    using System;
    class Person
    {
        private string name;

        private int? age;

        public Person(string personName)
            : this(personName, null)
        {

        }
        public Person(string personName, int? personAge)
        {
            this.Pname = personName;
            this.Page = personAge; 
        }
        public int? Page 
        {
            get { return this.age; }
            set { this.age = value; }


        }

        public string Pname
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public override string ToString()
        {
            var neshtosi = this.Page == null ? "Not specified!" : this.Page.ToString(); //!
            return String.Format("Name: {0}; Age: {1};", this.Pname, neshtosi);
        }
        /*public static int? ToNullableInt32(this string s)
        {
            int i;
            if (Int32.TryParse(s, out i)) return i;
            return null;
        }*/
    }
}
