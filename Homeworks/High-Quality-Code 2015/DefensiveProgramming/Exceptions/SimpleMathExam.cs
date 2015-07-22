namespace Exceptions
{
    using System;

    public class SimpleMathExam : Exam
    {
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                problemsSolved = 0;
            }

            if (problemsSolved > 10)
            {
                problemsSolved = 10;
            }

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved { get; private set; }

        public override ExamResult Check()
        {
            switch (this.ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: not pass.");

                case 1:
                    return new ExamResult(4, 2, 6, "Average result: pass.");

                case 2:
                    return new ExamResult(6, 2, 6, "Average result: pass with excellent.");

                default:
                    return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
            }
        }
    }
}