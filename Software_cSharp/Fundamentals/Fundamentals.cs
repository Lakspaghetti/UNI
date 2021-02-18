using System;

namespace Fundamentals
{
    class Fundamentals
    {
        public void CountToTen () {
            for (int x = 1; x <= 10; x++) {
                Console.WriteLine (x);
            }
            Console.WriteLine ("Finished!");
        }
        public int Fibonacci (int fib) {
            if (fib <= 0) { //In case of negative numbers inserted
                return 0; //Chose 0 as default value for wrong inputs
            }
            else if (fib == 1) {
                return fib;
            }
            else {
                return Fibonacci (fib - 1) + Fibonacci (fib - 2);
            }
        }
        public int Collatz (int n) {
            Console.WriteLine (n);
            if (n <= 1) { //negative numbers as input are not allowed
                return 1; //negative numbers will be printed and the counter will return 1
            }
            else if (n%2 == 0) {
                return 1 + Collatz (n / 2);
            }
            else {
                return 1 + Collatz (3 * n + 1);
            }
        }
    }
}
