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
            snake = new Snake(6, 20);
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

                food.PlaceFoodOnBoard(board);
                snake.Move();
                snake.Eat(food);

                ShowScore(snake);
                Thread.Sleep(150);
            }
        }

        private void ShowScore(Snake snake)
        {
            Console.SetCursorPosition(41, 0);
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
