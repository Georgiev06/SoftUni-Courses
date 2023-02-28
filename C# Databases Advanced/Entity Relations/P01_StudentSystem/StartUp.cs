using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            Console.WriteLine("Connected!");
        }
    }
}