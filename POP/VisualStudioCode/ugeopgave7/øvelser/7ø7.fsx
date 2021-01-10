type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

type card = rank * suit

let succSuit (s: suit) : (suit) option =
    match s with
    | Hearts -> Some(Diamonds)
    | Diamonds -> Some(Clubs)
    | Clubs -> Some(Spades)
    | Spades -> None

let succRank (r: rank) : (rank) option =
    match r with
   | Two -> Some(Three)
   | Three -> Some(Four)
   | Four -> Some(Five)
   | Five -> Some(Six)
   | Six -> Some(Seven)
   | Seven -> Some(Eight)
   | Eight -> Some(Nine)
   | Nine -> Some(Ten)
   | Ten -> Some(Jack)
   | Jack -> Some(Queen)
   | Queen -> Some(King)
   | King -> Some(Ace)
   | Ace -> None


let succCard (c: card) : (card) option =
    let (c1, c2) = succRank(fst c), succSuit(snd c)
    match c1, c2 with
    | None, None -> None
    | None, Some(suit) -> Some(Two, suit)
    | Some(rank), Some(suit) -> Some(rank, snd c)
    | Some(rank), None -> Some(rank, snd c)


let initDeck () : card list =
    let card = (Two, Hearts)
    let mutable fullDeck : card list = []
    let rec Helper (c: card) : card list =
        fullDeck <- c :: fullDeck
        match succCard(c) with
        | Some(rank, suit) -> Helper(rank, suit)
        | None -> fullDeck
    Helper(card)
    
printfn "The function initDeck returns a deck with the length %A and it is looking as the following: \n%A" ((initDeck()).Length) (initDeck ()) 



