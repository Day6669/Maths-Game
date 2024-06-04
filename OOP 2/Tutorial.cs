using System;
namespace OOP_2
{
	public class Tutorial
	{
		public Tutorial()
		{
		}

		public static void start()
		{
			Console.WriteLine("You begin the game by pressing play.\n Attempt " +
				"to get as many answers correct as possible as when you get one wrong the game restarts.");
			Thread.Sleep(500);
			Console.WriteLine("You will see your total score once you have answered a question incorrectly. Good Luck!");
		}
	}
}

