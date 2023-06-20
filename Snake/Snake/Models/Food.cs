namespace SimpleSnake.Models
{
    public class Food
    {
        private const char Symbol = '@';

        public Position Position { get; }

        public void PlaceFoodOnBoard(GameBoard board)
        {
            int row = 0;
            int col = 0;
            var random = new Random();

            do
            {
                row = random.Next(1, 19);
                col = random.Next(1, 39);
            } while (board.Board[row, col] != ' ');

            if (!board.IsBoardHasFood(Symbol))
            {
                board.Board[row, col] = Symbol;
                Position.Row = row;
                Position.Col = col;
            }
        }
    }
}
