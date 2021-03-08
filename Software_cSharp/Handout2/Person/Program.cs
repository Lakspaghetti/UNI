using System;
using System.Collections;

namespace Person {
    internal class Program {
        private static void Main(string[] args) {
            Person Mikkel = new Person (Demographic.Youth, 19, "Mikkel", RiskGroup.Low);
            Person Mathilde = new Person (Demographic.Youth, 27, "Mathilde", RiskGroup.Low);
            Person Magnus = new Person (Demographic.Youth, 22, "Magnus", RiskGroup.Low);
            Person Kathrin = new Person (Demographic.Adult, 47, "Kathrin", RiskGroup.Medium);
            Person Kim = new Person (Demographic.Adult, 53, "Kim", RiskGroup.Medium);
            Person Julie = new Person (Demographic.Child, 15, "Julie", RiskGroup.Low);
            Person Charlotte = new Person (Demographic.Adult, 52, "Charlotte", RiskGroup.High);
            Person lilV = new Person (Demographic.Youth, 19, "lilV", RiskGroup.Low);
            Person Lucas = new Person (Demographic.Youth, 20, "Lucas", RiskGroup.Low);
            Person tenth = new Person (Demographic.Senior, 60, "olGang", RiskGroup.High);

            ArrayList mylist = new ArrayList();

            mylist.Add (Mikkel);
            mylist.Add (Mathilde);
            mylist.Add (Magnus);
            mylist.Add (Kathrin);
            mylist.Add (Kim);
            mylist.Add (Julie);
            mylist.Add (Charlotte);
            mylist.Add (lilV);
            mylist.Add (Lucas);
            mylist.Add (tenth);

            foreach (Person per in mylist) {
                Console.WriteLine(per);
            }

            mylist.Sort();

            Console.WriteLine("\n");

            foreach (Person per in mylist) {
                Console.WriteLine(per);
            }
        }
    }
}