let isTable (llst:'a list list) =
    if llst.IsEmpty || llst.[0].IsEmpty then
        false
    else
        let llstLen = llst.Length
        let subLen = llst.[0].Length
        let newlist = List.init (llstLen) (fun i -> llst.[i].Length)
        List.forall (fun x -> x = subLen) newlist


printfn " "
printfn "White box test isTable:"
printfn " "
printfn "%5A: Branch 1a test: returns false when table is empty" (isTable [[]]) 
printfn "%5A: Branch 2b test: returns true when table consists of lists of equal length " (isTable [[1;2;3];[4;5;6]])
printfn "%5A: Branch 2c test: returns false when table consists of lists of unequal length" (isTable [[1;2;3];[4;5;6;7]])
