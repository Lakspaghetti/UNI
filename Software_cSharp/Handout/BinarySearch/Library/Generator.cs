using System;

namespace Library {
    public class Generator {
        public delegate IComparable Initializer(int value);
        private Random rand;

        public Generator() {
            rand = new Random();
        }

        public static IComparable SimpleInitializer(int value) {
            return value;
        }
        public static IComparable SimpleInitializerComparison(int value) { //for comparisonCountedInt
            return new ComparisonCountedInt(value);
        }

        public int NextInt(int maxValue) {
            return rand.Next(maxValue);
        }

        public IComparable[] NextArray(int size, int maxValue) {
            return NextArray(size, maxValue,
                Generator.SimpleInitializer);
        }

        public IComparable[] NextArray(int size, int maxValue, Initializer initializer) {
            var array = new IComparable[size];

            for (var i = 0; i < size; i++) {
                array[i] = initializer(rand.Next(maxValue));
            }

            Array.Sort(array);

            return array;
        }
        public ComparisonCountedInt[] NextArrayComp(int size, int maxValue, Initializer initializer) {
            ComparisonCountedInt[] array = new ComparisonCountedInt[10];

            for (var i = 0; i < array.Length; i++) {
                array.SetValue(initializer(rand.Next(maxValue)), i);
            }

            Array.Sort(array);

            return array;
        }
    }
}