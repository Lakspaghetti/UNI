using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    public class TestGameCircle {
        private Game game;

        [SetUp]
        public void CreateBoard() {
            game = Game.GetInstance;
            game.Respond('r');
        }

        [Test]
        public void TestMoveDown() {
            game.Respond('k');
            Assert.AreEqual(new Position(0, 1), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveUp() {
            game.Respond('k');
            game.Respond('i');
            Assert.AreEqual(new Position(0, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveRight() {
            game.Respond('l');
            Assert.AreEqual(new Position(1, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestMoveLeft() {
            game.Respond('l');
            game.Respond('j');
            Assert.AreEqual(new Position(0, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestRowWin() {
            game.Respond(' ');
            game.Respond('s');
            game.Respond(' ');
            game.Respond('i');
            game.Respond('l');
            game.Respond(' ');
            game.Respond('s');
            game.Respond(' ');
            game.Respond('i');
            game.Respond('l');
            game.Respond(' ');
            Assert.AreEqual(BoardState.Circle_Wins, game.Board.State);
        }
    }
}