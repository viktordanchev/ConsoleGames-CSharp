namespace SimpleSnake.Models
{
    public class Position
    {
        public Position()
        {
        }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
