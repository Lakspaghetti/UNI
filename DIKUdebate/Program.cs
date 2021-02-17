using System;

namespace DIKUdebate {
    class Program {
        static void Main() {
            DIKUperson JG = new DIKUperson("Joachim", DIKUActivity.AttendingSome);
            DIKUperson MC = new DIKUperson("Mikkel", DIKUActivity.AttendingAll);
            DIKUclassroom Bandoen = new DIKUclassroom ();
            Bandoen.Discussion(MC, JG);


        }
    }
}
