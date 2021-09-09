let facOption (n:int) : int option = 
    if n<1 || n>13 then 
        None 
    else
        let rec counter (m:int) : int option =
            if m=1 then Some(1) else Some(m * (Option.get (counter(m-1))))
        counter n

printfn "%A" (facOption 13)
