namespace TicTacToe.Models.Interfaces
{
    public interface IBoard
    {
        void DrawBoard();
        void SetSymbol(char symbol, int position);
        void ResetBoard();
        bool CheckRows();
        bool CheckColumns();
        bool CheckDiagonals();
    }
}
