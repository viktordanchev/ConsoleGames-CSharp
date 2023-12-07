using SimpleSnake.Constants;

namespace SimpleSnake.Models
{
    public class Food
    {
        private const char Symbol = '@';

        public Food()
        {
            Position = new();
        }

        public Position Position { get; }

        public void PlaceFoodOnBoard(Snake snake)
        {
            int row = 0;
            int col = 0;
            var random = new Random();

            do
            {
                row = random.Next(1, Constant.RowIndex - 1);
                col = random.Next(1, Constant.ColumnIndex - 1);
            } while (snake.SnakeBody.Any(p => p.Row == row && p.Col == col));

            if (Position.Row == 0 && Position.Col == 0)
            {
                Console.SetCursorPosition(col, row);
                Console.Write(Symbol);
                Position.Row = row;
                Position.Col = col;
            }
        }
    }
}
