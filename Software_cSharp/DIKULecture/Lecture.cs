using System;

namespace DIKULecture {
    class Lecture : ChatRoom {
        private int numOfstudentsOnline = 0;
        private string Information = "no information yet";
        public Lecture (String name) : base (name) { this.OnlineStudents = 0; }

        public int OnlineStudents {
            get { return numOfstudentsOnline; }
            set { numOfstudentsOnline = value; }
        }

        public string LectInfo {
            get { return Information; }
            set { Information = value; }
        }

        public override string ToString () {
            return String.Format ("Lecture: {0} \nNumber of students: {1}", this.Name, this.OnlineStudents);
        }

    }
}