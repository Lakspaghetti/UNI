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

          
let line (a0:float) (a1:float) (x:float) : float =
    let list = [a0; a1]
    if a0 = 0.0 || a1 = 0.0 then 
        nan
    else
        poly list x

printfn "%A" (line 2.0 1.5 2.3)

