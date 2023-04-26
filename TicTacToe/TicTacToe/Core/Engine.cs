﻿using TicTacToe.Core.Interfaces;
using TicTacToe.Messages;
using TicTacToe.Models;
using TicTacToe.Models.Interfaces;

namespace TicTacToe.Core
{
    public class Engine : IEngine
    {
        private readonly IBoard board;

        public Engine()
        {
            board = new Board();
        }

        public void Run()
        {
            Console.WriteLine(OutputMessages.WelcomeToTheGame);
            Console.WriteLine(PrintGameRules());
            Console.Write(OutputMessages.StartGame);
            Console.ReadKey();
            Console.Clear();

            int filledCells = 0;
            int myScore = 0;
            int enemyScore = 0;
            char symbol = ' ';
            int position = 0;

            while (true)
            {
                Console.WriteLine($"Score {myScore}:{enemyScore}");
                Console.WriteLine();

                board.DrawBoard();

                if (board.WinnerCheck() || filledCells == 9)
                {
                    if (board.WinnerCheck())
                    {
                        Console.WriteLine(OutputMessages.PrintWinner, symbol);

                        if (symbol == 'X')
                            myScore++;
                        else
                            enemyScore++;
                    }
                    else
                    {
                        Console.WriteLine(OutputMessages.PrintDraw);
                    }

                    filledCells = 0;

                    ContinueGame();
                    board.ResetBoard();
                    continue;
                }

                if (filledCells % 2 == 0)
                    symbol = 'X';
                else
                    symbol = 'O';

                bool IsNotSet = true;
                do
                {
                    try
                    {
                        position = GetPosition();
                        board.SetSymbol(symbol, position);

                        IsNotSet = false;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (IsNotSet);

                filledCells++;

                Console.Clear();
            }
        }

        private int GetPosition()
        {
            Console.Write(OutputMessages.EnterPosition);
            int position = int.Parse(Console.ReadLine());

            if (position < 1 || position > 9)
            {
                do
                {
                    Console.WriteLine(ExceptionMessages.InvalidNumber);
                    Console.Write(OutputMessages.EnterPosition);
                    position = int.Parse(Console.ReadLine());

                } while (position < 1 || position > 9);
            }

            return position;
        }

        private void ContinueGame()
        {
            Console.Write(OutputMessages.ContinueGame);
            Console.ReadKey();
            Console.Clear();
        }

        private string PrintGameRules()
        {
            string rules = "Rules:" + Environment.NewLine +
                OutputMessages.FirstGameRule + Environment.NewLine +
                OutputMessages.SecondGameRule + Environment.NewLine +
                OutputMessages.ThirdGameRule + Environment.NewLine +
                OutputMessages.FourthGameRule + Environment.NewLine +
                OutputMessages.FifthGameRule + Environment.NewLine +
                OutputMessages.SixthGameRule + Environment.NewLine;

            string boardExample = Environment.NewLine +
                "Example:" + Environment.NewLine +
                "1 | 2 | 3" + Environment.NewLine +
                "---------" + Environment.NewLine +
                "4 | 5 | 6" + Environment.NewLine +
                "---------" + Environment.NewLine +
                "7 | 8 | 9" + Environment.NewLine;

            return rules + boardExample;
        }
    }
}