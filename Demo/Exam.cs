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
        public int TotalScore { get; set; }
        public int UserScore { get; set; }

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
        protected void CollectAnswers()
        {
            TotalScore = Questions.Sum(q => q.Mark);
            UserScore = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                var question = Questions[i];
                Console.WriteLine($"\nYour answer for Question {i + 1}:");

                bool validAnswer = false;
                do
                {
                    Console.Beep(800, 200);
                    Console.Write("Enter your answer: ");
                    string userInput = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (question is TrueFalseQuestion)
                    {
                        if (bool.TryParse(userInput, out bool boolAnswer))
                        {
                            question.UserAnswer = new Answer(
                                boolAnswer ? 1 : 2,
                                boolAnswer ? "True" : "False"
                            );
                            validAnswer = true;
                        }
                    }
                    else if (question is MCQQuestion mcq)
                    {
                        if (int.TryParse(userInput, out int choice) &&
                            choice >= 1 &&
                            choice <= mcq.AnswerList.Length)
                        {
                            question.UserAnswer = mcq.AnswerList[choice - 1];
                            validAnswer = true;
                        }
                    }

                    if (!validAnswer)
                    {
                        Console.Beep(800, 200);
                        Console.WriteLine("Invalid answer! Please try again.");
                    }
                } while (!validAnswer);

                if (question.IsCorrect())
                {
                    UserScore += question.Mark;
                }
            }
        }
        protected void Sound(double percentage)
        {
            if (percentage >= 85)
            {
                Console.Beep(523, 200);
                Console.Beep(659, 200);
                Console.Beep(784, 400);
            }
            else if (percentage >= 50)
            {
                Console.Beep(523, 300);
                Console.Beep(523, 300);
            }
            else
            {
                Console.Beep(784, 200);
                Console.Beep(659, 200);
                Console.Beep(523, 400);
            }
        }
        protected void ShowUserResults()
        {
            Console.Clear();
            Console.WriteLine("\n=== Exam Results ===");
            double percentage = (double)UserScore / TotalScore * 100;

            Sound(percentage);

            Console.WriteLine($"Total Score: {TotalScore}");
            Console.WriteLine($"Your Score: {UserScore}");
            Console.WriteLine($"Percentage: {percentage:F2}%\n");

            if (percentage >= 85)
            {
                Console.WriteLine("Excellent performance! Outstanding achievement!");
            }
            else if (percentage >= 75)
            {
                Console.WriteLine("Very good! Keep up the great work!");
            }
            else if (percentage >= 50)
            {
                Console.WriteLine("Good effort! There's room for improvement.");
            }
            else
            {
                Console.WriteLine("More practice needed. Don't give up!");
            }

            Console.WriteLine("\nQuestion Review:");
            for (int i = 0; i < Questions.Length; i++)
            {
                var question = Questions[i];
                Console.WriteLine($"\nQuestion {i + 1} ({question.Mark} marks):");
                Console.WriteLine($"Your answer: {question.UserAnswer}");
                Console.WriteLine($"Correct answer: {question.RightAnswer}");
                Console.WriteLine($"Result: {(question.IsCorrect() ? "Correct" : "Incorrect")}");
            }
        }
        public abstract object Clone();

        #endregion

    }
}
