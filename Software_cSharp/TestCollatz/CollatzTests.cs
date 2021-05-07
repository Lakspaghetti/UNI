using NUnit.Framework;

namespace TestCollatz {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [TestCase(5, 3, 8)]
        public void TestExample(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size),
                            CollatzImpl.CollatzRec(n, max_len, max_size));
        }

        [TestCase(5, 3, 8)] // n < max_size, k = 1, if statement once
        public void TestStatement(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 1);
        }

        [TestCase(2, 3, 8)] // n > 1, k = 1, else statement once
        public void TestBranch(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 1);
        } // enters if statement

        //-- need elaboration on path coverage. Link? what does "with k = 2" mean --//
        //-- Current guess is that k = 2 means that any loop that runs 2 or less times is a relevant path --//

        [TestCase(1, 3, 8)] // n > 1, k = 0
        public void TestPath(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 0);
        }

        [TestCase(5, 1, 17)] // len <= max_len, k = 2, else then if
        public void TestPathThrd(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 2);
        }

        [TestCase(6, 1, 8)] // len <= max_lem, k = 2, if then else statement
        public void TestPathFrth(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 2);
        }
    }
}
