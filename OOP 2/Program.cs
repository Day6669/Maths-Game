namespace OOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Testing test = new Testing();
            Console.WriteLine("Testing");
            test.RunTests();

            Console.WriteLine("Welcome!");

            MathTutor mathsApp = new MathTutor();

            mathsApp.Play();
        }
    }
}

