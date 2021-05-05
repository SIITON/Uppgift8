using System;
using Uppgift8.Bowling;

namespace Uppgift8
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BowlingGame2();
            game.Roll(2);
            game.Roll(4);
            game.Roll(7);
            game.Roll(3);
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(0);
            game.Roll(5);
            game.Roll(10);
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            game.Roll(4);
            game.Roll(5);
            game.Roll(3);
            game.Roll(7);
            game.Roll(10);
            
            game.PrintScoreInConsole();
            Console.WriteLine($"Total score: {game.Score()}");
        }
    }
}
