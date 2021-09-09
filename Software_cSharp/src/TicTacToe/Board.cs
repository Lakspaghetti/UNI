using System;
using System.Collections.Generic;

namespace TicTacToe {
    /// <summary>
    ///     State machine class. Maintains an internal game board
    ///     which it can draw, place turns in, and check if a
    ///     game is won.
    /// </summary>
    public class Board {
        private Cell[,] cells;
        private int max_places = Constants.SIZE * Constants.SIZE;

        private int n_places;

        public Board() {
            cells = new Cell[Constants.SIZE, Constants.SIZE];
            State = BoardState.Inconclusive;
        }

        public BoardState State { get; private set; }

        /// <summary>
        ///     Places a circle at the specified position
        ///     if that position is empty.
        /// </summary>
        public bool PlayCircle(Position pos) {
            return PlayCircle(ref cells[pos.Y, pos.X]);
        }

        private bool PlayCircle(ref Cell cell) {
            var retval = false;

            switch (cell) {
            case Cell.Empty:
                n_places += 1;
                cell = Cell.Circle;
                retval = true;
                // After implementing the method CheckGameEnded(), uncomment below:
                CheckGameEnded();
                break;
            }

            return retval;
        }

        /// <summary>
        ///     Places a cross at the specified position
        ///     if that position is empty.
        /// </summary>
        public bool PlayCross(Position pos) {
            return PlayCross(ref cells[pos.Y, pos.X]);
        }

        private bool PlayCross(ref Cell cell) {
            var retval = false;

            switch (cell) {
            case Cell.Empty:
                n_places += 1;
                cell = Cell.Cross;
                retval = true;
                // After implementing the method CheckGameEnded(), uncomment below:
                CheckGameEnded();
                break;
            }

            return retval;
        }

        /// <summary>
        /// Determines if either player has 3-in-a-row,
        /// in which case the game is over.
        /// </summary>
        private void CheckGameEnded() {
            if (IsGameOver (Cell.Circle)) {
                State = BoardState.Circle_Wins;
            }
            else if (IsGameOver (Cell.Cross)) {
                State = BoardState.Cross_Wins;
            }
            else if (n_places == 9) {
                State = BoardState.Tied;
            }
        }
        /// <summary>
        /// check all possible combinations for the target cell
        /// of winning the game (row, column, or slope).
        /// </summary>
        private bool IsGameOver (Cell cell) {
            for (var i = 0; i < Constants.SIZE; i++) {
                for (var j = 0; j < Constants.SIZE; j++) {
                    if (i == 1 && j == 1) {
                        if (cells[i, j] == cell && cells[i - 1, j - 1] == cell && cells[i + 1, j + 1] == cell) { //diagonal win
                            return true;
                        } //else if to keep the line below 100 characters
                        else if (cells[i, j] == cell && cells[i - 1, j + 1] == cell && cells[i + 1, j - 1] == cell) { //diagonal win
                            return true;
                        }
                    }
                    if (i == 1) {
                        if (cells[i, j] == cell && cells[i - 1, j] == cell && cells[i + 1, j] == cell) { //horizontal win
                            return true;
                        }
                    }
                    if (j == 1){
                        if (cells[i, j] == cell && cells[i, j + 1] == cell && cells[i, j - 1] == cell) { //vertical win
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///     Draw the game board with its associated borders.
        /// </summary>
        public void Draw() {
            Console.WriteLine("+---+");
            for (var i = 0; i < Constants.SIZE; i++) {
                Console.Write("|");
                for (var j = 0; j < Constants.SIZE; j++) {
                    cells[i, j].Draw();
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("+---+");
        }
    }
}