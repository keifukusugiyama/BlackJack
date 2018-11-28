using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Card{
        public string stringVal;
        public string suit;
        public int val;
        public int pointVal;

        public Card (string StringVal, string Suit, int Val, int PointVal)
        {
            stringVal = StringVal;
            suit = Suit;
            val = Val;
            pointVal = PointVal;
        }
    }
}