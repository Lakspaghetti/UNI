let poly (fl:float list) (x:float) : float =
    let mutable xList = fl
    let mutable result = 0.0
    let mutable coefficient = 0.0
    if fl = [] then 
        0.0
    else
        for i = 0 to (fl.Length - 1) do
            result <- result + xList.Head * x**coefficient 
            xList <- xList.Tail
            coefficient <- coefficient + 1.0
        result

let randomList = [ 1.0; 2.0; 3.0 ] 
printfn "%A" (poly randomList 2.0)

          