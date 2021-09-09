open AmazeingPlayton

open System

Console.Clear()

let world1 = World(true, Player())
world1.AddItem(Wall(15, 15))

printfn "\n    Welcome to the game! When you are ready, press a button and journey through a few levels."
printfn "    First, investigate the walls. try walking into it!
    (Press any button)"

match Console.ReadKey().Key with
  | _ -> world1.Play()

Console.Clear()
let a: Item list = [Wall(15, 15); PickAxe(7, 7)]
let world2 = World(true, Player())
for i in a do
  world2.AddItem(i)
printfn "\n    That was not very exiting was it? Lets try breaking it down.
    Grab that pickaxe over there, and destroy that wall!"

match Console.ReadKey().Key with
  | _ -> world2.Play()

Console.Clear()
let _b: Item list = [Fire(15, 15); Fire(14, 15); Water(20, 20); Water(20, 21)]
let world3 = World(true, Player())
for i in _b do
  world3.AddItem(i)
printfn "\n    Well done. Now lets look at some more dangerous stuff.
    Beware the fire, it will damage you. Your hitpoints will display right above the game.
    You will die if you have below 0 hitpoints
    If you take too much damage, water will heal you, but there are only so much healing a pond can give you!"

match Console.ReadKey().Key with
  | _ -> world3.Play()

Console.Clear()
let c: Item list = [FleshEatingPlant(15, 15); Water(20, 20); Water(20, 21)]
let world4 = World(true, Player())
for i in c do
  world4.AddItem(i)
printfn "\n    Beware of living creatures! They tend to hurt more than mere fire.
    A flesh eating plant might've grown big in these dungeons. Try walking into one!"

match Console.ReadKey().Key with
  | _ -> world4.Play()

Console.Clear()
let d: Item list = [FleshEatingPlant(15, 15); Sword(7, 7); Water(20, 20); Water(20, 21)]
let world5 = World(true, Player())
for i in d do
  world5.AddItem(i)
printfn "\n    But not even these monsters are invincible. Grab a sword and slay that hungry plant!"

match Console.ReadKey().Key with
  | _ -> world5.Play()

Console.Clear()
let world6 = World(true, Player())
world6.AddItem(TeleportPad(6, 15, 25, 15))
for i = 0 to 29 do
  world6.AddItem(Wall(15, i))
printfn "\n    The last thing i want to show you is teleporters. You will figure out how it works."

match Console.ReadKey().Key with
  | _ -> world6.Play()

Console.Clear()

printfn "\n    Now you are ready for a real test! Good luck adventurer."

let b = World(true, Player(),20,50)

for i in [  [0; 6;8;10;31;33;35]
            [1; 1;2;3;4;5;6;8;9;10;13;14;15;16;17;19;21;22;23;26;27;28;29;30;31;33;34;35;38;39;40;41;42;44;46;47;48]
            [2; 1;5;8;11;13;17;19;21;26;30;33;36;38;42;44;46]
            [3; 1;5;7;8;9;11;13;15;17;19;21;22;23;26;30;32;33;34;36;38;40;42;44;46;47;48]
            [4; 1;5;7;9;15;17;19;23;26;30;32;34;40;42;44;48]
            [5; 1;2;3;4;5;6;7;9;10;11;13;14;15;17;18;19;21;23;26;27;28;29;30;31;32;34;35;36;38;39;40;42;43;44;46;47]
            [6; 6;9;14;17;19;21;23;31;34;39;42;22;46;48] 
            [7; 0;1;2;3;4;5;6;9;10;14;15;16;17;19;21;23;25;26;27;28;29;30;31;34;35;39;40;41;42;44;46;48]  
            [8; 4;5;6;7;8;10;12;17;19;21;23;29;30;31;32;33;35;37;42;44;46;28]
            [9; 1;2;4;8;12;14;15;17;19;20;21;22;23;24;25;26;27;29;33;37;39;40;42;44;45;46;47;48]
            [10; 4;8;9;10;11;12;13;14;17;21;24;29;33;34;35;36;37;39;42;46;49]
            [11; 0;1;2;4;8;9;12;14;17;19;22;24;25;26;27;29;33;34;37;39;42;47;49]
            [12; 2;4;8;12;14;17;19;22;24;26;29;32;37;39;42;44;47;49]
            [13; 0;1;2;4;5;6;7;8;10;11;12;14;15;16;17;19;20;22;24;25;26;27;29;30;31;32;33;35;36;37;39;40;41;42;44;45;47;49]
            [14; 0;6;22;25;31;47]
            [15; 0;2;4;6;8;9;10;11;12;13;14;15;16;17;18;19;22;23;25;27;29;31;33;34;35;36;37;38;39;40;41;42;43;44;46;47]
            [16; 0;1;2;4;8;21;25;26;27;29;33;46]
            [17; 4;6;10;12;13;14;15;16;17;18;19;21;22;23;24;29;31;35;37;38;39;40;41;42;43;44;46;47;48;49]
            [18; 1;2;3;4;6;7;8;9;10;14;18;22;26;27;28;29;31;32;33;34;35;39;43;47]   
            [19; 6;12;16;20;22;31;37;41;45]                                                                 ] do
    
    for j in i.[1..i.Length - 1] do
        b.AddItem (Wall (j,i.Head)) 

b.AddItem (TeleportPad (31,10,45,18))
b.AddItem (TeleportPad (6,10,28,3))
b.AddItem (FleshEatingPlant(3,12))
b.AddItem (FleshEatingPlant(48,19))
b.AddItem (FleshEatingPlant(24,7))
b.AddItem (FleshEatingPlant(37,6))
b.AddItem (PickAxe(6,3))
b.AddItem (PickAxe(6,4))
b.AddItem (PickAxe (4,4))
b.AddItem (PickAxe (5,0))
b.AddItem (PickAxe (18,6))
b.AddItem (PickAxe (30,9))
b.AddItem (Sword(28,4))
b.AddItem (Water (15,6))
b.AddItem (Water (16,6))
b.AddItem (Water (0,12))
b.AddItem (Water (1,12))
b.AddItem (Water (1,15))
b.AddItem (Water (22,7))
b.AddItem (Water (22,8))
b.AddItem (Fire (12,4))
b.AddItem (Fire (6,16))
b.AddItem (Fire(28,15))

match Console.ReadKey().Key with
  | _ -> b.Play()