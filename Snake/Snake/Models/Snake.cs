using SimpleSnake.Enums;

namespace SimpleSnake.Models
{
    public class Snake
    {
        private const char BodySymbol = '\u25CF';
        private const char HeadSymbol = '\u263B';

        public void PlaceSnakeOnBoard(GameBoard board)
        {
            int row = 1;
            int col = 20;

            for (int i = 1; i <= 6; i++)
            {
                if (i == 6)
                {
                    board.AddToBoard(row++, col, HeadSymbol);
                    continue;
                }

                board.AddToBoard(row++, col, BodySymbol);
            }
        }

        public void Move(Direction direction, GameBoard board)
        {
            int row = 0;
            int col = 0;

            if (direction == Direction.Right)
            {
                col++;
            }
            else if (direction == Direction.Left)
            {
                col--;
            }
            else if (direction == Direction.Down)
            {
                row++;
            }
            else if (direction == Direction.Up)
            {
                row--;
            }

            board.AddToBoard(row, col, HeadSymbol);
        }
    }
}
