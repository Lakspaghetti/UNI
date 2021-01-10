module AmazeingPlayton

open System

type Color = ConsoleColor

///<summary> A class that represents a canvas which will be the foundation for what the visual game. Is a 2D array</summary>
///<param name = "rows"> The amount of rows on the canvas.</param>
///<param name = "cols"> The amount of columns on the canvas. </param>
type Canvas (rows: int, cols: int) =
  let arr = Array2D.create rows cols (' ', None, None)
  
  ///<summary> Retrieve the data for a given point on the canvas. Points start as (0, 0) in the top left corner </summary>
  ///<param name = "x"> The horizontal coordinate on the canvas. </param>
  ///<param name = "y"> The vertical coordinate on the canvas </param>
  ///<returns> A tuple with the points character, the color of the character and the background color. </returns>
  member this.GetData (x: int, y: int) : char * Color * Color =
    match arr.[y,x] with
    | c, None, None -> (c, Color.DarkGray, Color.DarkGray)
    | c, None, Some (bg) -> (c, Color.DarkGray, bg) 
    | c, Some (fg), None -> (c, fg, Color.DarkGray)
    | c, Some (fg), Some (bg) -> (c, fg, bg)

  member this.size = (rows,cols)

  ///<summary> Specify the data of the given point. </summary>
  ///<param name = "x"> The horizontal coordinate. </param>
  ///<param name = "y"> The vertical coordinate. </param>
  ///<param name = "c"> The character displayed on the canvas point. </param>
  ///<param name = "fg"> The color of the character. </param>
  ///<param name = "bg"> The background color on the canvas point. </param>
  member this.Set ((x: int, y: int, c: char, fg: Color, bg: Color)): unit =
    match fg, bg with
      | Color.White, Color.Black -> Array2D.set arr y x (c, None, None)
      | Color.White, _ -> Array2D.set arr y x (c, None, Some bg)
      | _, Color.Black -> Array2D.set arr y x (c, Some fg, None)
      | _, _ -> Array2D.set arr y x (c, Some fg, Some bg)

  ///<summary> Print the canvas to the terminal window. </summary>
  member this.Show(): unit =
    Console.ResetColor()

    printf "\n\n    "

    for i = 0 to rows - 1 do
      for j = 0 to cols - 1 do
        match arr.[i, j] with
          | (char, None, None) -> Console.ForegroundColor <- Color.White
                                  Console.BackgroundColor <- Color.DarkGray
                                  printf "%c" char
          | (char, Some fg, None) -> Console.ForegroundColor <- fg
                                     Console.BackgroundColor <- Color.DarkGray
                                     printf "%c" char
          | (char, None, Some bg) -> Console.ForegroundColor <- Color.White
                                     Console.BackgroundColor <- bg
                                     printf "%c" char
          | (char, Some fg, Some bg) -> Console.ForegroundColor <- fg
                                        Console.BackgroundColor <- bg
                                        printf "%c" char
      Console.ResetColor()                                 
      printf "    \n    "
    printf "    \n\n"

///<summary> Abstract class which acts as the parent for all entities in the game. </summary>
[<AbstractClass>]
type Entity() =

  ///<summary> Render the class on the canvas </summary>
  ///<param name = "Canvas"> The canvas which we want to render the item on </param>
  abstract member RenderOn : Canvas -> unit
  default this.RenderOn canvas = ()

