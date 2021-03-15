using System;
using Library;
using NUnit.Framework;
using Person;

namespace Tests {
    [TestFixture]
    public class Test {

        [SetUp]
        public void Init() {
            gen = new Generator();

            people = new PersonClass[] { //don't know how to put this in the setup and then use it in the test
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

            CCI = gen.NextArrayComp(10, 10, Generator.SimpleInitializerComparison);
        }

        private Generator gen;
        private ComparisonCountedInt[] CCI;
        private PersonClass[] people;

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
        public void TestBig() { //No clue to what the biggest size of an array is, therefore this test will keep failing
            Assert.AreEqual(Search.Binary(gen.NextArray(System.Int32.MaxValue, 1000), 69),1);
        }

        [Test]
        public void TestPersonArray1() {
            System.Array.Sort(people);

            PersonClass Mikkel = new PersonClass (Demographic.Youth, 19, "Mikkel", RiskGroup.Low);
            Assert.AreEqual(Search.Binary(people, Mikkel), 8);
        }

        [Test]
        public void TestPersonArray2() {
            System.Array.Sort(people);

            PersonClass Charlotte = new PersonClass (Demographic.Senior, 52, "Charlotte", RiskGroup.High);
            Assert.AreEqual(Search.Binary(people, Charlotte), 1);
        }

        [Test]
        public void TestRunningTime() {
            ComparisonCountedInt.ResetComparisons(CCI);
            Search.Binary(CCI, new ComparisonCountedInt(5));

            Assert.LessOrEqual(ComparisonCountedInt.CountComparisons(CCI) - 3, (int)Math.Ceiling(Math.Log(CCI.Length, 2.0)) ); // countcomparisons - 3 due to that search has 3 extra compare to statements
        }
        [Test]
        public void TestJumpVsLinear() {
            ComparisonCountedInt.ResetComparisons(CCI);
            Search.Binary(CCI, new ComparisonCountedInt(5));
            var tempVarBin = ComparisonCountedInt.CountComparisons(CCI) - 3; //same reason as above for the - 3

            ComparisonCountedInt.ResetComparisons(CCI);
            Search.Jump(CCI, new ComparisonCountedInt(5));
            var tempVarJump = ComparisonCountedInt.CountComparisons(CCI) - 1; //last compareTo in jump only checks if the result is correct, therefor - 1 iteration
            Assert.LessOrEqual(tempVarBin, tempVarJump);
        }
    }
}
