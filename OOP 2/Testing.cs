using static System.Diagnostics.Debug;

namespace OOP_2
{
	public class Testing
	{
		Pack pack;

		public Testing()
		{
			pack = new Pack();
	
        }

		public void DealThreeCards()
		{
			List<Card> packs = pack.Deal(3);
			Assert(packs.Count == 3, "Packs needs to cointain 3 cards");
		}

		public void DealFiveCards()
		{
			List<Card> packs = pack.Deal(5);
			Assert(packs.Count == 5, "Pack needs to contain 5 cards");
		}

		public void TestShuffle()
		{
			List<Card> cards = pack.getPack();

			Pack newPack = new Pack();
            newPack.Shuffle();
		
			Assert(cards.SequenceEqual(newPack.getPack()) == false, "Not Shuffled");
		}

		public void RunTests()
		{
            DealFiveCards();
            DealThreeCards();
            TestShuffle();
            Console.WriteLine("All Tests Passed");
        }
	}
}

