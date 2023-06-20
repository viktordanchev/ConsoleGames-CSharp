using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.Models;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private GameBoard board;
        private Snake snake;
        private Food food;
        private Direction direction;

        public Engine()
        {
            board = new GameBoard(20, 40);
            snake = new Snake();
            food = new Food();
            direction = Direction.Right;
        }

        public void Run()
        {
            snake.CreateSnake(board);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetDirection();
                }

                food.PlaceFoodOnBoard(board);
                snake.Move(direction, board);
                board.DrawBoard();

                Thread.Sleep(300);
                Console.Clear();
            }
        }

        private void GetDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
        }
    }
}