///<summary> The main character of the game is the player class. This class will be controlable. Inherits the Entity class. </summary>
///<param name = "x"> The start horizontal coordinate for the player. </param>
///<param name = "y"> The start vertical coordinate for the player. </param>
///<param name = "c"> The character used to visualize the player on the canvas. </param>
///<param name = "fg"> The color of the character. </param>
///<param name = "bg"> The players background color. </param>
type Player(x: int, y: int, c: char, fg: Color, bg: Color) =
  inherit Entity()

  let mutable hitpoints = 10
  new() = Player(2, 2, 'Ѫ', Color.Blue, Color.Red)

  override this.RenderOn (canv: Canvas) : unit = 
    canv.Set(fst this.Pos, snd this.Pos, c, fg, bg)

  member val Pos = (x,y) with get, set
  member val PrevPos = (x,y) with get, set
  member val CurrentField = (' ', Color.DarkGray, Color.DarkGray) with get, set
  member val NextField = (' ', Color.DarkGray, Color.DarkGray) with get, set
  member val PickAxes = 0 with get, set
  member val Sword = false with get, set

  ///<summary> Increase the current hitpoints of the player- </summary>
  ///<param name = "h"> The amount of hitpoints to add to the players current hitpoints. </param>
  member this.Heal (h: int) : unit = if hitpoints + 2 > 10 then hitpoints <- 10 else hitpoints <- hitpoints + h

  ///<summary> Decrease the players current hitpoints. </summary>
  ///<param name = "d"> The amount of hitpoints to subtract from the players hitpoints. </param>
  member this.Damage (d: int) : unit = hitpoints <- hitpoints - d
  member this.HitPoints = hitpoints
  member this.IsDead = hitpoints < 0

  ///<summary> Move the player to a given point. </summary>
  ///<param name = "x"> The horizontal coordinate. </param>
  ///<param name = "y"> The vertical coordinate. </param>
  member this.MoveTo ((x:int, y:int)) : unit = this.PrevPos <- this.Pos
                                               this.Pos <- (x, y)

///<summary> The abstract class which all items will inherit from. Inherits the Entity class. </summary>
[<AbstractClass>]
type Item() =
  inherit Entity()

  ///<summary> Specifies how an item interacts with a player. </summary>
  ///<param name = "player"> The player to interact with. </param>
  abstract member InteractWith : Player -> unit
  abstract member FullyOccupy :  bool 
  default this.FullyOccupy = true
  abstract member Pos : int * int
  abstract member Pos2 : int * int
  default this.Pos2 = (-1,-1)

///<summary> A class representing walls. Inherits from the Item class. </summary>
///<param name = "x"> The horizontal position of the wall. </param>
///<param name = "y"> The vertical position of the wall. </param>
type Wall (x: int, y: int) = 
    inherit Item()
    override this.Pos = (x,y)

    member val WallExists = true with get, set

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, 'Ξ', ConsoleColor.White, ConsoleColor.DarkRed) //▢

    override this.InteractWith (p: Player) : unit =
        if this.WallExists && p.PickAxes > 0 then
            p.PickAxes <- p.PickAxes - 1
            p.NextField <- (' ', Color.DarkGray, Color.DarkGray)
            this.WallExists <- false
        elif this.WallExists then
            p.Pos <- p.PrevPos
            p.NextField <- p.CurrentField
        else ()

///<summary> A class representing water. Inherits the Item class. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>
type Water (x: int, y: int) =
    inherit Item()
    let mutable waterLeft = 2
    override this.Pos = (x,y)

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, '≈', ConsoleColor.DarkBlue, ConsoleColor.Blue)
  
    override this.FullyOccupy = false

    override this.InteractWith (p: Player) : unit =
        if waterLeft <> 0 then 
            p.Heal 2
            waterLeft <- waterLeft - 1
            if waterLeft = 0 then p.NextField <-  ('≈', Color.Red, Color.Blue)
            else ()
        else ()

///<summary> A class representing fire. Inherits the Item class. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>   
type Fire (x: int, y: int) =
    inherit Item()
    let mutable fireLeft = 5
    override this.FullyOccupy = false
    override this.Pos = (x,y)

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, '≙', ConsoleColor.Yellow, ConsoleColor.Red)
       
    override this.InteractWith (p: Player) : unit =
        if fireLeft <> 0 then
            p.Damage 1
            fireLeft <- fireLeft - 1
            if fireLeft = 0 then p.NextField <- ('*', Color.Black, Color.DarkYellow)
            else ()
        else ()

///<summary> A class representing flesh eating plants. Inherits the Item class. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>
type FleshEatingPlant (x: int, y: int) =
    inherit Item()
    override this.Pos = (x,y)

    member val PlantExists = true with get, set

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, '⋥', ConsoleColor.Red, ConsoleColor.DarkGreen)

    override this.InteractWith (p: Player) : unit =
        if this.PlantExists && p.Sword then
            p.Damage 5
            p.NextField <- (' ', Color.DarkGray, Color.DarkGray)
            this.PlantExists <- false
        elif this.PlantExists then
            p.Damage 5
            p.Pos <- p.PrevPos
            p.NextField <- p.CurrentField
        else ()

