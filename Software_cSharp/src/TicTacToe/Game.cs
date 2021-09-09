using System;

namespace TicTacToe {
    public class Game {
        private static readonly Game S_INSTANCE = new Game();

        private bool gameRunning = true;
        private Player player;

        private Game() {
            Restart();
        }

        public Board Board { get; private set; }

        public Cursor Cursor { get; private set; }

        public static Game GetInstance { get; } = Game.S_INSTANCE;

        private void Play() {
            player = player.Play();
        }

        private void Restart() {
            Cursor = new Cursor();
            Board = new Board();
            player = Circle.GetInstance;
        }

        private void Quit() {
            Console.Clear();
            Console.WriteLine("\nGood bye !");
            Environment.Exit(0);
        }

        /// <summary>
        ///     Moves according to the specified key, taking into account
        ///     which player currently has the turn.
        /// </summary>
        private void Move(int key) {
            player.Move(key);
        }

        /// <summary>
        ///     Simple key event handler.
        /// </summary>
        /// <param name="key">Key character</param>
        public void Respond(int key) {
            switch (key) {
            case ' ':
                Play();
                break;
            case 'r':
                Restart();
                break;
            case 'q':
                Quit();
                break;
            default:
                Move(key);
                break;
            }
        }

        private void DrawTitle() {
            Console.WriteLine("TIC-TAC-TOE\n");
        }

        private void DrawHelp() {
            player.DrawHelp();
        }

        private void DrawGameTied() {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("The game was a tie!");
        }

        private void DrawCircleWins() {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Circle Wins!");
        }

        private void DrawCrossWins() {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Cross Wins!");
        }

        /// <summary>
        ///     Fetches the current status of the game from the
        ///     state machine. A game can be either running or ended.
        /// </summary>
        private void CheckGameRunning() {
            switch (Board.State) {
            case BoardState.Tied:
                gameRunning = false;
                DrawGameTied();
                break;
            case BoardState.Circle_Wins:
                gameRunning = false;
                DrawCircleWins();
                break;
            case BoardState.Cross_Wins:
                gameRunning = false;
                DrawCrossWins();
                break;
            case BoardState.Inconclusive:
                break;
            }
        }

        /// <summary>
        ///     Draw the game by calling the constituent draw methods in order.
        /// </summary>
        private void Draw() {
            Console.Clear();
            DrawTitle();
            DrawHelp();

            CheckGameRunning();

            Board.Draw();
            Cursor.Draw();
        }

        /// <summary>
        ///     Game loop. Called from Main method.
        ///     Starts a game and keeps it running until closed.
        /// </summary>
        public void Interact() {
            int key;
            while (gameRunning) {
                Draw();
                CheckGameRunning();
                // Should fix issue with windows consoles in 'cooked' mode.
                // key = Console.Read()
                key = Console.ReadKey().KeyChar;
                Respond(key);
            }
        }
    }
}