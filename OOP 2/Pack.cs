namespace OOP_2
{
    // collection type to hold the cards
    class Pack : BasePack
    {

        static private List<Card> pack;

        public List<Card> getPack()
        {
            // public getter for private attribute
            return pack;
        }

   
        // data type for card faces
        public enum CardFaces
        {
            ONE = 1,
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            FIVE = 5,
            SIX = 6,
            SEVEN= 7,
            EIGHT = 8,
            NINE = 9,
            TEN = 10,
            ELEVEN = 11,
            TWELVE = 12,
            THRITEEN = 13,
        }

   

        public Pack()
        {
            //Creates the card pack here.
            pack = new List<Card>();

            foreach (var suit in Enum.GetValues(typeof(suitType)))
            {
                foreach (var face in Enum.GetValues(typeof(CardFaces)))
                //Loop to create card from all 13 cards from each suit.
                {
                    Card card = new Card();
                    card.Suit = (suitType)suit;
                    card.Value = (int)face;
                    pack.Add(card);

                }
            }
        }

        public void Shuffle()
        {
            base.shuffle(ref pack);
        }

        public override List<Card> Deal(in int amount)
        {
            List<Card> hand = new List<Card>();
            if (pack.Count > amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    hand.Add(pack[i]);
                    pack.Add(pack[i]);
                    pack.RemoveAt(i);
                }
            }
            return hand;
           
        }

    }
}

