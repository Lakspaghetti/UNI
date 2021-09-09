type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

type card = rank * suit

let sameRank (c1: card) (c2: card) : bool =
    if (fst c1) = (fst c2) then
        true
    else
        false

printfn "\nThe function sameRank returns \"%A\" when it's two of hearts and two of diamonds\n" (sameRank (Two, Hearts) (Two, Diamonds))
printfn "\nThe function sameRank returns \"%A\" when it's two of hearts and three of diamonds\n" (sameRank (Two, Hearts) (Three, Diamonds))