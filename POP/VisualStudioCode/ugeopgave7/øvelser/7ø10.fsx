type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

type card = rank * suit

let highCard (c1: card) (c2: card) : card =
    if (fst c1) >= (fst c2) then
        c1
    else
        c2

printfn "\nThe function highCard returns \"%A\" when it's two of hearts and three of hearts\n" (highCard (Two, Hearts) (Three, Hearts))
printfn "\nThe function highCard returns \"%A\" when it's two of hearts and three of diamonds\n" (highCard (Two, Hearts) (Three, Diamonds))
printfn "\nThe function highCard returns \"%A\" when it's two of hearts and two of spades\n" (highCard (Two, Hearts) (Two, Spades))
printfn "\nThe function highCard returns \"%A\" when it's eight of clubs and king of spades\n" (highCard (Eight, Clubs) (King, Spades))