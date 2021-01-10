#r "wargame-shuffle.dll"

open Shuffle

let testCases = [
    ("A Deck of even amount of cards",
     [([2; 3; 4; 5; 6; 7; 8; 9], ([8; 6; 4; 2], [9; 7; 5; 3]));
      ([3; 5; 7; 9; 11; 13], ([11; 7; 3], [13; 9; 5]));
      ([2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13], ([12; 10; 8; 6; 4; 2], [13; 11; 9; 7; 5; 3]));
      ([], ([], []));])
    ("A Deck of uneven amount of cards",
     [([4; 9; 2; 5; 3], ([3; 2; 4], [5; 9]));
      ([2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14], ([14; 12; 10; 8; 6; 4; 2], [13; 11; 9; 7; 5; 3;]));
      ([10], ([10], []));
      ([3; 10; 12], ([12; 3], [10]));])
]

printfn "Black-box testing of deal function"
for i = 0 to testCases.Length - 1 do
    let (setName, testSet) = testCases.[i]
    printfn " %d. %s" (i+1) setName
    for j = 0 to testSet.Length - 1 do
        let (inp, expected) = testSet.[j]
        let output = deal inp
        printfn "   test %d:\n       input: %A\n       validity: %b" (j+1) inp (output = expected)

let rec shuffle0 (d: Deck) (acc: Deck): Deck =
    let l = 0
    match d.Length, l + 1 with
    | 1, _ -> d.[0] :: acc
    | _, len when len = d.Length -> shuffle0 (d.[..l - 1]) (d.[l] :: acc)
    | _, 1 -> shuffle0 (d.[1..]) (d.[0] :: acc)
    | _, _ -> shuffle0 (d.[..l - 1] @ d.[l + 1..]) (d.[l] :: acc)

let rec shuffle1 (d: Deck) (acc: Deck): Deck =
    let l = 1
    match d.Length, l + 1 with
    | 1, _ -> d.[0] :: acc
    | _, len when len = d.Length -> shuffle1 (d.[..l - 1]) (d.[l] :: acc)
    | _, 1 -> shuffle1 (d.[1..]) (d.[0] :: acc)
    | _, _ -> shuffle1 (d.[..l - 1] @ d.[l + 1..]) (d.[l] :: acc)

/// Blackbox test shuffle
/// As shuffle gives random outputs due to the use of the function rand we test alternative versions of shuffle
// shuffle0, l = 0 and shuffle1, l = 1 . Note the function will not run properly for 0 < l and l > 1


/// Unit        Case                                    Expected output                      Comment
             
///  shuffle0   d = [2;3;4;5;6;7;8;9;10;11;12;13;14]      
///             acc = []                                [14;13;12;11;10;9;8;7;6;5;4;3;2]     shuffle0 reverses d and appends the accumulator (nothing)           
///             d = [2;3;4;5;6;7]                       
///             acc = [8;9;10;11;12;13;14]              [7;6;5;4;3;2;8;9;10;11;12;13;14]     shuffle0 reverses d and appends the accumulator     
///
/// shuffle1    d = [2;3;4;5;6;7;8;9;10;11;12;13;14]      
///             acc = []                                [2;14;13;12;11;10;9;8;7;6;5;4;3]     shuffle1 puts the l'th element as head of the new Deck, reverses d from the l'th element and appends the accumulator (nothing) 
///             d = [2;3;4;5;6;7]                       
///             acc = [8;9;10;11;12;13;14]              [7;6;5;4;3;2;8;9;10;11;12;13;14]     shuffle1 puts the l'th element as head of the new Deck, reverses d from the l'th element and appends the accumulator


printfn "\nBlack-box test of shuffle function\n shuffle0 [2;3;4;5;6;7;8;9;10;11;12;13;14] [] = [14;13;12;11;10;9;8;7;6;5;4;3;2]: %b\n" (shuffle0 [2;3;4;5;6;7;8;9;10;11;12;13;14] [] = [14;13;12;11;10;9;8;7;6;5;4;3;2])
printfn " shuffle0 [2;3;4;5;6;7] [8;9;10;11;12;13;14]  = [7;6;5;4;3;2;8;9;10;11;12;13;14]: %b\n" (shuffle0 [2;3;4;5;6;7] [8;9;10;11;12;13;14] = [7;6;5;4;3;2;8;9;10;11;12;13;14] )

printfn " shuffle1 [2;3;4;5;6;7;8;9;10;11;12;13;14] [] = [2;14;13;12;11;10;9;8;7;6;5;4;3]: %b\n" (shuffle1 [2;3;4;5;6;7;8;9;10;11;12;13;14] [] = [2;14;13;12;11;10;9;8;7;6;5;4;3])
printfn " shuffle1 [2;3;4;5;6;7] [8;9;10;11;12;13;14]  = [2;7;6;5;4;3;8;9;10;11;12;13;14]: %A\n" (shuffle1 [2;3;4;5;6;7] [8;9;10;11;12;13;14] = [2;7;6;5;4;3;8;9;10;11;12;13;14])
printfn "We assume that the given \"rand\" function is working as intended"

let newDeck (): Deck =
    let mutable fullDeck: Deck = []
    let mutable i = 1
    while i <= 4 do
        for j in 14 .. - 1 .. 2 do
            fullDeck <- j :: fullDeck
        i <- i + 1
    fullDeck

let Deck = [2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14]

/// Black-box test of the function newDeck in the library CardgameOp

/// unit : "newDeck"
/// Case:                               Input:              Expected output:
/// A Deck of 52 cars with values 2-14  ()                  [14; 13; 12; 11; 10; 9; 8; 7; 6; 5; 4; 3; 2; 14; 13; 12; 11; 10; 9; 8; 7; 6; 5; 4; 3; 2; 14; 13; 12; 11; 10; 9; 8; 7; 6; 5; 4; 3; 2; 14; 13; 12; 11; 10; 9; 8; 7; 6; 5; 4; 3; 2]
printfn "\n Black-box test of newDeck\n\n test 1:\n %b : input: () Output: %100A" (newDeck () = Deck) (newDeck ())