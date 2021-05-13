using System;

namespace DarkDungeons.Dungeons{    
    public class EarthDungeon : Dungeon{
        public EarthDungeon() {
            this.Unlocked = true;
            this.Completed = false;
            this.name = "Earth";
        } 
    }
}