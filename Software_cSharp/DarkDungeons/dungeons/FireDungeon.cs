using System;

namespace DarkDungeons.Dungeons{    
    public class FireDungeon : Dungeon{
        public FireDungeon() {
            this.Unlocked = true;
            this.Completed = false;
            this.name = "Fire";
        } 
    }
}