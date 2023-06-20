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
            SnakeLength = 6;
            TailPosition = new();
            HeadPosition = new();
        }

        public int SnakeLength { get; }
        private int Row { get; set; }
        private int Col { get; set; }
        private Position TailPosition { get; set; }
        private Position HeadPosition { get; set; }

        public void CreateSnake(GameBoard board)
        {
            char symbol = BodySymbol;

            for (int i = 1; i <= SnakeLength; i++)
            {
                if (i == SnakeLength)
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

                board.AddToBoard(Row++, Col, symbol);
            }
        }

        public void Move(Direction direction, GameBoard board)
        {
            board.Board[HeadPosition.Row, HeadPosition.Col] = BodySymbol;

            if (direction == Direction.Right)
            {
                HeadPosition.Col++;
            }
            else if (direction == Direction.Left)
            {
                HeadPosition.Col--;
            }
            else if (direction == Direction.Down)
            {
                HeadPosition.Row++;
            }
            else if (direction == Direction.Up)
            {
                HeadPosition.Row--;
            }

            board.AddToBoard(HeadPosition.Row, HeadPosition.Col, HeadSymbol);
        }
    }
}
