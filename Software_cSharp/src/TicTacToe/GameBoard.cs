using System;

namespace TUI
{
    public class GameBoard
    {
        private char[] _board;
        private int _cursor;

        public GameBoard ()
        {
            _cursor = 4;
            _board = new char[9] {
                ' ',' ',' ',
                ' ',' ',' ',
                ' ',' ',' '
            };
        }

        public void MoveCursorUp()
        {
            if (_cursor > 2) {
                _cursor -= 3;
            }
        }
        public void MoveCursorDown()
        {
            if (_cursor < 6) {
                _cursor += 3;
            }
        }
        public void MoveCursorLeft()
        {
            if ((_cursor % 3) > 0) {
                _cursor -= 1;
            }
        }
        public void MoveCursorRight()
        {
            if ((_cursor % 3) < 2) {
                _cursor += 1;
            }
        }

        /// <summary>
        /// Inserts the turn if the current position is non-empty.
        /// </summary>
        /// <param name="piece">Piece.</param>
        public void InsertTurn(char piece)
        {
            if (CanInsert ())
            {
                _board [_cursor] = piece;
            }

        }

        /// <summary>
        /// Determines whether a GameBoard can insert at its current cursor position.
        /// </summary>
        public bool CanInsert()
        {
            return _board [_cursor] == ' ';
        }

        /// <summary>
        /// Prints board to terminal with borders all way round.
        /// </summary>
        public void PrintBoard()
        {
            Console.Write ("#===#");
            for (int i = 0; i < 9; i++) {
                if (i == 3 || i == 6)
                {
                    Console.Write ("|");
                }
                if (i % 3 == 0)
                {
                    Console.Write ("\n|");
                }

                if (i == _cursor)
                {
                    if (_board[i] == ' ') {
                        Console.Write ('_');
                    }
                    else
                    {
                        Console.Write (Char.ToUpper (_board [i]));
                    }

                }
                else
                {
                    Console.Write (_board[i]);
                }
            }
            Console.WriteLine ("|\n#===#");
        }
    }
}

