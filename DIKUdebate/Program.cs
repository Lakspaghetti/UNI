using System;
using System.Collections.Generic;

namespace DIKUdebate {
    class Program {
        static void Main() {
            DIKUperson JG = new DIKUperson ("Joachim", DIKUActivity.AttendingSome);
            DIKUperson MC = new DIKUperson ("Mikkel", DIKUActivity.AttendingAll);
            DIKUperson MM = new DIKUperson ("Mads", DIKUActivity.AttendingNone);
            DIKUperson TT = new DIKUperson ("TES", DIKUActivity.AttendingSome);
            DIKUperson GG = new DIKUperson ("GUNGAME", DIKUActivity.AttendingAll);
            DIKUperson BB = new DIKUperson ("BYEBYE", DIKUActivity.AttendingNone);
            DIKUclassroom Bandoen = new DIKUclassroom ();
            List<DIKUperson> testList = new List<DIKUperson> ();
            testList.Add(JG);
            testList.Add(MC);
            testList.Add(MM);
            testList.Add(TT);
            testList.Add(GG);
            testList.Add(BB);

            Console.Clear ();
            //Shows that ToString works
            Console.WriteLine ("When printing Mikkel it looks as follows:\n\n{0}\n\n\n\n", MC); 

            //Shows that Discussion and all methods except ToString in person works
            Console.WriteLine ("A discussion between Mikkel and mads looks as follows:");
            Bandoen.Discussion (MC, MM);

            //shows that RunDebate works
            Console.WriteLine ("\n\n\n\nA Debate between Joachim, Mikkel, Mads, TES, GUNGAME and BYEBYE looks as follows:");
            Console.WriteLine ("\nWINNER WINNER CHICKEN DINNER!: {0}", (Bandoen.RunDebate (testList)).Name);
        }
    }
}
