using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            BuildDeck();
        }

        public void BuildDeck() 
        {
            string [] stringVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string [] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            int point;
            foreach (string each_suit in suits)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (i > 9)
                    {
                        point = 10;
                    }
                    else if (i == 0)
                    {
                        point = 11;
                    }
                    else{
                        point = i + 1;
                    }
                    Card new_card = new Card(stringVals[i], each_suit, i+1, point);
                    cards.Add(new_card);
                }
            }
        }

        public Card Deal()
        {
            Card removing = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return removing;
        }

        public void Reset()
        {
            cards.Clear();
            BuildDeck();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = cards.Count-1; i >= 0; i--)
            {
                int randIndx = rand.Next(i);
                Card temp = cards[i];
                cards[i] = cards[randIndx];
                cards[randIndx] = temp;
            }
        }

    } //close class Deck
}