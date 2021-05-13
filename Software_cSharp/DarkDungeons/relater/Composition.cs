using System;
using System.Collections.Generic;
using DarkDungeons.Dungeons;

namespace DarkDungeons.Compositions{
    public class Composition{
        Dungeon parent;
        List<Dungeon> successors;
        public Composition(Dungeon Parent, List<Dungeon> Successors=null) { //composite and facade pattern?
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
                        Console.WriteLine("{0} dungeon unlocked!", successor.name);
                        successor.Unlock();
                    }
                } catch {}
            }
        }
    }
}