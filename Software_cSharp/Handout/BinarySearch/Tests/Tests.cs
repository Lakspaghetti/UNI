using Library;
using NUnit.Framework;
using Person;

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

        [Test]
        public void TestElementTwo() {
            Assert.AreNotEqual(Search.Binary(gen.NextArray(10, 0), 0),-1);
        }

        [Test]
        public void TestBig() { //No clue to what the biggest size of an array is
            Assert.AreEqual(Search.Binary(gen.NextArray(System.Int32.MaxValue, 1000), 69),1);
        }

        [Test]
        public void TestPersonArray() {
            PersonClass[] people = new PersonClass[] { //don't know how to put this in the setup and then use it in the test
                new PersonClass (Demographic.Youth, 19, "Mikkel", RiskGroup.Low),
                new PersonClass (Demographic.Youth, 27, "Mathilde", RiskGroup.Low),
                new PersonClass (Demographic.Youth, 22, "Magnus", RiskGroup.Low),
                new PersonClass (Demographic.Adult, 47, "Kathrin", RiskGroup.Medium),
                new PersonClass (Demographic.Adult, 53, "Kim", RiskGroup.Medium),
                new PersonClass (Demographic.Child, 15, "Julie", RiskGroup.Low),
                new PersonClass (Demographic.Senior, 52, "Charlotte", RiskGroup.High),
                new PersonClass (Demographic.Youth, 19, "lilV", RiskGroup.Low),
                new PersonClass (Demographic.Youth, 20, "Lucas", RiskGroup.Low),
                new PersonClass (Demographic.Senior, 60, "olGang", RiskGroup.High),
            };
            PersonClass Mikkel = new PersonClass (Demographic.Youth, 19, "Mikkel", RiskGroup.Low);
            PersonClass Charlotte = new PersonClass (Demographic.Senior, 52, "Charlotte", RiskGroup.High);
            System.Array.Sort(people);

            Assert.AreEqual(Search.Binary(people, Mikkel), 8); //Through Person/Program.cs i know that Mikkel is supposed to be at index 8
            Assert.AreEqual(Search.Binary(people, Charlotte), 1); //Creating multiple test in here to avoid duplicating the people array
        }
    }
}
