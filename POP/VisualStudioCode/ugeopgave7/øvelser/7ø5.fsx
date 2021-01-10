type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

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

printfn "\nsuccRank returns \"%A\" when it's Two\n" (succRank Two)
printfn "succRank returns \"%A\" when it's Ace\n" (succRank Ace)