type suit = Hearts | Diamonds | Clubs | Spades

let succSuit (s: suit) : (suit) option =
    match s with
    | Hearts -> Some(Diamonds)
    | Diamonds -> Some(Clubs)
    | Clubs -> Some(Spades)
    | Spades -> None

printfn "\nsuccSuit returns \"%A\" when it's Hearts\n" (succSuit Hearts)
printfn "\nsuccSuit returns \"%A\" when it's Spades\n" (succSuit Spades)
