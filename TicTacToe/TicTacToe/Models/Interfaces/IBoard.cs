namespace TicTacToe.Models.Interfaces
{
    public interface IBoard
    {
        void DrawBoard();
        bool WinnerCheck();
        void SetSymbol(char symbol, int position);
        void ResetBoard();
    }
}
