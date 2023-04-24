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
            Console.WriteLine(OutputMessages.WelcomeToTheGame);
            Console.WriteLine(OutputMessages.GameRules);
            board.DrawBoard();

            int count = 0;
            char symbol = ' ';
            char position = char.Parse(Console.ReadLine());
            while (count != 8)
            {
                if (board.WinnerCheck())
                {
                    break;
                }

                Console.WriteLine(OutputMessages.ChosePosition);
                position = char.Parse(Console.ReadLine());

                if (position < 0 || position > 8)


                if (count % 2 == 0)
                    symbol = 'X';
                else
                    symbol = 'O';

                board.SetSymbol(symbol, position);
                count++;
            }
        }
    }
}
