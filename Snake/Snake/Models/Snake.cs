﻿using SimpleSnake.Enums;

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

        public void CreateSnake(GameBoard board)
        {
            char symbol = BodySymbol;

            for (int row = 1; row <= 6; row++)
            {
                if (row == 6)
                {
                    symbol = HeadSymbol;
                }

                board.Board[row, Col] = symbol;
                SnakeBody.Add(new(row, Col));
            }
        }

        public void Move(GameBoard board)
        {
            Position tailPosition = SnakeBody[0];
            Position headPosition = SnakeBody[SnakeBody.Count - 1];
            board.Board[headPosition.Row, headPosition.Col] = BodySymbol;
            board.Board[tailPosition.Row, tailPosition.Col] = ' ';

            board.Board[Row, Col] = HeadSymbol;
            SnakeBody.Add(new(Row, Col));
            headPosition = SnakeBody[SnakeBody.Count - 1];
        }

        public void Eat(Food food, GameBoard board)
        {
            Position headPosition = SnakeBody[SnakeBody.Count - 1];
            Position tailPosition = SnakeBody[0];

            if (headPosition.Row == food.Position.Row && headPosition.Col == food.Position.Col)
            {
                board.Board[tailPosition.Row, tailPosition.Col] = BodySymbol;
                Score++;
            }
            else
            {
                SnakeBody.RemoveAt(0);
            }
        }

        public bool IsMoving()
        {
            if (Row == 0 || Row == 19 || Col == 0 || Col == 39)
            {
                return false;
            }

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
