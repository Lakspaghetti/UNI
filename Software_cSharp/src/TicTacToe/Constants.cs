namespace TicTacToe {
    /// <summary>
    ///     Constants used in the game.
    ///     Defines size of the game board.
    /// </summary>
    public static class Constants {
        public const int SIZE = 3;
        public const int MAX_INDEX = Constants.SIZE - 1;

        public const int MIN_X = 1;
        public const int MAX_X = Constants.MIN_X + Constants.SIZE - 1;
        public const int MIN_Y = 7;
        public const int MAX_Y = Constants.MIN_Y + Constants.SIZE - 1;
    }
}