using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.Models;
using SimpleSnake.Constants;

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
            board = new GameBoard(Constant.RowIndex, Constant.ColumnIndex);
            snake = new Snake(Constant.SnakeStartLength, Constant.ColumnIndex / 2);
            food = new Food();
            direction = Direction.Down;
        }

        public void Run()
        {
            board.DrawBoard();
            snake.CreateSnake();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    CreateDirection();
                }

                snake.GetDirection(direction);

                if (!snake.IsMoving(board))
                {
                    Console.Clear();
                    AskForRestart();
                }

                food.PlaceFoodOnBoard(snake);
                snake.Move();
                snake.Eat(food);

                ShowScore(snake);
                Thread.Sleep(Constant.ThreadSleep);
            }
        }

        private void ShowScore(Snake snake)
        {
            Console.SetCursorPosition(Constant.ColumnIndex + 1, 0);
            Console.WriteLine($"Score: {snake.Score}");
        }

        private void AskForRestart()
        {
            int row = 21;
            int col = 3;

            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(row, col);
                Console.WriteLine("Would you like to restart? y/n");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);

            Console.Clear();

            if (key.Key == ConsoleKey.Y)
            {
                Start.Main();
            }
            else if (key.Key == ConsoleKey.N)
            { 
                Environment.Exit(0);
            }
        }

        private void CreateDirection()
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

            Console.CursorVisible = false;
        }
    }
}
