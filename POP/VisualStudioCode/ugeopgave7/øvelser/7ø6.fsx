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


printfn "\nsuccCard returns \"%A\" when it's Two of Hearts\n" (succCard (Two, Hearts))
printfn "succCard returns \"%A\" when it's Ace of Spades\n" (succCard (Ace, Spades))
printfn "succCard returns \"%A\" when it's Ace of Hearts\n" (succCard (Ace, Hearts))
printfn "succCard returns \"%A\" when it's Two of Spades\n" (succCard (Two, Spades))

