using System;

namespace learningCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int myTest;
            int myInt = 5;
            int mySndInt = 4;

            double mydouble = 4.3;
            double mySnddouble = 3.2;

            String myString = "Mikkel";
            String mySndString = "Luc";
            String myThrdString = "Carlsen";

            String[] myStringArray = new String[5] {"hej", "med", "dig", "bla", "bla"}; 

            Array myArr = Array.CreateInstance(typeof(string), 4);

            Console.WriteLine("Hello World!");

            myTest = 5;

            Console.WriteLine(myTest);

            myTest = 8;

            Console.WriteLine(myTest);

            Console.WriteLine(myInt + mySndInt);

            Console.BackgroundColor = System.ConsoleColor.Red;

            Console.ForegroundColor = System.ConsoleColor.Black;

            Console.WriteLine(mydouble + mySnddouble);

            Console.ResetColor();

            Console.BackgroundColor = System.ConsoleColor.DarkBlue;

            Console.ForegroundColor = System.ConsoleColor.DarkGray;

            Console.WriteLine(myString + " " + mySndString + " "+ myThrdString); 

            Console.ResetColor();

            Console.WriteLine(myStringArray);

            for (int i = 0; i < myStringArray.Length; i++)
            {
                Console.WriteLine(myStringArray.GetValue(i));
            }

            Console.WriteLine(myArr);

            Console.ReadLine ();
        }
    }
}
