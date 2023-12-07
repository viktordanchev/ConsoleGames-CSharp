using SimpleSnake.Enums;
using SimpleSnake.Constants;

namespace SimpleSnake.Models
{
    public class Snake
    {
        private const char BodySymbol = '\u25CF';
        private const char HeadSymbol = '\u263B';

        public Snake(int row, int col)
        {
            Row = row;
            Col = col;
            SnakeBody = new List<Position>();
        }

        public List<Position> SnakeBody { get; }
        public int Score { get; private set; }
        private int Row { get; set; }
        private int Col { get; set; }

        public void CreateSnake()
        {
            char symbol = BodySymbol;

            for (int row = 1; row <= Constant.SnakeStartLength; row++)
            {
                if (row == Constant.SnakeStartLength)
                {
                    symbol = HeadSymbol;
                }

                Console.SetCursorPosition(Col, row);
                Console.Write(symbol);
                SnakeBody.Add(new(row, Col));
            }
        }

        public void Move()
        {
            Position tailPosition = SnakeBody[0];
            Position headPosition = SnakeBody[SnakeBody.Count - 1];
            Console.SetCursorPosition(headPosition.Col, headPosition.Row);
            Console.Write(BodySymbol);
            Console.SetCursorPosition(tailPosition.Col, tailPosition.Row);
            Console.Write(' ');

            Console.SetCursorPosition(Col, Row);
            Console.Write(HeadSymbol);
            SnakeBody.Add(new(Row, Col));
        }

        public void Eat(Food food)
        {
            Position headPosition = SnakeBody[SnakeBody.Count - 1];
            Position tailPosition = SnakeBody[0];

            if (headPosition.Row == food.Position.Row && headPosition.Col == food.Position.Col)
            {
                Console.SetCursorPosition(tailPosition.Col, tailPosition.Row);
                Console.Write(BodySymbol);
                food.Position.Row = 0;
                food.Position.Col = 0;
                Score++;
            }
            else
            {
                SnakeBody.RemoveAt(0);
            }
        }

        public bool IsMoving(GameBoard board)
        {
            Position headPosition = SnakeBody[SnakeBody.Count - 1];
            SnakeBody.RemoveAt(SnakeBody.Count - 1);

            if (Row == 0 || Row == Constant.RowIndex - 1 || Col == 0 || Col == Constant.ColumnIndex - 1 ||
                SnakeBody.Any(p => p.Row == headPosition.Row && p.Col == headPosition.Col))
            {
                return false;
            }

            SnakeBody.Add(headPosition);
            return true;
        }

        public void GetDirection(Direction direction)
        {
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
        }
    }
}
