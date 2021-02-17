using System;
using System.Collections.Generic;

namespace DIKUdebate {
    class DIKUclassroom {
        public DIKUperson Discussion (DIKUperson person1, DIKUperson person2) {
            Console.Clear ();
            Console.WriteLine("{0} and {1}... GET READY TO BREAK SOME ANKLES!\n", person1.Name, person2.Name);

            int round = 1;
            DIKUperson current = person1;
            DIKUperson inactive = person2;

            while (!person1.hasLost () && !person2.hasLost ()) {
                Console.WriteLine ("ROUND: {0} FIGHT!", round);
                current.Argue (inactive);

                var temp = current;
                current = inactive;
                inactive = temp;
                round++;
            }
            DIKUperson winner;
            if (person1.hasLost ()) {
                winner = person2;
            } 
            else {
                winner = person1;
            }
            Console.WriteLine("AND THE WINNER IS: {0}", winner.Name);
            winner.getExperience ();
            return winner;
        }
        public DIKUperson RunDebate (List<DIKUperson> list) { //REKURSIV
            List<DIKUperson> winList = new List<DIKUperson>();
            while (list.Count >= 2) {
                DIKUperson shooter1 = list[0];
                DIKUperson shooter2 = list[1];

                winList.Add (this.Discussion(shooter1, shooter2));

                list.RemoveAt(0);
                list.RemoveAt(1);
            }
            if (list.Count == 1) {
                winList.add list[0];
            }
        }
    }
}
