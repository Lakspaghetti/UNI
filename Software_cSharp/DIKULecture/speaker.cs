using System;

namespace DIKULecture {
    class Speaker : Person {
        private bool isInLecture = false;
        private Lecture lecture;

        public Speaker (string name, string occupation, int age) : base (name, occupation, age) { }

//BeginLect is created instead of Broadcast 
//This name seems more fitting for the purpose of the method in my opinion
//Puts the speaker into the lecture
        public void BeginLect (Lecture Lect) { 
            if (isInLecture == false) {
                this.isInLecture = true;
                this.lecture = Lect;
            }       
        }
//Sends information to the lecture
        public void speak (string info) {
            if (isInLecture == true) {
                lecture.LectInfo = info;
            }
        }
    }
}