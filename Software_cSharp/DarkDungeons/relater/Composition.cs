using System;
using System.Collections.Generic;
using DarkDungeons.Dungeons;

namespace DarkDungeons.Compositions{
    public class Composition{
        private Dungeon parent;
        private List<Dungeon> successors;
        public Composition(Dungeon Parent, List<Dungeon> Successors=null) {
            this.parent = Parent;
            this.successors = Successors;
            try {
                foreach (Dungeon successor in successors) {
                    successor.Lock();
                }
            } catch {}
        }

        public void Traverse() {
            parent.Traverse();
            if (parent.Completed) {
                try {
                    foreach (Dungeon successor in successors) {
                        successor.Unlock();
                        Console.WriteLine("{0} dungeon unlocked!", successor.name);                        
                    }
                } catch {}
            }
        }
    }
}