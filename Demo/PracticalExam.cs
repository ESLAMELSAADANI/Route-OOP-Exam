using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class PracticalExam : Exam
    {

        #region Constructors
        
        public PracticalExam(TimeSpan duration, int questionNum) : base(duration, questionNum)
        {
        }

        #endregion

        #region Methods
        
        public override object Clone()
        {
            var exam = new PracticalExam(Duration, QuestionsNum);
            exam.Questions = Array.ConvertAll(Questions, q => (Question)q.Clone());
            return exam;
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n=== Practical Exam ===");
            Console.WriteLine($"Duration: {Duration.TotalMinutes} minutes");
            Console.WriteLine($"Number of questions: {QuestionsNum}\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}:");
                Questions[i].Display();
                Console.WriteLine();
            }

            DisplayResults();
        }

        protected override void DisplayResults()
        {
            Console.WriteLine("\nCorrect Answers:");
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i].RightAnswer != null)
                {
                    Console.WriteLine($"Question {i + 1}: {Questions[i].RightAnswer}");
                }
            }
        } 

        #endregion

    }
}
