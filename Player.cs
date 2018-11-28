using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player (string Name)
        {
            name = Name;
            hand = new List<Card>();
        }
        public Card Draw(Deck deck)
        { 
            Card new_card = deck.Deal();
            hand.Add(new_card);
            return new_card;
        }

        public Card Discard(int idx)
        {
            if (idx > hand.Count)
            {
                return null;
            }
            Card discarding = hand[idx];
            hand.RemoveAt(idx);
            return discarding;
        }

        public int DisplayPoints()
        {
            int sum = 0;
            int aces = 0;
            foreach (Card card in hand)
            {
                if (card.pointVal == 11)
                {
                    aces ++;
                }
                
                sum += card.pointVal;
            }
            while (sum > 21 && aces > 0)
            {
                sum -=10;
                aces --;
            }
            
            return sum;
        }

        public void PlayerDraw(Deck deck1)
        {
            Card new_card = this.Draw(deck1);
            System.Console.WriteLine($"{this.name} got the {new_card.stringVal} of {new_card.suit}.");
        }

        public void PlayerTurn(Deck deck1, Game game)
        {
            System.Console.WriteLine($"{this.name}'s Turn");
            System.Console.WriteLine($"{this.name} has {this.DisplayPoints()} points.");
            if (this.CheckBlackjack() == true)
            {
                System.Console.WriteLine("Blackjack!");
            }
            while (this.DisplayPoints() < 21)
            {
                System.Console.WriteLine("Please select an option 1: draw or 2: stay");
                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    this.PlayerDraw(deck1);
                    System.Console.WriteLine($"{this.name} now has {this.DisplayPoints()} points.");
                }
                else if (selection == "2")
                {
                    System.Console.WriteLine($"{this.name}'s turn has ended.");
                    break;
                }

            }
            if (this.DisplayPoints() > 21)
            {
                System.Console.WriteLine($"{this.name} Lost.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray; 
                game.DealerTurn(deck1);
            }
        }
        public bool CheckBlackjack()
        {
            if (this.DisplayPoints() == 21 && this.hand.Count == 2)
            {
                return true;
            }
            return false;
        }


    } //close class Player
}