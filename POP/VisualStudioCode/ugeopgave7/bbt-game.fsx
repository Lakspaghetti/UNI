#r "wargame-shuffle.dll"
#r "wargame-game.dll"

open Shuffle
open Game

let testCases = [
    ("Decks with more than 1 card.",
     [([2; 3; 4; 5; 6; 7; 8; 9], Some(2, [3; 4; 5; 6; 7; 8; 9]));
      ([3; 5; 7; 9; 11; 13], Some(3, [5; 7; 9; 11; 13]));
      ([10; 14], Some(10, [14]));
      ([14; 13; 12; 11; 10], Some(14, [13; 12; 11; 10]));]);
    ("Decks of 1 card",
     [([4], Some(4, []));
      ([14], Some(14, []));
      ([10], Some(10, []));
      ([5], Some(5, []));]);
    ("Empty deck",
     [([], None);]);
]

printfn "Black-box testing of getCard function"
for i = 0 to testCases.Length - 1 do
    let (setName, testSet) = testCases.[i]
    printfn " %d. %s" (i+1) setName
    for j = 0 to testSet.Length - 1 do
        let (inp, expected) = testSet.[j]
        let output = getCard inp
        printfn "   test %d:\n       input: %A\n       validity: %b" (j+1) inp (output = expected)



let addCards (p: Player) (d: Deck): Player = p @ d

/// Black-box test of the function newDeck in the library CardgameOp

/// unit : "newDeck"
/// Case:                                       Input:                      Expected output:
/// Empty player and a deck of 3 cards          p=[], d=[1; 2; 3]           [1; 2; 3]
/// player of 3 cards and a deck of 3 cards     p=[1; 2; 3], d=[4; 5; 6]    [1; 2; 3; 4; 5; 6]
/// player of 3 cards and an empty deck         p=[1; 2; 3], d=[]           [1; 2; 3]
printfn "\n Black-box test of addCards\n\n test 1: %b : Input: p=[], d=[1; 2; 3]. Expected output: %A" (addCards [] [1; 2; 3] = [1; 2; 3;]) (addCards [][1; 2; 3;])
printfn "\n test 2: %b : Input: p=[1; 2; 3], d=[4; 5; 6]. Expected output: %A" (addCards [1; 2; 3] [4; 5; 6] = [1; 2; 3; 4; 5; 6]) (addCards [1; 2; 3;] [4; 5; 6;])
printfn "\n test 3: %b : Input: p=[1; 2; 3], d=[]. Expected output: %A" (addCards [1; 2; 3] [] = [1; 2; 3]) (addCards [1; 2; 3] [])



let rec gametest (c: Card list) (p1: Player) (p2: Player): int =
    let c1, c2 = getCard p1, getCard p2
    match c1, c2 with
    | None, None -> 0
    | None, _ -> 2
    | _, None -> 1
    | Some (h1, t1), Some (h2, t2) when h1 > h2 -> gametest [] (addCards t1 [ h1; h2 ] @ c) t2
    | Some (h1, t1), Some (h2, t2) when h2 > h1 -> gametest [] t1 (addCards t2 [ h1; h2 ] @ c)
    | Some (h1, []), Some (h2, []) when h1 = h2 -> 0
    | Some (h1, []), Some (h2, _) when h1 = h2 -> 2
    | Some (h1, _), Some (h2, []) when h1 = h2 -> 1
    | Some (h1, h12::t1), Some (h2, h22::t2) when h1 = h2 -> gametest ([ h1; h2; h12; h22 ] @ c) t1 t2

/// Blackbox test game

/// Unit: game
/// 
/// Input               Expected output     Comment
/// p1 = [2;3;4;5]
/// p2 = [2;3;4;5]      0                   Draw by matchcase | None, None -> 0 (line 10). This play also makes use of the matchcase line 18
/// 
/// p1 = [2;3;4]
/// p2 = [2;3;4]        0                   Draw by | Some (h1, []), Some (h2, []) when h1 = h2 -> 0 (line 15)
/// 
/// p1 = [2;4;5;6]
/// p2 = [2;3;4;5]      1                   Player 1 wins by matchcase | _, None -> 1 (line 12). This play also makes use of the matchcase line 13
/// 
/// p1 = [2;3;4;5]
/// p2 = [2;4;5;6]      2                   Player 2 wins by matchcase | None, _ -> 2 (line 11). This play also makes use of the matchcase line 14
///
/// p1 = [3;3;4]
/// p2 = [2;3;4]        1                   Player 1 wins by matchcase | Some (h1, _), Some (h2, []) when h1 = h2 -> 1 (line 17)
///  
/// p1 = [2;3;4]
/// p2 = [3;3;4]        2                   Player 2 wins by matchcase | Some (h1, []), Some (h2, _) when h1 = h2 -> 2 (line 16)
      


printfn "If cards are dealt as P1: [2;3;4;5] and P2: [2;3;4;5] it's a draw:  \n%b\n" ((gametest [] [2;3;4;5] [2;3;4;5]) = 0)
printfn "If cards are dealt as P1: [2;3;4] and P2: [2;3;4] it's a draw:  %b\n" ((gametest [] [2;3;4] [2;3;4]) = 0)
printfn "If cards are dealt as P1: [2;4;5;6] and P2: [2;3;4;5] P1 wins:  %b\n" ((gametest [] [2;4;5;6] [2;3;4;5]) = 1)
printfn "If cards are dealt as P1: [2;3;4;5] and P2: [2;4;5;6] P2 wins:  %b\n" ((gametest [] [2;3;4;5] [2;4;5;6]) = 2)
printfn "If cards are dealt as P1: [3;3;4] and P2: [2;3;4] P1 wins:      %b\n" ((gametest [] [3;3;4] [2;3;4]) = 1)
printfn "If cards are dealt as P1: [2;3;4] and P2: [3;3;4] P2 wins:      %b\n" ((gametest [] [2;3;4] [3;3;4]) = 2)