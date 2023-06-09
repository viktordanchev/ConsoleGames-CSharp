namespace Snake.Models
{
    public class Board
    {
        private char[,] board;

        public Board(int rows, int cols)
        {
            board = new char[rows, cols];
            CreateBoard(board);
        }

        private void CreateBoard(char[,] board)
        {
            char symbol = ' ';

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        symbol = '\u2554';
                        //u2554 = ╔
                    }
                    else if (row == 0 && col == board.GetLength(1))
                    {
                        symbol = '\u2557';
                        //u2557 = ╗
                    }
                    else if (row)
                    {

                    }
                }
            }
        }

        private void SetHorizontal()
        {
            char symbol = ' ';

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (col == 0)
                {
                    symbol = '\u2554';
                    //u2554 = ╔
                }
                else if (col == board.GetLength(1))
                {
                    symbol = '\u2557';
                    //u2554 = ╗
                }
                else
                {
                    symbol = '\u2550';
                    //u2550 = ═
                }

                board[row, col] = symbol;
            }
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
    }
}