///<summary> A class that represents the exit. Inherits the Item class. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>
type Exit (x: int, y: int) =
    inherit Item()
    member val quit = false with get, set
    override this.Pos = (x,y)

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, 'Ħ', ConsoleColor.Black, ConsoleColor.Magenta)

    override this.InteractWith (p: Player) : unit =
        if p.HitPoints >= 5 then
            this.quit <- true
        else ()

///<summary> A class representing teleporter pads. Inherits the Item class. Two pads will be created with each instance of the class. </summary>
///<param name = "x1"> The horizontal position of the first pad. </param>
///<param name = "y1"> The vertical position of the first pad. </param>
///<param name = "x2"> The horizontal position of the second pad. </param>
///<param name = "y2"> The vertical position of the second pad. </param>
///<remarks> The pads are interconnected and will teleport the player from one pad to another. </remarks>
type TeleportPad (x1: int, y1: int, x2: int, y2: int) =
    inherit Item()
    override this.Pos = (x1,y1)
    override this.Pos2 = (x2,y2)
    override this.FullyOccupy = false

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, '¤', ConsoleColor.Cyan, ConsoleColor.DarkBlue)
        canv.Set(fst this.Pos2, snd this.Pos2, '¤', ConsoleColor.Cyan, ConsoleColor.DarkBlue)

    override this.InteractWith (p: Player) : unit =
        if p.Pos = this.Pos then p.Pos <- this.Pos2
        else p.Pos <- this.Pos

///<summary> A class representing a pickaxe. Inherits the Item class. Is used to destroy walls and has to be picked up. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>
type PickAxe (x: int, y: int) =
    inherit Item()
    override this.Pos = (x,y)
    override this.FullyOccupy = false

    member val PickAxeExists = true with get, set

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, 'Ͳ', ConsoleColor.DarkGray, ConsoleColor.Yellow)

    override this.InteractWith (p: Player) : unit =
        if this.PickAxeExists then
            p.PickAxes <- p.PickAxes + 1
            this.PickAxeExists <- false
            p.NextField <- (' ', Color.DarkGray, Color.DarkGray)
        else ()

///<summary> A class representing swords. Inherits the Item class. Has to be picked up and is used to destroy plants. </summary>
///<param name = "x"> The horizontal position. </param>
///<param name = "y"> The vertical position. </param>
type Sword (x: int, y: int) =
    inherit Item()
    override this.Pos = (x,y)
    override this.FullyOccupy = false

    member val SwordExists = true with get, set

    override this.RenderOn (canv: Canvas) : unit = 
        canv.Set(fst this.Pos, snd this.Pos, '†', ConsoleColor.DarkGray, ConsoleColor.White)

    override this.InteractWith (p: Player) : unit =
        if this.SwordExists then 
            p.Sword <- true
            this.SwordExists <- false
            p.NextField <- (' ', Color.DarkGray, Color.DarkGray)
        else ()

