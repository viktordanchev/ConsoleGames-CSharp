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

        public void SetSymbol(char symbol, string position)
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

                    if (count == int.Parse(position))
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

        public bool CheckRows(char symbol)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                int count = 0;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == symbol)
                        count++;
                }

                if (count == 3)
                    return true;
            }

            return false;
        }

        public bool CheckColumns(char symbol)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                int count = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] == symbol)
                        count++;
                }

                if (count == 3)
                    return true;
            }

            return false;
        }

        public bool CheckDiagonals(char symbol)
        {
            if (board[0, 0] == symbol && board[2, 4] == symbol && board[4, 8] == symbol)
                return true;

            if (board[0, 8] == symbol && board[2, 4] == symbol && board[4, 0] == symbol)
                return true;

            return false;
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
    }
}
