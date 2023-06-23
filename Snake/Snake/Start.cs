using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake
{
    public class Start
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}