///<summary> A class representing a world. The vizual world is a canvas, thus a 2D matrix. </summary>
///<param name = "exit"> A boolean which represents whether or not an exits will be created in the world. </param>
///<param name = "p"> A player which will be the controlable character in the world. </param>
///<param name = "rows"> The amount of rows on the world canvas. </param>
///<param name = "cols"> The amount of columns on the world canvas. </param>
type World (exit: bool, p: Player, rows: int, cols: int) =
    let board = Canvas(rows, cols)
    let loseBoard = Canvas(16, 51)
    let winBoard = Canvas(16, 44)
    let mutable items: Item list = []
    new(exit: bool, p: Player) = World(exit,p,30,30)

    ///<summary> Updates the world to the next state after the player moved. </summary>
    member this.Update () : unit = 
        for i in items do
            if i.Pos = p.Pos || i.Pos2 = p.Pos then i.InteractWith p
            else ()
            
        p.CurrentField <- p.NextField
        p.RenderOn (board)
        Console.Clear ()
        printfn "\n    Hitpoints: %A" (p.HitPoints)
        printfn "\n    PickAxes:   %A" (p.PickAxes)
        printfn "\n    Sword:     %b" (p.Sword)
        if p.HitPoints < 5 then printfn  "    YOU'RE TOO WEAK TO EXIT" 
        board.Show ()

    ///<summary> Adds an item to the world. </summary>
    ///<param name = "item"> The item we want to add to the world. </param>
    member this.AddItem (item : Item) : unit =
        item.RenderOn (board) 
        items <- items @ [item]

    ///<summary> Plays the game. Input a move for the player, then update the canvas accordingly. Repeats untill game ends. </summary>
    /// <remarks> The game can end 3 ways: The player dies, the player finds the exit or the quit key (SHIFT + Q) is pressed. </remarks>
    member this.Play () : unit =
        Console.Clear ()
        p.CurrentField <- board.GetData (fst p.Pos, snd p.Pos)
        p.RenderOn (board)
        printfn "\n    WELCOME TO THE DUNGEON. PRESS ARROWKEY TO ESCAPE. BEWARE OF... EVERYTHING\n    PRESS SHIFT + Q IF YOU'RE TOO SCARED\n\n\n"
        let theExit = Exit (snd board.size - 1,fst board.size - 1)
        if exit then
            this.AddItem (theExit)
        else printfn "\n    GOOD LUCK FINDING THE EXIT MY FRIEND :)\n\n\n"
        board.Show ()

        let mutable exitcon = false

        while (not exitcon) do
            let keyInput = Console.ReadKey true
            
            match keyInput.Key with
            | ConsoleKey.LeftArrow -> if fst p.Pos = 0 then ()
                                      else p.NextField <- board.GetData (fst p.Pos - 1, snd p.Pos)
                                           let c, fg, bg = p.CurrentField
                                           board.Set (fst p.Pos, snd p.Pos, c, fg, bg)
                                           p.MoveTo (fst p.Pos - 1, snd p.Pos)
                                           this.Update ()

            | ConsoleKey.RightArrow -> if fst p.Pos = snd board.size - 1 then ()
                                       else p.NextField <- board.GetData (fst p.Pos + 1, snd p.Pos)
                                            let c, fg, bg = p.CurrentField
                                            board.Set (fst p.Pos, snd p.Pos, c, fg, bg)
                                            p.MoveTo (fst p.Pos + 1, snd p.Pos)
                                            this.Update ()

            | ConsoleKey.UpArrow -> if snd p.Pos = 0 then ()
                                    else p.NextField <- board.GetData (fst p.Pos, snd p.Pos - 1)
                                         let c, fg, bg = p.CurrentField
                                         board.Set (fst p.Pos, snd p.Pos, c, fg, bg)
                                         p.MoveTo (fst p.Pos, snd p.Pos - 1)
                                         this.Update ()

            | ConsoleKey.DownArrow -> if snd p.Pos = fst board.size - 1 then ()
                                      else p.NextField <- board.GetData (fst p.Pos, snd p.Pos + 1)
                                           let c, fg, bg = p.CurrentField
                                           board.Set (fst p.Pos, snd p.Pos, c, fg, bg)
                                           p.MoveTo (fst p.Pos, snd p.Pos + 1)
                                           this.Update ()

            | ConsoleKey.Q -> if keyInput.Modifiers = ConsoleModifiers.Shift then exitcon <- true ; Console.Clear ()
            | _ -> () |> ignore

            if p.IsDead then
              exitcon <- true
              Console.Clear ()
              for i in [ [5; 5;6;10;11;14;18;20;21;22;23;29;30;33;36;38;39;40;41;43;44;45]
                         [6; 4;9;12;14;15;17;18;20;28;31;33;36;38;43;45;46]
                         [7; 4;6;7;9;10;11;12;14;15;16;17;18;20;21;22;28;31;33;36;38;39;40;43;44;45]
                         [8; 4;7;9;12;14;16;18;20;28;31;33;36;38;43;45;46]
                         [9; 5;6;9;12;14;18;20;21;22;23;29;30;34;35;38;39;40;41;43;46]] do
                for j in i.[1..i.Length - 1] do
                  loseBoard.Set (j, i.Head, ' ', Color.White, Color.DarkRed)
              loseBoard.Show()
            elif theExit.quit then
              exitcon <- true
              Console.Clear ()
              for i in [  [5; 4;8;11;12;15;18;23;27;30;31;34;38]
                          [6; 4;5;7;8;10;13;15;18;23;27;29;32;34;35;38]
                          [7; 5;6;7;10;13;15;18;23;25;27;29;32;34;36;38]
                          [8; 6;10;13;15;18;23;24;25;26;27;29;32;34;37;38]
                          [9; 6;11;12;16;17;24;26;30;31;34;38]] do

                for j in i.[1..i.Length - 1] do
                  winBoard.Set (j, i.Head, ' ', Color.White, Color.Green)
              winBoard.Show()
            else ()