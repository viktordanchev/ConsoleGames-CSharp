using Snake.Core;
using Snake.Core.Interfaces;

namespace Snake
{
    internal class Start
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}