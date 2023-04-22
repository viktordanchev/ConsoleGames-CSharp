using TicTacToe.Core;
using TicTacToe.Core.Interfaces;

namespace TicTacToe
{
    internal class Start
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}