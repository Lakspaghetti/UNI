type account (name:string) =
    let accName = name

    let mutable balance = 0
    let mutable transactions = []

    static let mutable lastAccountNumber = 0
    let id = lastAccountNumber <- lastAccountNumber + 1; lastAccountNumber
    static member lastAccount = lastAccountNumber
    member this.currentNumber = id

    member this.add (textD:string) (amount:int) : unit =
        transactions <- (textD, balance + amount) :: transactions
        balance <- balance + amount
    
    member this.Balance () : int =
        if transactions = [] then
            0
        else
            snd(transactions.Head)

    member this.transactionslist = transactions

let testAccount = account("mig")
printfn "last account:%A" account.lastAccount 
printfn "%A" testAccount.transactionslist
printfn "balance:%A" (testAccount.Balance ())
testAccount.add ("random") (5)
printfn "balance:%A" (testAccount.Balance ())
testAccount.add ("random") (5)
printfn "balance:%A" (testAccount.Balance ())
testAccount.add ("random") (-5)
printfn "balance:%A" (testAccount.Balance ())
printfn "%A" testAccount.transactionslist

let sndtestAccount = account("dig")
printfn "\nlast account:%A" account.lastAccount
printfn "%A" sndtestAccount.transactionslist
printfn "balance:%A" (sndtestAccount.Balance ())
sndtestAccount.add ("random") (3)
printfn "balance:%A" (sndtestAccount.Balance ())
sndtestAccount.add ("random") (3)
printfn "balance:%A" (sndtestAccount.Balance ())
sndtestAccount.add ("random") (-3)
printfn "balance:%A" (sndtestAccount.Balance ())
printfn "%A" sndtestAccount.transactionslist

printfn "\n%A" testAccount.currentNumber