using System;

namespace DIKULecture {
    class Student : Person {
      private bool isInLecture = false;
      private Lecture lecture;
      
      public Student (string name, string occupation, int age) : base(name, occupation, age) { }

//Joins a lecture if possible
      public void Join (Lecture lect) {
          if (this.isInLecture == false) {
              lect.OnlineStudents++;
              this.isInLecture = true;
              this.lecture = lect;
          }
      }
//Gets information from a lecture if possible
      public String listen () {
          if (this.isInLecture == true) {
            return lecture.LectInfo;
          }
          else {
            return "student is not in lecture";
          }

      }

    }
}
