using System;

namespace TicTacToe {
    public class Cursor {
        private Position pos;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TicTacToe.Cursor" /> class
        ///     with custom border size, packed within input parameter.
        /// </summary>
        /// <param name="borders">Borders.</param>
        public Cursor() {
            // set start position for the cursor, taking into account
            // offset of the game area borders.
            pos = new Position(Constants.MIN_X, Constants.MIN_Y);
        }

        /// <summary>
        ///     Implicit conversion to a Position, taking into account
        ///     difference between game area coordinates and screen
        ///     coordinates (which might be effected by borders).
        /// </summary>
        public static implicit operator Position(Cursor cursor) {
            return new Position(
                cursor.pos.X - Constants.MIN_X,
                cursor.pos.Y - Constants.MIN_Y);
        }

        public void MoveUp() {
            if (pos.Y > Constants.MIN_Y) {
                pos.Y -= 1;
            }
        }

        public void MoveLeft() {
            if (pos.X > Constants.MIN_X) {
                pos.X -= 1;
            }
        }

        public void MoveDown() {
            if (pos.Y < Constants.MAX_Y) {
                pos.Y += 1;
            }
        }

        public void MoveRight() {
            if (pos.X < Constants.MAX_X) {
                pos.X += 1;
            }
        }

        /// <summary>
        ///     Draw a cursor at its current position.
        /// </summary>
        public void Draw() {
            Console.SetCursorPosition(pos.X, pos.Y);
        }
    }
}