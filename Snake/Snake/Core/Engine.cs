using Snake.Core.Interfaces;
using Snake.Models;

namespace Snake.Core
{
    public class Engine : IEngine
    {
        private Board board;
        private SnakeBody snakeBody;

        public Engine()
        {
            board = new Board(20, 40);
            snakeBody = new SnakeBody();
        }

        public void Run()
        {
            board.DrawBoard();

            while (true)
            {
                Console.SetCursorPosition(41, 0);
                Console.Write("score");
                Console.CursorVisible = false;

                Thread.Sleep(100);
            }
        }
    }
}
