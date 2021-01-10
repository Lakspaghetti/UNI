module Stats

open Shuffle

type Player = Deck


/// This function has XML-tags in the wargame-game.fs file
let getCard (p: Player): (Card * Player) option =
    match p with
    | h :: t -> Some(h, t)
    | [] -> None


/// This function has XML-tags in the wargame-game.fs file
let addCards (p: Player) (d: Deck): Player = p @ (shuffle d [])


/// <summary> The same function as in the file wargame-game.fs file, but modified to include the number of rounds a game lasts. </summary>
/// <param name="udspl"> The number of rounds the game has currently underwent. When starting the game, set this to 0. </param>
/// <returns> A list with two elements, representing the winner and the number of rounds a game has lasted. </returns>
let rec game (c: Card list) (p1: Player) (p2: Player) (udspl: int): int list =
    let c1, c2 = getCard p1, getCard p2
    match c1, c2 with
    | None, None -> [0; udspl]
    | None, _ -> [2; udspl]
    | _, None -> [1; udspl]
    | Some (h1, t1), Some (h2, t2) when h1 > h2 -> game [] (addCards t1 [ h1; h2 ] @ c) t2 (udspl + 1)
    | Some (h1, t1), Some (h2, t2) when h2 > h1 -> game [] t1 (addCards t2 [ h1; h2 ] @ c) (udspl + 1)
    | Some (h1, []), Some (h2, []) when h1 = h2 -> [0; udspl]
    | Some (h1, []), Some (h2, _) when h1 = h2 -> [2; udspl]
    | Some (h1, _), Some (h2, []) when h1 = h2 -> [1; udspl]
    | Some (h1, h12::t1), Some (h2, h22::t2) when h1 = h2 -> game ([ h1; h2; h12; h22 ] @ c) t1 t2 (udspl + 1)


/// <summary> Simulate two players playing war-game an amount of times </summary>
/// <param name="N"> The number of times we want the game to be simulated </param>
/// <returns> A unit type. This will output a report of how many games each player won, how many draws and the average amount of rounds pr. game </returns>
let runGames (N: int): unit =

    let mutable i = 0
    let mutable pl1, pl2, udt, udspil, avg = 0, 0, 0, 0, 0

    while i < N do
        let pla1, pla2 = deal (newDeck ())
        let gameDecision = game [] pla1 pla2 0
        udspil <- udspil + gameDecision.[1]
        if gameDecision.[0] = 1 then pl1 <- pl1 + 1
        elif gameDecision.[0] = 2 then pl2 <- pl2 + 1
        else udt <- udt + 1
        i <- i + 1
    avg <- udspil / i 

    printfn "Player 1 won %A times, Player 2 won %A times, The game was a draw %A times, In an average of %A rounds." pl1 pl2 udt avg
runGames 10000