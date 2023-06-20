using SimpleSnake.Enums;

namespace SimpleSnake.Models
{
    public class Snake
    {
        private const char BodySymbol = '\u25CF';
        private const char HeadSymbol = '\u263B';

        public Snake()
        {
            Row = 1;
            Col = 20;
            TailPosition = new();
            HeadPosition = new();
            SnakeBody = new List<Position>();
        }

        public List<Position> SnakeBody { get; }
        private int Row { get; set; }
        private int Col { get; set; }
        private Position TailPosition { get; set; }
        private Position HeadPosition { get; set; }

        public void CreateSnake(GameBoard board)
        {
            char symbol = BodySymbol;

            for (int i = 1; i <= 6; i++)
            {
                if (i == 6)
                {
                    HeadPosition.Row = Row;
                    HeadPosition.Col = Col;
                    symbol = HeadSymbol;
                }
                else if (TailPosition.Row == 0 || TailPosition.Col == 0)
                {
                    TailPosition.Row = Row;
                    TailPosition.Col = Col;
                }

                board.Board[Row, Col] = symbol;
                SnakeBody.Add(new(Row, Col));
                Row++;
            }
        }

        public void Move(Direction direction, GameBoard board)
        {
            Position newTailPosition = SnakeBody[1];
            SnakeBody.RemoveAt(0);
            board.Board[HeadPosition.Row, HeadPosition.Col] = BodySymbol;
            board.Board[TailPosition.Row, TailPosition.Col] = ' ';
            TailPosition = newTailPosition;

            if (direction == Direction.Right)
            {
                Col++;
            }
            else if (direction == Direction.Left)
            {
                Col--;
            }
            else if (direction == Direction.Down)
            {
                Row++;
            }
            else if (direction == Direction.Up)
            {
                Row--;
            }

            board.Board[Row, Col] = HeadSymbol;
            SnakeBody.Add(new(Row, Col));
            HeadPosition = SnakeBody[5];
        }

        public void Eat(Food food, GameBoard board)
        {
            if (HeadPosition == food.Position)
            {
                board.Board[TailPosition.Row, TailPosition.Col] = ' ';
                TailPosition = newTailPosition;
            }
        }
    }
}
