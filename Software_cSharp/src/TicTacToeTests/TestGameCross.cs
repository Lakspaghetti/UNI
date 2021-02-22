using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    public class TestGameCross {
        private Game game;

        [SetUp]
        public void CreateBoard() {
            game = Game.GetInstance;
            game.Respond('r');
            game.Respond(' ');
        }

        [Test]
        public void TestMoveDown() {
            game.Respond('s');
            Assert.AreEqual(new Position(0, 1), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveUp() {
            game.Respond('s');
            game.Respond('w');
            Assert.AreEqual(new Position(0, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveRight() {
            game.Respond('d');
            Assert.AreEqual(new Position(1, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveLeft() {
            game.Respond('d');
            game.Respond('a');
            Assert.AreEqual(new Position(0, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestRowWin() {
            game.Respond('s');
            game.Respond(' ');
            game.Respond('k');
            game.Respond(' ');
            game.Respond('w');
            game.Respond('d');
            game.Respond(' ');
            game.Respond('i');
            game.Respond('l');
            game.Respond(' ');
            game.Respond('s');
            game.Respond(' ');
            Assert.AreEqual(BoardState.Cross_Wins, game.Board.State);
        }
    }
}