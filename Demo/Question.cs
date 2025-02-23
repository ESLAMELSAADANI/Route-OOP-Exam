using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    abstract class Question : ICloneable, IComparable<Question>
    {

        #region Properties

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        #endregion

        #region Constructors

        protected Question(string header, string body, int mark)
        {
            this.Header = header;
            this.Body = body;
            this.Mark = mark;
        }

        #endregion

        #region Methods

        public abstract object Clone();
        public bool IsCorrect()
        {
            return UserAnswer?.AnswerId == RightAnswer?.AnswerId;
        }
        public int CompareTo(Question? other)
        {
            return this.Mark.CompareTo(other?.Mark ?? 0);
        }
        public override string ToString()
        {
            return $"({Mark} marks) {Header}\n{Body}";
        }
        public abstract void Display();

        #endregion

    }
}
