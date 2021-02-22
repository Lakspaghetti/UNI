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
            Assert.True(cross.Move('s'));
            Assert.True(circle.Move('k'));
        }

        public void TestMoveUp() {
            Assert.True(cross.Move('w'));
            Assert.True(circle.Move('i'));
        }

        public void TestMoveLeft() {
            Assert.True(cross.Move('a'));
            Assert.True(cross.Move('j'));
        }

        public void TestMoveRight() {
            Assert.True(cross.Move('d'));
            Assert.True(cross.Move('l'));
        }
        public void fail() {
            Assert.False(cross.Move('z'));
            Assert.False(cross.Move('z'));
        }
    }
}