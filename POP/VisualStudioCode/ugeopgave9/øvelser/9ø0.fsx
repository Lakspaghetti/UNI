let fac (n:int) : int =
    if n<1 then 
        raise (System.ArgumentException "Error: \"function was called on a number less than 1\"")
    else 
        let number = n
        let rec result (m: int): int =
            if m=1 then 
                m
            else 
                m * result (m-1)
        result number
          

printfn "%A" (fac 1)
printfn "%A" (fac 4)

