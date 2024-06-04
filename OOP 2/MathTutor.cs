using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OOP_2
{
	public class MathTutor: IMathsApp
	{
        private Pack cards = new Pack();
        private int correct_questions = 0;
        private int total = 0;

		public MathTutor()
		{
            cards = new Pack();
            cards.Shuffle();
		}

        public void WriteToFile(string name, int score)
        {
            string filePath = "";
            string currentpath = Directory.GetCurrentDirectory();
            List<string> formatPath;

            bool isUnix = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isUnix)
            {
                formatPath = currentpath.Split('/').ToList<string>();
                formatPath.RemoveAt(formatPath.Count - 1);
                formatPath.RemoveAt(formatPath.Count - 1);
                formatPath.RemoveAt(formatPath.Count - 1);
                // add \Roads folder and join it together
                filePath = string.Join('/', formatPath) + "/scores.txt";
            }
            else
            {
                formatPath = currentpath.Split('\\').ToList<String>();
                formatPath.RemoveAt(formatPath.Count - 1);
                // add \Roads folder and join it together
                filePath = string.Join('\\', formatPath) + "\\scores.txt";
            }

            try
            {
                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine($"{name} - {score}");
                    sw.Close();
                }
                else
                {
                    using(FileStream fs = File.Create(filePath))
                    {
                        Byte[] text = new UTF8Encoding(true).GetBytes("Your Score:\n");
                        fs.Write(text, 0, text.Length);
                        Byte[] scoresOne = new UTF8Encoding(true).GetBytes($"{name} - {score}");
                        fs.Write(scoresOne, 0, scoresOne.Length);
                    }
                }
            }
            catch
            {
                throw new FileLoadException();
            }

        }

		public int Menu()
		{
            // Output the menu options
            Console.WriteLine("Select an option");
            Console.WriteLine("1. Instructions 2. Deal three cards 3.Quit");
            // Get the user's input
            string? user_input_option = null;
            try
            {
                user_input_option = Console.ReadLine();
                if (user_input_option is not null)
                {
                    int value = int.Parse(user_input_option);
                    // If the input is valid, return it
                    if (value is >= 1 && value is <= 3)
                    {
                        return value;
                    }
                    
                }
                // If the input is not valid, return -1
                return -1;
            }
            catch
            {
               // If there is an exception, call the menu method
               // until a valid input is received
                return Menu();
            }
        }
        // Display an equation to the user
        public void DisplayEquation(List<Card> equation)
        {
            // Build a string representing the equation
            string output = "";
            output += equation[0].Value.ToString();
            switch (equation[1].Suit)
            {
                case suitType.PLUS:
                    output += " + ";
                    break;
                case suitType.MINUS:
                    output += " - ";
                    break;
                case suitType.TIMES:
                    output += " * ";
                    break;
                case suitType.DIVIDE:
                    output += " / ";
                    break;
            }
            output += equation[2].Value.ToString() + "=";
            // Output the equation to the user
            Console.WriteLine(output);
        }

        // A method to deal three cards
        // and ask the user to solve the resulting equation
        public bool DealOnce()
        {
            // Increment the total number of questions
            total++;
            List<Card> formula = cards.Deal(3);
            suitType Operator = formula[1].Suit;
            int first = formula[0].Value;
            int second = formula[2].Value;
            int number;
            DisplayEquation(formula);

            // Get the user's answer
            while (true)
            {
                Console.WriteLine("Enter your answer");
                string? answer = Console.ReadLine();
            if (int.TryParse(answer,out number))
                {
                   break;
                }

            }

            switch (Operator)
                {
                case suitType.PLUS:
                    return first + second == number;
               case suitType.MINUS:
                    return first - second == number;
               case suitType.TIMES:
                    return first * second == number;
              case suitType.DIVIDE:
                    return first / second == number;
                default:
                    throw new Exception("Math incorrect");
            }
        }
        // Method to start the game
        public void Play()
        {
            bool playing = true;
            while (playing)
            {
                int option = Menu();
                switch (option)
                {
                    case 1:
                        // Display the tutorial
                        Tutorial.start();
                        break;
                    case 2:
                        // Generate and check one question
                        bool correct = DealOnce();
                        if (correct)
                        {
                            Console.WriteLine("Correct!!");
                            correct_questions++;
                        }
                        else
                        {
                            Console.WriteLine("Oops.Try again!");
                            Console.WriteLine("Play again or quit? p/q");
                            string? choice = Console.ReadLine();
                            if (choice is not null)
                            {
                                // Play again
                                if (choice == "p")
                                {
                                    total = 0;
                                    correct_questions = 0;
                                    continue;
                                }
                                // Quit game
                                else if (choice == "q")
                                {
                                    playing = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        playing = false;
                        break;
                }
            }
            Console.WriteLine($"You scored {correct_questions} / {total}");
            Console.WriteLine("What is your name player?");
            string? name = Console.ReadLine();
            if (name is not null)
                // Write the player's name and score to a file
                WriteToFile(name, correct_questions);
        }
    }   
}

