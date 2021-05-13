using System;

namespace DarkDungeons.Dungeons{    
    public class IceDungeon : Dungeon{
        public IceDungeon() {
            this.Unlocked = true;
            this.Completed = false;
            this.name = "Ice";
        } 
    }
}