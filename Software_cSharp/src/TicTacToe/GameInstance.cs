using System;

namespace TUI
{
    public enum GameType
    {
        AI, PVP
    };

    public class GameInstance
    {
        private GameBoard _board;

        public GameBoard Board { get { return _board; } }

        private const char _player_1 = 'x';
        private const char _player_2 = 'o';

        // signify if player 1 or player 2 currently has the turn
        // true if player 1, false if player 2
        private bool _player_turn;

        public GameInstance (GameType type)
        {
            _board = new GameBoard ();
            _player_turn = true; // player 1 starts
        }

        public void InsertTurn ()
        {
            if (_player_turn) {
                _board.InsertTurn (_player_1);
            }
            else
            {
                _board.InsertTurn (_player_2);
            }

            _player_turn = !_player_turn; // change player
        }
    }
}
