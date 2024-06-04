namespace OOP_2{
    // create a data type to store the different suits
    public enum suitType    {        PLUS = 1,        MINUS = 2,        TIMES = 3,        DIVIDE = 4,    }    public class Card    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        private suitType suitValue;        private int cardValue;

        // Make getters and setters for value
        public int Value        {            get            {                return cardValue;            }            set            {
                // validate set
                if (value <= 13 && value >= 1)                {                    cardValue = value;                }                else                {                    Console.WriteLine("Value given is too large or too small");                }            }        }        public suitType Suit
        {            get            {                return suitValue;            }            set

            {                suitValue = value;            }

        }    }}