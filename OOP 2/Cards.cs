﻿namespace OOP_2
    // create a data type to store the different suits
    public enum suitType
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        private suitType suitValue;

        // Make getters and setters for value
        public int Value
                // validate set
                if (value <= 13 && value >= 1)
        {

            {

        }