using System.Collections.Generic;
using FsCheck;
using TicTacToe;

namespace TicTacToeTests {
    public abstract class Test {
        private Random.StdGen random;
        private int size;

        public Test() {
            random = Random.mkStdGen(1000);
            size = 10;
        }

        protected Gen<Position> Position =>
            from x in Gen.Choose(0, Constants.SIZE - 1)
            from y in Gen.Choose(0, Constants.SIZE - 1)
            select new Position(x, y);

        protected a Eval<a>(Gen<a> gen) {
            return gen.Eval(size, random);
        }

        protected IEnumerable<a> Shuffle<a>(IEnumerable<a> col) {
            return Eval(Gen.Shuffle(col));
        }

        /// <summary>
        ///     Generate a random number between l and h, inclusive.
        /// </summary>
        protected int Choose(int l, int h) {
            return Eval(Gen.Choose(l, h));
        }

        protected IEnumerable<Position> SomeRandomPositions() {
            return Eval(Gen.ListOf(Position));
        }
    }
}