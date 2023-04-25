using TicTacToe.Messages;
using TicTacToe.Models.Interfaces;

namespace TicTacToe.Models
{
    public class Board : IBoard
    {
        private char[,] board;

        public Board()
        {
            CreateBoard();
        }

        public void DrawBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }

                Console.WriteLine();
            }
        }

        public bool WinnerCheck()
        {
            if (CheckRows() || CheckCols() || CheckDiagonals())
                return true;
            else
                return false;
        }

        public void SetSymbol(char symbol, int position)
        {
            char currPosition = char.Parse(position.ToString());

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == symbol)
                    {
                        Console.WriteLine(ExceptionMessages.AlreadyFilled);
                    }

                    if (board[row, col] == currPosition)
                    {
                        board[row, col] = symbol;
                        return;
                    }
                }
            }
        }

        private void CreateBoard()
        {
            char [,] board = 
            {
                {'-', ' ', '|', ' ', '-', ' ', '|', ' ', '-' },
                {'-', '-', '-', '-', '-', '-', '-', '-', '-' },
                {'-', ' ', '|', ' ', '-', ' ', '|', ' ', '-' },
                {'-', '-', '-', '-', '-', '-', '-', '-', '-' },
                {'-', ' ', '|', ' ', '-', ' ', '|', ' ', '-' }
            };

            this.board = board;
        }

        private bool CheckRows()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                int countX = 0;
                int countO = 0;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 'X')
                        countX++;
                    else if (board[row, col] == 'O')
                        countO++;
                }

                if (countX == 3 || countO == 3)
                    return true;
            }

            return false;
        }

        private bool CheckCols()
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                int countX = 0;
                int countO = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] == 'X')
                        countX++;
                    else if (board[row, col] == 'O')
                        countO++;
                }

                if (countX == 3 || countO == 3)
                    return true;
            }

            return false;
        }

        private bool CheckDiagonals()
        {
            for (int i = 0; i < 2; i++)
            {
                int countX = 0;
                int countO = 0;

                for (int y = 0; y < board.GetLength(0); y++)
                {
                    if (board[y, y] == 'X')
                        countX++;
                    else if (board[y, y] == 'O')
                        countO++;
                }

                if (countX == 3 || countO == 3)
                    return true;
            }

            return false;
        }
    }
}
