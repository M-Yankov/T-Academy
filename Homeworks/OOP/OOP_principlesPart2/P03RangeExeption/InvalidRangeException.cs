

namespace P03RangeExeption
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;



        public InvalidRangeException(string txt, T start, T end)
            : base(String.Format("{2} \"Value must be in range between {0} and {1}\"", start, end, txt))
        {
            this.Pstart = start;
            this.Pend = end;
        }

        public InvalidRangeException(T start, T end)
            :this("" , start , end)
        {
            this.Pend = end;
            this.Pstart = start;
        }
        public InvalidRangeException()
        {

        }

        public InvalidRangeException(string txt)
            :base(txt)
        {

        }
        public T Pstart
        {
            get { return this.start; }
            set { this.start = value; }
        }
        public T Pend
        {
            get { return this.end; }
            set { this.end = value; }
        }


    }
}
