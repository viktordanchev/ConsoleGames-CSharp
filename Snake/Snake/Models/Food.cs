namespace SimpleSnake.Models
{
    public class Food
    {
        private const char Symbol = '@';

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

            board.AddToBoard(row, col, Symbol);
        }
    }
}
