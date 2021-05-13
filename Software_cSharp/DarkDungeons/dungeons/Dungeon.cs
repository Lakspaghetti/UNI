using System;

namespace DarkDungeons.Dungeons{    
    public abstract class Dungeon{
        public bool Unlocked { get; set; }
        public bool Completed { get; set; }
        public string name { get; set; }

        public Dungeon() {
            this.Unlocked = true;
            this.Completed = false;
        } 
        public void Traverse() {
            if (Unlocked) {
                Console.WriteLine("\n{0} dungeon completed!", name);
                this.Completed = true;
            }
            else {
                Console.WriteLine("\n{0} dungeon is locked", name);
            }
        }

        public void Lock() {
            Unlocked = false;
        }
        public void Unlock() {
            Unlocked = true;
        }
    }
}