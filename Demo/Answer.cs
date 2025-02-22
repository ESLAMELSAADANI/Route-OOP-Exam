using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Answer : ICloneable
    {

        #region Properties
        
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        #endregion

        #region Constructors
        
        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        #endregion

        #region Methods
        
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        } 

        #endregion

    }
}
