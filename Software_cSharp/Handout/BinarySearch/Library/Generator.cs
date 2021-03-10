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
    }
}