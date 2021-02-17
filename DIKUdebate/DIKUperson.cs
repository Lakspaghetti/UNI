using System;

namespace DIKUdebate {
    class DIKUperson {
        public string Name {get;}
        public int MaxBrainPower {get; private set;}
        public int BrainPower {get; private set;}
        public int StrengthOfArgument {get; private set;}
        public int Semester {get; private set;}
        public int CounterArgument {get; private set;}
        public int DoubleArgument {get; private set;}
        private DIKUActivity Activity;
        private Random rand = new Random();

        public DIKUperson (string name, DIKUActivity activity) {
            this.Name = name;
            this.Activity = activity;

            this.MaxBrainPower = 20;
            this.Semester = 1;
            this.BrainPower = 20;
            this.StrengthOfArgument = 4;
            this.CounterArgument = 10;
            this.DoubleArgument = 10;
        }
        public bool hasLost () {
            if (this.BrainPower <= 0) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool beDrained (int amount) {
            if (this.CounterArgument > rand.Next (101)) {
                Console.WriteLine("{0} just outplayed you and broke your ankles instead\nThe remaining brainpower of {0} is now {1}\n", this.Name, this.BrainPower);
                return false;
            }
            else {
                this.BrainPower -= amount; // amount has to be a postive integer, otherwise it will add brainpower
                Console.WriteLine ("DAYM! {0}'s ankle just broke. Nice shot bro!\nThe remaining brainpower of {0} is now {1}\n", this.Name, this.BrainPower);
                return true;
            }
        }
        public void Argue (DIKUperson opponent) {
            if (this.DoubleArgument > rand.Next (101)) {
                Console.WriteLine ("{0} 360 noscopes {1} for {2} damage", this.Name, opponent.Name, this.StrengthOfArgument * 2);
                opponent.beDrained(this.StrengthOfArgument * 2);
            }
            else {
                Console.WriteLine ("{0} dropshots {1} for {2} damage", this.Name, opponent.Name, this.StrengthOfArgument);
                opponent.beDrained(this.StrengthOfArgument);
            }
        }
        public void getExperience () {
            this.Semester++;
            this.StrengthOfArgument += 2;

            if (this.Activity == DIKUActivity.AttendingNone) {this.MaxBrainPower += 20;}
            else {this.MaxBrainPower += 10;}

            if (this.Activity == DIKUActivity.AttendingSome || this.Activity == DIKUActivity.AttendingAll) {
                this.CounterArgument += 10;
            }
            else {this.CounterArgument += 5;}

            if (this.Activity == DIKUActivity.AttendingAll) {this.DoubleArgument += 10;}
            else {this.DoubleArgument += 5;}

            this.BrainPower = this.MaxBrainPower; //needs to be done after MaxBrainPower has been increased
        }

        public override string ToString () {
            return String.Format (
                "The person's name: {0}\nThe person's activity: {1}\nThe person's semester: {2}\nThe person's Brainpower: {3}", this.Name, this.Activity, this.Semester, this.BrainPower
            );
        }
    }
}
