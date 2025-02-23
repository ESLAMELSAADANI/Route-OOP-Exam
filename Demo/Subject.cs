using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Subject : IComparable<Subject>
    {

        #region Properties
        
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        #endregion

        #region Constructors
        
        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        #endregion

        #region Methods
        
        public void CreateExam(ExamType type, TimeSpan duration, int QuestionsNum)
        {
            if (type == ExamType.Final)
            {
                Exam = new FinalExam(duration, QuestionsNum);
            }
            else if (type == ExamType.Practical)
            {
                Exam = new PracticalExam(duration, QuestionsNum);
            }
            else
            {
                throw new ArgumentException("Invalid exam type", nameof(type));
            }
        }
        public int CompareTo(Subject? other)
        {
            return SubjectId.CompareTo(other?.SubjectId ?? 0);
        }
        public override string ToString()
        {
            return $"Subject: {SubjectName} (ID: {SubjectId})";
        } 

        #endregion

    }
}
