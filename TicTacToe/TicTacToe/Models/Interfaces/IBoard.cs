namespace TicTacToe.Models.Interfaces
{
    public interface IBoard
    {
        void DrawBoard();
        void SetSymbol(char symbol, string position);
        void ResetBoard();
        bool CheckRows(char symbol);
        bool CheckColumns(char symbol);
        bool CheckDiagonals(char symbol);
    }
}
