namespace Exceptions
{
    using System;

    public class CSharpExam : Exam
    {
        private int score;

        public CSharpExam(int score)
        {
            if (score < 0)
            {
                throw new NullReferenceException();
            }

            this.Score = score;
        }

        public int Score
        {
            get 
            {
                return this.score; 
            }

            private set
            {
                Validator.LessThanZero(value);
                this.score = value;
            } 
        }

        public override ExamResult Check()
        {
            Validator.ValidateRange(this.Score, 0, 100);

            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}