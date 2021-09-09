module Shuffle

type Card = int
type Deck = Card list

/// <summary>Deal a Deck of Cards into two smaller Decks of equal size.
/// If the amount of Cards are odd, then the first Deck is prioritized.  </summary>
/// <param name="d">Deck of Cards</param>
/// <returns>A tuple with the resulting Decks as elemnts</returns>
let deal (d: Deck): Deck * Deck =
    let mutable d1 = [] //These mutables are the output Decks
    let mutable d2 = [] //Check if the deck is of even elements
    for i in 0 .. d.Length - 1 do //Go through all indexes
        if i % 2 = 0 then d1 <- d.[i] :: d1 else d2 <- d.[i] :: d2 //Use the index to decide which deck gets the card
    (d1, d2)

/// <summary>Get a random number from an interval</summary>
/// <param name="n">An integer which is the upper bound of the interval [0;n[</param>
/// <returns>An integer number</returns>
let rand: int -> int =
    let rnd = System.Random()
    fun n -> rnd.Next(0, n)

/// <summary>Shuffle a Deck of Cards</summary>
/// <param name="d">The Deck of Cards which will be shuffled</param>
/// <param name="acc">An accumulator to store the shuffled deck.
/// This is usually an empty list, when calling the function</param>
/// <returns>The same Deck of Cards, with the Cards in random order</returns>
let rec shuffle (d: Deck) (acc: Deck): Deck =
    let l = rand (d.Length)
    match d.Length, l + 1 with
    | 1, _ -> d.[0] :: acc
    | _, len when len = d.Length -> shuffle (d.[..l - 1]) (d.[l] :: acc)
    | _, 1 -> shuffle (d.[1..]) (d.[0] :: acc)
    | _, _ -> shuffle (d.[..l - 1] @ d.[l + 1..]) (d.[l] :: acc)

///<summary> create a new Deck consisting of 4 series of 13 Cards, which can have the values 2-14</summary>
///<param name = "()"> an empty unit to create the Deck inside </param>
///<returns> A shuffled Deck of 52 Cards </returns>
let newDeck (): Deck =
    let mutable fullDeck: Deck = []
    let mutable i = 1
    while i <= 4 do
        for j in 2 .. 14 do
            fullDeck <- j :: fullDeck
        i <- i + 1
    shuffle fullDeck []

