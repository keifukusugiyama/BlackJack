using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // create players
            // Player player1 = new Player("Bob");
            // Player dealer = new Player("Dealer");

            // //create hands of 2 cards
            // Deck deck1 = new Deck();    
            // deck1.Shuffle();
            // player1.Draw(deck1);
            // player1.Draw(deck1);            
            // dealer.Draw(deck1);            
            // dealer.Draw(deck1);            

            // // display current points
            // player1.DisplayPoints();            
            // dealer.DisplayPoints();            

            // if (player1.DisplayPoints() > 21)
            // {
            //     System.Console.WriteLine("You Lose!");
            // }


            // if (dealer.DisplayPoints() > 21)
            // {
            //     System.Console.WriteLine("You Win!");
            // }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Please enter your name to start the game!");
            string name = Console.ReadLine();
            Game game1 = new Game(name);
            Console.ResetColor();
        }
    }
}
