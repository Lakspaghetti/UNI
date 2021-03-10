using System;
using System.Collections;

namespace Person {
    internal class Program {
        private static void Main(string[] args) {

            PersonClass Mikkel = new PersonClass (Demographic.Youth, 19, "Mikkel", RiskGroup.Low);
            PersonClass Mathilde = new PersonClass (Demographic.Youth, 27, "Mathilde", RiskGroup.Low);
            PersonClass Magnus = new PersonClass (Demographic.Youth, 22, "Magnus", RiskGroup.Low);
            PersonClass Kathrin = new PersonClass (Demographic.Adult, 47, "Kathrin", RiskGroup.Medium);
            PersonClass Kim = new PersonClass (Demographic.Adult, 53, "Kim", RiskGroup.Medium);
            PersonClass Julie = new PersonClass (Demographic.Child, 15, "Julie", RiskGroup.Low);
            PersonClass Charlotte = new PersonClass (Demographic.Adult, 52, "Charlotte", RiskGroup.High);
            PersonClass lilV = new PersonClass (Demographic.Youth, 19, "lilV", RiskGroup.Low);
            PersonClass Lucas = new PersonClass (Demographic.Youth, 20, "Lucas", RiskGroup.Low);
            PersonClass tenth = new PersonClass (Demographic.Senior, 60, "olGang", RiskGroup.High);

            ArrayList myArrList = new ArrayList();

            myArrList.Add (Mikkel);
            myArrList.Add (Mathilde);
            myArrList.Add (Magnus);
            myArrList.Add (Kathrin);
            myArrList.Add (Kim);
            myArrList.Add (Julie);
            myArrList.Add (Charlotte);
            myArrList.Add (lilV);
            myArrList.Add (Lucas);
            myArrList.Add (tenth);

            foreach (PersonClass per in myArrList) {
                Console.WriteLine(per);
            }

            myArrList.Sort();

            Console.WriteLine("\n");

            foreach (PersonClass per in myArrList) {
                Console.WriteLine(per);
            }
        }
    }
}