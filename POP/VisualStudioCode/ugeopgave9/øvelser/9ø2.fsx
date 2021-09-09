let facFailWith (n:int) : int =
    if n<1 then 
        failwith "argument must be greater than 0"
    else
        if n>13 then
            failwith "calculation would result in an overflow"
        else
            let number = n
            let rec result (m: int): int =
                if m<=1 then 
                    1
                else 
                    m * result (m-1)
            (result n)

try 
    printfn "%A" (facFailWith 1)
    printfn "%A" (facFailWith 4)
    printfn "%A" (facFailWith 12)
    printfn "%A" (facFailWith 13)
with
    Failure msg -> printfn "%s" msg

