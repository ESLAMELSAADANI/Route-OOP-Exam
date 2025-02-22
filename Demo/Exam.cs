using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    abstract class Exam : ICloneable
    {

        #region Properties
        
        public TimeSpan Duration { get; set; }
        public Question[] Questions { get; set; }
        public int QuestionsNum { get { return Questions.Length; } }

        #endregion

        #region Constructors
        
        protected Exam(TimeSpan duration, int questionNum)
        {
            Duration = duration;
            Questions = new Question[questionNum];
        }

        #endregion

        #region Methods
        
        public abstract void ShowExam();
        public abstract object Clone();
        protected abstract void DisplayResults(); 

        #endregion

    }
}
