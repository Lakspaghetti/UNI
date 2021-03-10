using System;

namespace Library {
    public class ComparisonCountedInt : IComparable {
        static int compareInt;
        private int numOfComp;
        readonly int ComparisonCount;
        public ComparisonCountedInt (int myInt) {
            compareInt = myInt;
            numOfComp = 0;
            ComparisonCount = numOfComp;
        }
        public int CompareTo(object obj) {
            numOfComp++;
            return this.CompareTo(obj);
        }
        public static int CountComparisons(ComparisonCountedInt[] array) {
            return 2; //confusion much
        }


    }
}