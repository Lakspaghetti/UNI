using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Fundamentals test = new Fundamentals ();
            test.CountToTen ();
            Console.WriteLine ("\nFibonacci 10: {0}\n", test.Fibonacci (10));
            Console.WriteLine("Collatz 13: {0}", test.Collatz (13));
        }
    }
}
