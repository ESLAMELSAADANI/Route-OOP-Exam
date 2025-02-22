namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Subject Sub1 = new Subject(10, "C#");
                ExamManage examManage = new ExamManage(Sub1);

                examManage.CreateExam();
                examManage.CreateQuestions();
                examManage.RunExam();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
