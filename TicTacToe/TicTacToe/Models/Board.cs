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

            Console.WriteLine();
        }

        public bool WinnerCheck()
        {
            if (CheckRows() || CheckCols() || CheckDiagonals())
                return true;

            return false;
        }

        public void SetSymbol(char symbol, int position)
        {
            int count = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (row % 2 != 0)
                    continue;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == '-' || board[row, col] == 'X' || board[row, col] == 'O')
                        count++;

                    if (count == position)
                    {
                        if (board[row, col] != '-')
                            throw new ArgumentException(ExceptionMessages.AlreadyFilled);

                        board[row, col] = symbol;
                        return;
                    }
                }
            }
        }

        public void ResetBoard()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            char[,] board =
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
            if (countX == 3 || countO == 3)
                return true;

            return false;
        }
    }
}
