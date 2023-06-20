namespace SimpleSnake.Models
{
    public class GameBoard
    {
        private const char Symbol = '\u2588';

        private char[,] board;

        public GameBoard(int rows, int cols)
        {
            board = new char[rows, cols];
            CreateBoard(Board);
        }

        public char[,] Board 
        {
            get => board;
        }

        public void DrawBoard()
        {
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    Console.Write(Board[row, col]);
                }

                Console.WriteLine();
            }
        }

        public bool IsBoardHasFood(char symbol)
        {
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    if (Board[row, col] == symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CreateBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (row == 0 || row == board.GetLength(0) - 1)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        board[row, col] = Symbol;
                    }

                    continue;
                }

                board[row, 0] = Symbol;
                board[row, board.GetLength(1) - 1] = Symbol;

                for (int col = 1; col < board.GetLength(1) - 1; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
    }
}
