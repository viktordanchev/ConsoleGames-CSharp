using TicTacToe.Core.Interfaces;
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
            int count = 0;
            char symbol = ' ';

            while (true)
            {
                Console.WriteLine(OutputMessages.WelcomeToTheGame);
                Console.WriteLine(PrintGameRules());

                board.DrawBoard();

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

                if (board.WinnerCheck() || count == 8)
                {
                    Console.WriteLine(OutputMessages.PrintWinner, symbol);
                    Console.WriteLine("Wants to continue? y/n");

                    char command = char.Parse(Console.ReadLine());

                    if (command == 'y')
                    {

                    }
                }

                if (count % 2 == 0)
                    symbol = 'X';
                else
                    symbol = 'O';

                board.SetSymbol(symbol, position);
                count++;

                Console.Clear();
            }
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

            string boardExample =  Environment.NewLine + 
                "1 | 2 | 3" + Environment.NewLine +
                "---------" + Environment.NewLine +
                "4 | 5 | 6" + Environment.NewLine +
                "---------" + Environment.NewLine +
                "7 | 8 | 9" + Environment.NewLine;

            rules += boardExample;

            return rules;
        }
    }
}
