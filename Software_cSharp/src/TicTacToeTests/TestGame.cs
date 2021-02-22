using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    public class TestGame {
        private Game game;

        [SetUp]
        public void CreateBoard() {
            game = Game.GetInstance;
            game.Respond('r');
        }

        [Test]
        public void TestInitialCursorPosition() {
            Assert.AreEqual(new Position(0, 0), (Position) game.Cursor);
        }

        [Test]
        public void TestInitialBoardState() {
            Assert.AreEqual(BoardState.Inconclusive, game.Board.State);
        }
    }
}