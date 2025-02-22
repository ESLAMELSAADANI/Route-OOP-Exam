using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class MCQQuestion : Question
    {

        #region Constructors

        public MCQQuestion(string header, string body, int mark, Answer[] answers, int correctAnswerIndex) : base(header, body, mark)
        {
            if (answers == null || answers.Length < 2)
                throw new ArgumentException("MCQ must have at least 2 answers", nameof(answers));
            if (correctAnswerIndex < 0 || correctAnswerIndex >= answers.Length)
                throw new ArgumentException("Invalid Correct Answer Index", nameof(correctAnswerIndex));

            AnswerList = answers;
            RightAnswer = answers[correctAnswerIndex];
        }

        #endregion

        #region Methods

        public override object Clone()
        {
            var answerClone = Array.ConvertAll(AnswerList, a => (Answer)a.Clone());
            var correctAnswerIndex = Array.IndexOf(AnswerList, RightAnswer);
            return new MCQQuestion(Header, Body, Mark, answerClone, correctAnswerIndex);
        }

        public override void Display()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Choose one answer:");
            foreach (var item in AnswerList)
            {
                Console.WriteLine($"  {item}");
            }
        }

        #endregion

    }
}
