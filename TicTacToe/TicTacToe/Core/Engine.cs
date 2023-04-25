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
    }
}
