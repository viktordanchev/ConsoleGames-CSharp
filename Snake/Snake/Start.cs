using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake
{
    public class Start
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}