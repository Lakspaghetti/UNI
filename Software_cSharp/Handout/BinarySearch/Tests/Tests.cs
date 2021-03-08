using Library;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    public class Test {
        [SetUp]
        public void Init() {
            gen = new Generator();
        }

        private Generator gen;

        [Test]
        public void TestTooLow() {
            Assert.AreEqual(Search.Binary(gen.NextArray(10, 10), -1),-1);
        }

        [Test]
        public void TestTooHigh() {
            Assert.AreEqual(Search.Binary(gen.NextArray(10, 10), 11),-1);
        }
        [Test]
        public void TestElement() {
            Assert.AreNotEqual(Search.Binary(gen.NextArray(1, 0), 0),-1);
        }
        [Test]
        public void TestEmptyArray() {
            for (int i = -100; i<=100; i++) {
            Assert.AreEqual(Search.Binary(gen.NextArray(0, 0), i),-1);
            }
        }

    }
}