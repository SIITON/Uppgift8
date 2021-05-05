using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift8.Bowling
{
    public class BowlingGame2 : IBowlingGame
    {
        private int[] _rolls;
        private int _turn;

        public BowlingGame2()
        {
            _rolls = new int[21];
            _turn = 0;
        }
        public void Roll(int pins_striked)
        {
            _rolls[_turn] = pins_striked;
            _turn++;
        }

        public int Score()
        {
            int score = 0;
            int rollNum = 0;
            for (int frameIdx = 0; frameIdx < 10; frameIdx++)
            {
                if (_rolls[rollNum] == 10) // Strike
                {
                    score += 10 + _rolls[rollNum + 1] + _rolls[rollNum + 2];
                    rollNum++;
                }
                else if (_rolls[rollNum] + _rolls[rollNum + 1] == 10) // Spare
                {
                    score += 10 + _rolls[rollNum + 2];
                    rollNum += 2;
                }
                else
                {
                    score += _rolls[rollNum] + _rolls[rollNum + 1];
                    rollNum += 2;
                }
            }
            return score;
        }
        public void PrintScoreInConsole()
        {
            int[] score = new int[10];
            int rollNum = 0;
            Console.WriteLine("   1     2     3     4     5     6     7     8     9     10");
            Console.WriteLine("+-----+-----+-----+-----+-----+-----+-----+-----+-----+--+----+");
            // First line, pins knocked
            for (int frameIdx = 0; frameIdx < 10; frameIdx++)
            {
                Console.Write("|");
                if (_rolls[rollNum] == 10) // Strike
                {
                    var points = 10 + _rolls[rollNum + 1] + _rolls[rollNum + 2];
                    score[frameIdx] = 10 + _rolls[rollNum + 1] + _rolls[rollNum + 2];
                    rollNum++;
                    if (frameIdx != 9) // The tenth frame
                    {
                        Console.Write("    X");
                    }
                    else
                    {
                        Console.Write(" X");
                        Console.Write($" {_rolls[rollNum]} {_rolls[rollNum + 1]}");
                    }
                }
                else if (_rolls[rollNum] + _rolls[rollNum + 1] == 10) // Spare
                {
                    Console.Write($" {_rolls[rollNum]}  /");
                    rollNum += 2;
                    if (frameIdx == 9)
                    {
                        //Console.Write($" {_rolls[rollNum]} /");
                        if (_rolls[rollNum] == 10)
                        {
                            Console.Write($" X");
                        }
                        else
                        {
                            Console.Write($" {_rolls[rollNum]}");
                        }
                    }
                }
                else
                {
                    Console.Write($" {_rolls[rollNum]}  {_rolls[rollNum + 1]}");
                    rollNum += 2;
                }

            }
            
            Console.Write("|");
            Console.WriteLine();
            // Second line (running total score)
            score = new int[10];
            int runningScore = 0;
            rollNum = 0;
            for (int frameIdx = 0; frameIdx < 10; frameIdx++)
            {
                Console.Write("|");
                if (_rolls[rollNum] == 10) // Strike
                {
                    runningScore += 10 + _rolls[rollNum + 1] + _rolls[rollNum + 2];
                    rollNum++;
                }
                else if (_rolls[rollNum] + _rolls[rollNum + 1] == 10) // Spare
                {
                    runningScore += 10 + _rolls[rollNum + 2];
                    rollNum += 2;
                }
                else
                {
                    runningScore += _rolls[rollNum] + _rolls[rollNum + 1];
                    rollNum += 2;
                }
                Console.Write("  {0,3}", runningScore);
            }
            Console.Write("  |");
            Console.WriteLine("\n+-----+-----+-----+-----+-----+-----+-----+-----+-----+-------+");
        }
    }
}
