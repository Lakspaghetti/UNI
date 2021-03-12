using System;

namespace Library {
    public class ComparisonCountedInt : IComparable {
        readonly int compareInt;
        private int ComparisonCount;
        public ComparisonCountedInt (int myInt) {
            compareInt = myInt;
            ComparisonCount = 0;
        }
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            ComparisonCountedInt compInt = obj as ComparisonCountedInt;
            if (compInt != null) {
                this.ComparisonCount++;
                return this.compareInt.CompareTo(compInt.compareInt);
            }
            else {
                throw new ArgumentException("Object is not a ComparisonCountedInt");
            }

        }
        public static int CountComparisons(ComparisonCountedInt[] array) {
            int result = 0;
            foreach (var num in array) {
                result += num.ComparisonCount;
            }
            return result;
        }
        public static void ResetComparisons(ComparisonCountedInt[] array) {
            foreach (var elm in array) {
                elm.ComparisonCount = 0;
            }
        }
    }
}