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

        [TestCase(5, 3, 8)]
        public void TestStatement(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 1);
        }//enters while loop, increments len, enters else part of if statement and then breaks while loop

        [TestCase(2, 3, 8)]
        public void TestBranch(int n, int max_len, int max_size) {
            Assert.AreEqual(CollatzImpl.Collatz(n, max_len, max_size), 1);
        } // enters if statement
    }
}
