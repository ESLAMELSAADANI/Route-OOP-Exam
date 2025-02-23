using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class ExamManage
    {
        #region Attributes
        
        private Subject subject;
        private Stopwatch stopwatch;

        #endregion

        #region Constructors
        
        public ExamManage(Subject subject)
        {
            this.subject = subject;
            this.stopwatch = new Stopwatch();
        }

        #endregion

        #region Methods
        
        public void CreateQuestions()
        {
            Console.WriteLine($"\nCreating questions for {subject.SubjectName}");
            bool isPracticalExam = subject.Exam is PracticalExam;

            for (int i = 0; i < subject.Exam.QuestionsNum; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");

                int choice;
                if (isPracticalExam)
                {
                    Console.WriteLine("Practical Exam: MCQ questions only");
                    choice = 2; // MCQ
                }
                else
                {
                    Console.WriteLine("Choose question type:");
                    Console.WriteLine("1. True/False");
                    Console.WriteLine("2. MCQ");

                    bool isParsed = false;
                    do
                    {
                        Console.Beep(800, 200);
                        Console.Write("Enter your choice (1 or 2): ");
                        isParsed = int.TryParse(Console.ReadLine(), out choice);
                    } while (!isParsed || choice < 1 || choice > 2);
                }
                string header;
                do
                {
                    Console.Beep(800, 200);
                    Console.Write("Enter question header: ");
                    header = Console.ReadLine()!;
                } while (string.IsNullOrWhiteSpace(header));

                string body;
                do
                {
                    Console.Beep(800, 200);
                    Console.Write("Enter question body: ");
                    body = Console.ReadLine()!;
                } while (string.IsNullOrWhiteSpace(body));

                bool isParsed0 = false;
                int mark;
                do
                {
                    Console.Beep(800, 200);
                    Console.Write("Enter question mark: ");
                    isParsed0 = int.TryParse(Console.ReadLine(), out mark);
                } while (!isParsed0);

                if (choice == 1) // True/False - only for Final Exam
                {
                    isParsed0 = false;
                    bool correctAnswer;
                    do
                    {
                        Console.Beep(800, 200);
                        Console.Write("Enter correct answer (true/false): ");
                        isParsed0 = bool.TryParse(Console.ReadLine(), out correctAnswer);
                    } while (!isParsed0);
                    subject.Exam.Questions[i] = new TrueFalseQuestion(header, body, mark, correctAnswer);
                }
                else // MCQ - for both exam types
                {
                    isParsed0 = false;
                    int numChoices;
                    do
                    {
                        Console.Beep(800, 200);
                        Console.Write("Enter number of choices: ");
                        isParsed0 = int.TryParse(Console.ReadLine(), out numChoices);
                    } while (!isParsed0 || numChoices < 2);

                    Answer[] answers = new Answer[numChoices];
                    for (int j = 0; j < numChoices; j++)
                    {
                        string answerText;
                        do
                        {
                            Console.Beep(800, 200);
                            Console.Write($"Enter choice {j + 1}: ");
                            answerText = Console.ReadLine()!;
                        } while (string.IsNullOrWhiteSpace(answerText));
                        answers[j] = new Answer(j + 1, answerText);
                    }

                    isParsed0 = false;
                    int correctAnswer;
                    do
                    {
                        Console.Beep(800, 200);
                        Console.Write($"Enter correct answer number (1 to {numChoices}): ");
                        isParsed0 = int.TryParse(Console.ReadLine(), out correctAnswer);
                        if (isParsed0)
                            correctAnswer -= 1;
                    } while (!isParsed0);

                    subject.Exam.Questions[i] = new MCQQuestion(header, body, mark, answers, correctAnswer);
                }
            }
        }
        public void CreateExam()
        {
            Console.WriteLine("\nChoose Exam Type:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");

            bool isParsed = false;
            int examChoice;
            do
            {
                Console.Beep(800, 200);
                Console.Write("Enter your choice (1 or 2): ");
                isParsed = int.TryParse(Console.ReadLine(), out examChoice);
            } while (!isParsed || examChoice != 1 && examChoice != 2);
            ExamType examType = examChoice == 1 ? ExamType.Final : ExamType.Practical;

            isParsed = false;
            int durationMinutes;
            do
            {
                Console.Beep(800, 200);
                Console.Write("\nEnter exam duration in minutes: ");
                isParsed = int.TryParse(Console.ReadLine(), out durationMinutes);
            } while (!isParsed || durationMinutes <= 0);

            isParsed = false;
            int QuestionsNum;
            do
            {
                Console.Beep(800, 200);
                Console.Write("Enter number of questions: ");
                isParsed = int.TryParse(Console.ReadLine(), out QuestionsNum);
            } while (!isParsed || QuestionsNum <= 0);

            subject.CreateExam(examType, TimeSpan.FromMinutes(durationMinutes), QuestionsNum);
        }
        public void RunExam()
        {
            Console.Clear();
            Console.Beep(800, 200);
            Console.Write("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()!.ToLower()) == 'y')
            {
                stopwatch.Start();
                subject.Exam.ShowExam();
                stopwatch.Stop();
                Console.WriteLine($"\nThe Elapsed Time = {stopwatch.Elapsed}");
            }
        } 

        #endregion

    }
}
