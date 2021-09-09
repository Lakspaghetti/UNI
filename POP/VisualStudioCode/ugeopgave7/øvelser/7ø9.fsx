type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

type card = rank * suit

let sameSuit (c1: card) (c2: card) : bool =
    if (snd c1) = (snd c2) then
        true
    else
        false

printfn "\nThe function sameSuit returns \"%A\" when it's two of hearts and three of hearts\n" (sameSuit (Two, Hearts) (Three, Hearts))
printfn "\nThe function sameSuit returns \"%A\" when it's two of hearts and three of diamonds\n" (sameSuit (Two, Hearts) (Three, Diamonds))