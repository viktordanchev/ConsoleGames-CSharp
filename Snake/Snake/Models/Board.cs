using System.Linq.Expressions;

namespace Snake.Models
{
    public class Board
    {
        private const char Symbol = '\u25A0';

        public Board()
        {
            DrawBoard();
        }

        private void DrawBoard()
        {
            for (int horizontal = 0; horizontal < 40; horizontal++)
            {
                Console.Write(Symbol);
            }

            Console.WriteLine();

            for (int vertical = 1; vertical < 15; vertical++)
            {
                Console.WriteLine(Symbol);
            }

            for(int horizontal = 0; horizontal < 40; horizontal++)
            {
                Console.Write(Symbol);
            }
        }
    }
}
