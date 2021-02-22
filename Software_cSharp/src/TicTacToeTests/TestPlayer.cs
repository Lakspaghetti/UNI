using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    public class TestPlayer {
        private Cross cross;
        private Circle circle;

        [SetUp]
        public void CreatePlayers() {
            cross = Cross.GetInstance;
            circle = Circle.GetInstance;
        }

        [Test]
        public void TestMoveDown() {
            Assert.True(cross.Move('k'));
        }
    }
}