using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    public class TestCursor {
        private Cursor cursor;

        [SetUp]
        public void CreateBoard() {
            cursor = new Cursor();
        }

        [Test]
        public void TestNoMoves() {
            Position pos = cursor;

            Assert.AreEqual(pos, new Position(0, 0));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveDown(int n) {
            for (var i = 0; i < n; i++) {
                cursor.MoveDown();
            }

            Assert.AreEqual(new Position(0, n), (Position) cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveDownTooMuch(int n) {
            for (var i = 0; i < n; i++) {
                cursor.MoveDown();
            }

            Assert.AreEqual(
                new Position(0, Constants.SIZE - 1),
                (Position) cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveUp(int n) {
            Position origin = cursor;

            for (var i = 0; i < n; i++) {
                cursor.MoveDown();
            }

            for (var i = 0; i < n; i++) {
                cursor.MoveUp();
            }

            Assert.AreEqual(origin, (Position) cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveUpTooMuch(int n) {
            Position origin = cursor;

            for (var i = 0; i < n; i++) {
                cursor.MoveDown();
            }

            for (var i = 0; i < n; i++) {
                cursor.MoveUp();
            }

            Assert.AreEqual(origin, (Position) cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveRight(int n) {
            for (var i = 0; i < n; i++) {
                cursor.MoveRight();
            }

            Assert.AreEqual(new Position(n, 0), (Position) cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveRightTooMuch(int n) {
            for (var i = 0; i < n; i++) {
                cursor.MoveRight();
            }

            Assert.AreEqual(
                new Position(Constants.SIZE - 1, 0),
                (Position) cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveLeft(int n) {
            Position origin = cursor;

            for (var i = 0; i < n; i++) {
                cursor.MoveRight();
            }

            for (var i = 0; i < n; i++) {
                cursor.MoveLeft();
            }

            Assert.AreEqual(origin, (Position) cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveLeftTooMuch(int n) {
            Position origin = cursor;

            for (var i = 0; i < n; i++) {
                cursor.MoveRight();
            }

            for (var i = 0; i < n; i++) {
                cursor.MoveLeft();
            }

            Assert.AreEqual(origin, (Position) cursor);
        }
    }
}