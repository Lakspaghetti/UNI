using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests {
    [TestFixture]
    public class TestBoard : Test {
        // We could use some tests...
        // Make some !!
        //all possible positions on the board
        public Position middle;
        Position right;
        Position top;
        Position topRight;
        Position left;
        Position bottom;
        Position bottomLeft;
        Position bottomRight;
        Position topLeft;
        Board myBoard;

        [SetUp]
        public void positions() {
            middle = new Position (1, 1);
            right = new Position (2, 1);
            left = new Position (0, 1);
            top = new Position (1, 0);
            bottom = new Position (1, 2);
            topRight = new Position (2, 0);
            bottomLeft = new Position (0, 2);
            bottomRight = new Position (2, 2);
            topLeft = new Position (0, 0);

            myBoard = new Board ();
        }

        [Test]
        public void CircleWinLeft () {
            myBoard.PlayCircle (left);
            myBoard.PlayCircle (topLeft);
            myBoard.PlayCircle (bottomLeft);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinRight () {
            myBoard.PlayCircle (right);
            myBoard.PlayCircle (topRight);
            myBoard.PlayCircle (bottomRight);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinTop () {
            myBoard.PlayCircle (top);
            myBoard.PlayCircle (topRight);
            myBoard.PlayCircle (topLeft);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinBottom () {
            myBoard.PlayCircle (bottom);
            myBoard.PlayCircle (bottomRight);
            myBoard.PlayCircle (bottomLeft);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinMidHor () {
            myBoard.PlayCircle (left);
            myBoard.PlayCircle (right);
            myBoard.PlayCircle (middle);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinMidVer () {
            myBoard.PlayCircle (top);
            myBoard.PlayCircle (bottom);
            myBoard.PlayCircle (middle);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinDiagonalOne () {
            myBoard.PlayCircle (topRight);
            myBoard.PlayCircle (bottomLeft);
            myBoard.PlayCircle (middle);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }

        [Test]
        public void CircleWinDiagonalTwo () {
            myBoard.PlayCircle (topLeft);
            myBoard.PlayCircle (bottomRight);
            myBoard.PlayCircle (middle);
            Assert.True(myBoard.State == BoardState.Circle_Wins);
        }


    }
}