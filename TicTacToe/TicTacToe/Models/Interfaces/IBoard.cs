namespace TicTacToe.Models.Interfaces
{
    public interface IBoard
    {
        void DrawBoard();
        void CreateBoard();
        bool WinnerCheck();
        void SetSymbol(char symbol, char position);
    }
}
