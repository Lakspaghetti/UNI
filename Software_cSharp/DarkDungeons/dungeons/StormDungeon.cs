using System;

namespace DarkDungeons.Dungeons{    
    public class StormDungeon : Dungeon{
        public StormDungeon() {
            this.Unlocked = true;
            this.Completed = false;
            this.name = "Storm";
        } 
    }
}