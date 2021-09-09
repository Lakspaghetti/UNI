using System;

namespace DIKULecture {
    class Program {
        static void Main(string[] args) {
            Lecture SD = new Lecture ("Software development");
            Lecture ID = new Lecture ("Interaction design");

            Student MK = new Student ("Magnus", "student", 22);
            Student MP = new Student ("Mathilde", "student", 28);
            Student MC = new Student ("Mikkel", "student", 19);

            Speaker YB = new Speaker ("Yung Boris", "speaker", 30);

            Console.Clear ();

            Console.WriteLine ("{0}", SD); //Is it needed to put a space in front of the parantheses here? question asked in relation to the style guide.
            Console.WriteLine ("{0}", ID);

            Console.WriteLine ("\nNow Magnus will try to join SD and then ID\n");

            MK.Join (SD);
            MK.Join (ID);

            Console.WriteLine ("{0}", SD);
            Console.WriteLine ("{0}", ID);

            Console.WriteLine ("\nNow Mikkel will try to join ID and then SD\n");

            MC.Join (ID);
            MC.Join (SD);

            Console.WriteLine ("{0}", SD);
            Console.WriteLine ("{0}", ID);

            Console.WriteLine ("\nNow Boris will begin the lecture SD\n");

            YB.BeginLect (SD);

            Console.WriteLine ("{0}", SD);
            Console.WriteLine ("{0}", ID);

            Console.WriteLine ("\nNow Magnus will try to listen\n");

            Console.WriteLine (MK.listen());

            Console.WriteLine ("\nNow Boris will broadcast the message \"Lecture starts now\"");
            Console.WriteLine ("and Mathilde will try to join ID\n");

            YB.speak ("Lecture starts now");
            MP.Join (ID);

            Console.WriteLine ("{0}", SD);
            Console.WriteLine ("{0}", ID);

            Console.WriteLine ("\nNow Magnus, Mathilde and Mikkel will each try to listen respectively");

            Console.WriteLine (MK.listen ());
            Console.WriteLine (MP.listen ());
            Console.WriteLine (MC.listen ());
        }
    }
}
