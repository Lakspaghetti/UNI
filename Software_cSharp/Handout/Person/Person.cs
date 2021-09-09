using System;

namespace Person {
    //https://docs.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-5.0
    //If the obj that is compared to is not of the same type it will throw an ArgumentException
    public class PersonClass : IComparable {
        private Demographic demographic;
        private int Age;
        private string Name;
        private RiskGroup riskgroup;

        public PersonClass (Demographic demo, int age, string name, RiskGroup risk) {
            this.demographic = demo;
            this.Age = age;
            this.Name = name;
            this.riskgroup = risk;
        }

        public int CompareTo(object obj) {
            PersonClass oPerson = obj as PersonClass;
            if (this.riskgroup == oPerson.riskgroup) {
                if (this.demographic == oPerson.demographic) {
                    if (this.Age == oPerson.Age) { //size based on alphabetical order from name
                        return String.Compare(this.Name, oPerson.Name);

                    }//age if-statement
                    else { //size based on age
                        if (this.Age < oPerson.Age) { //different from enum, therefor less than
                            return 1;
                        }
                        else {
                            return -1;
                        }
                    }
                } //demographic if-statement
                else { // size based on demographic
                    if (this.demographic > oPerson.demographic) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                }
            } //riskgroup if-statement
            else { //size based on riskgroup
                if (this.riskgroup > oPerson.riskgroup) {
                    return 1;
                }
                else {
                    return -1;
                }
            }
        } // end of compare to

        public override string ToString () {
            return String.Format ("{0}", this.Name);
        }
    }
}
