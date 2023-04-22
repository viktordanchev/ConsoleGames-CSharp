using TicTacToe.Core.Interfaces;
using TicTacToe.IO;
using TicTacToe.IO.Interfaces;
using TicTacToe.Messages;

namespace TicTacToe.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine()
        {
            writer = new Writer();
            reader = new Reader();
        }

        public void Run()
        {
            writer.WriteLine(OutputMessages.WelcomeToTheGame);

            Console.Clear();
        }
    }
}
