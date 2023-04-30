using SimpleSnake.Utilities;
using Snake.Core;
using Snake.Core.Interfaces;

namespace Snake
{
    internal class Start
    {
        static void Main(string[] args)
        {
            ConsoleWindow.CustomizeConsole();
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}