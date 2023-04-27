namespace TicTacToe.Messages
{
    public class OutputMessages
    {
        public const string WelcomeToTheGame = "--->Welcome to TicTacToe<---";
        public const string FirstGameRule = "1. Play occurs on a 3 by 3 grid of 9 squares.";
        public const string SecondGameRule = "2. Two players take turns marking empty squares, the first marking X's, the second O's.";
        public const string ThirdGameRule = "3. A row is any three squares on the grid, adjacent diagonally, vertically or horizontally.";
        public const string FourthGameRule = "4. If one player places three of the same marks in a row, the player wins.";
        public const string FifthGameRule = "5. If the spaces are all filled and there is no winner, the game ends in a draw.";
        public const string SixthGameRule = "6. To insert a character, select a number from 1 to 9, as shown in the example below.";

        public const string EnterPosition = "Position: ";
        public const string PrintWinner = "The winner is: {0}.";
        public const string PrintDraw = "The game is draw.";

        public const string StartGame = "Press any key to start the game...";
        public const string ContinueGame = "Press any key to continue...";
    }
}
