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
    }
}
