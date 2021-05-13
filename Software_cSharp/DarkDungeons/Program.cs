using System;
using System.Collections.Generic;
using DarkDungeons.Dungeons;
using DarkDungeons.Compositions;

namespace DarkDungeons
{
    class Program
    {
        static void Main()
        {
            IceDungeon test1;
            test1 = new IceDungeon(); 
            StormDungeon storm = new StormDungeon();
            IceDungeon ice = new IceDungeon(); 
            EarthDungeon earth = new EarthDungeon();
            FireDungeon fire = new FireDungeon();

            List<Dungeon> stormlist = new List<Dungeon>(); //= new Dungeon[earth, ice];
            stormlist.Add(earth); stormlist.Add(ice);

            List<Dungeon> earthlist = new List<Dungeon>(); //= new Dungeon[fire];
            earthlist.Add(fire);


            Composition Storm = new Composition(Parent: storm, Successors: stormlist);
            Composition Ice = new Composition(Parent: ice);
            Composition Earth = new Composition(Parent: earth, Successors: earthlist);
            Composition Fire = new Composition(Parent: fire);

            Storm.Traverse();
            Ice.Traverse();
            Earth.Traverse();
            Fire.Traverse();
        }
    }
}
