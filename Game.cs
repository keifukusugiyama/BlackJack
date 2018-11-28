using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public Player player1;
        public Player dealer;
        public Deck deck1;
        

        public Game(string name) 
        {
            player1 = new Player(name);
            dealer = new Player("The Dealer"); 
            deck1 = new Deck();
            deck1.Shuffle();
            Console.ForegroundColor = ConsoleColor.Red;
            player1.PlayerDraw(deck1);
            player1.PlayerDraw(deck1); 
            Console.ForegroundColor = ConsoleColor.DarkGreen;       
            dealer.PlayerDraw(deck1);         
            System.Console.WriteLine($"{dealer.name} has {dealer.DisplayPoints()} points.");
            dealer.Draw(deck1);   
            Console.ForegroundColor = ConsoleColor.Red;           
            player1.PlayerTurn(deck1, this);
            Console.ResetColor();
        }

        public void DealerTurn(Deck deck1)
        {
            System.Console.WriteLine($"{dealer.name}'s hidden card is {dealer.hand[1].stringVal} of {dealer.hand[1].suit}.");
            System.Console.WriteLine($"{dealer.name} has {dealer.DisplayPoints()}.");
            if (dealer.CheckBlackjack() == true)
            {
                System.Console.WriteLine("Blackjack!");
            } 
            while (dealer.DisplayPoints() < 17)
            {
                dealer.PlayerDraw(deck1);     
                System.Console.WriteLine($"{dealer.name} has {dealer.DisplayPoints()}."); 
            }
            if (dealer.DisplayPoints()>21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{player1.name} Won!");
            }
            else if (player1.DisplayPoints() < dealer.DisplayPoints())
            {
                System.Console.WriteLine($"{player1.name} Lost.");
            }
            else if (player1.DisplayPoints() == dealer.DisplayPoints())
            {
                if (player1.CheckBlackjack() == true && dealer.CheckBlackjack() != true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"{player1.name} Won!");
                }
                else if (player1.CheckBlackjack() != true && dealer.CheckBlackjack() == true)
                {
                    System.Console.WriteLine($"{player1.name} Lost.");
                }
                else
                {
                    System.Console.WriteLine($"{player1.name} Tied with the dealer.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{player1.name} Won!");
            }
            Console.ResetColor();
        }

        
    }
}