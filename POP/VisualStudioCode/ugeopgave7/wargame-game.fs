module Game

open Shuffle

type Player = Deck


/// <summary> Extracts a card from a deck. </summary>
/// <param name="p"> A list of integer cards, which represents a player. </param>
/// <returns> A tuple option. If the input is empty, return None, else return a tuple with the first card and the rest of the deck. </returns>
let getCard (p: Player): (Card * Player) option =
    match p with
    | h :: t -> Some(h, t)
    | [] -> None
printfn "%A" (getCard [])


/// <summary> Add a deck of cards to a players deck of cards. </summary>
/// <param name="p"> A list of integer cards, which represents a player. </param>
/// <param name="d"> A list of integer cards, which represents the deck we want to add to the players deck. </param>
/// <returns> A list of integer cards representing the players new deck of cards. </returns>
let addCards (p: Player) (d: Deck): Player = p @ (shuffle d [])


/// <summary> Simulate a full game of war-game. </Summary>
/// <param name="c"> The list of integer cards on the table, which a player wins when he win the round. Ususally [] (empty list). </param>
/// <param name="p1"> A list of integer cards, which represents player 1. </param>
/// <param name="p2"> A list of integer cards, which represents player 2. </param>
/// <returns> An integer representing the winner of the game. 1 for player 1 win, 2 for player 2 win and 0 for a draw. </returns>
let rec game (c: Card list) (p1: Player) (p2: Player): int =
    let c1, c2 = getCard p1, getCard p2
    match c1, c2 with
    | None, None -> 0
    | None, _ -> 2
    | _, None -> 1
    | Some (h1, t1), Some (h2, t2) when h1 > h2 -> game [] (addCards t1 [ h1; h2 ] @ c) t2
    | Some (h1, t1), Some (h2, t2) when h2 > h1 -> game [] t1 (addCards t2 [ h1; h2 ] @ c)
    | Some (h1, []), Some (h2, []) when h1 = h2 -> 0
    | Some (h1, []), Some (h2, _) when h1 = h2 -> 2
    | Some (h1, _), Some (h2, []) when h1 = h2 -> 1
    | Some (h1, h12::t1), Some (h2, h22::t2) when h1 = h2 -> game ([ h1; h2; h12; h22 ] @ c) t1 t2

let pla1, pla2 = deal (newDeck())
printfn "%A" (game [] pla1 pla2)