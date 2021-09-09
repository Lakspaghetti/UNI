exception ArgumentTooBig of string 

let fac (n:int) : int =
    if n<1 then 
        raise (System.ArgumentException "Error: \"function was called with a number less than 1\"")
    else
        if n>32 then
            raise (ArgumentTooBig "calculation would result in an overflow")
        else
            let number = n
            let rec result (m: int): int =
                if m=1 then 
                    m
                else 
                    m * result (m-1)
            (result number) - 1

try 
    printfn "%A" (fac 5)
    printfn "%A" (fac 32)
    printfn "%A" (fac 33)
with
    | ArgumentTooBig msg -> printfn "%A" msg

