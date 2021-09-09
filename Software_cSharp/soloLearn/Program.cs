using System;
using System.Collections.Generic;


namespace SoloLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            for (int x = 1; x <= number; x++)
            {  
                string output;
                output = (x%3==0) ? ("*") : Convert.ToString(x);
                Console.Write(output);
            }
        }
    }
}