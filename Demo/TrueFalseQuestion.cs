using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class TrueFalseQuestion:Question
    {

        #region Constructors
        
        public TrueFalseQuestion(string header, string body, int mark, bool correctAnswer) : base(header, body, mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1,"True"),
                new Answer(2,"False")
            };
            RightAnswer = new Answer(correctAnswer ? 1 : 2, correctAnswer ? "True" : "False");
        }

        #endregion

        #region Methods
        
        public override object Clone()
        {
            return new TrueFalseQuestion(Header, Body, Mark, RightAnswer.AnswerId == 1);
        }

        public override void Display()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Type True Or False:");
            foreach (var item in AnswerList)
            {
                Console.WriteLine($" {item}");
            }
        } 

        #endregion

    }
}
