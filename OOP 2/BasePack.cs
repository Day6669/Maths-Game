namespace OOP_2
{
	public class BasePack
	{
        public virtual List<Card> Deal(in int amount)
        {
            return new List<Card>();
        }

        public bool shuffle(ref List<Card> pack)
        {
            // loop all cards
            Random random = new Random();
            for (int i = 0; i < pack.Count - 1; i++)
            {
                // generate random number
                int randomIndex = random.Next(i, pack.Count);
                // swap cards around (current <-> random)
                Card temp = pack[i];
                pack[i] = pack[randomIndex];
                pack[randomIndex] = temp;
            }
            return true;
        }
    }
}

