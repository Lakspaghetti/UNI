using System;
using System.Collections.Generic;

namespace DIKUdebate {

    class DIKUclassroom {

        public DIKUperson Discussion (DIKUperson person1, DIKUperson person2) {
            Console.WriteLine("\n{0} and {1}... GET READY TO BREAK SOME ANKLES!\n", person1.Name, person2.Name); //intro line

            int round = 1;
            DIKUperson current = person1;
            DIKUperson inactive = person2;

            while (!person1.hasLost () && !person2.hasLost ()) {
                Console.WriteLine ("ROUND: {0} FIGHT!", round);
                current.Argue (inactive); //one persons attacks the other

                var temp = current;
                current = inactive;
                inactive = temp;
                round++;
            }
            DIKUperson winner;
            if (person1.hasLost ()) { //chceks who lost
                winner = person2;
            } 
            else {
                winner = person1;
            }
            Console.WriteLine("AND THE WINNER IS: {0}", winner.Name); //winner.Name in order to avoid using the ToString method in person
            winner.getExperience ();
            return winner;
        }

        public DIKUperson RunDebate (List<DIKUperson> lst) { //REKURSIV
            List<DIKUperson> winList = new List<DIKUperson> (); //the list of winners of the current call
            while (lst.Count >= 2) { 
                DIKUperson shooter1 = lst[0]; //first person in the debate
                DIKUperson shooter2 = lst[1]; //second person in the debate

                winList.Add (this.Discussion(shooter1, shooter2)); 

                lst.RemoveAt(1); //reversed. When index 0 is removed index 1 will then become index 0, therefore index 1 needs to be removed first
                lst.RemoveAt(0); //it is also possible to remove index 0 two times
            } 
            if (lst.Count == 1) { //checks for a remining person in the lst
                winList.Add (lst[0]);
            }
            if (winList.Count > 1) { //checks if the final winner has been found or not
                return this.RunDebate (winList);
            }
            else {
                return winList[0];
            }
        }
    }
}