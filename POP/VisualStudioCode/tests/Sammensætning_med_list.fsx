let iter x = [1..x]
let dbl x = [x; x]

let (>>=) x f = List.collect f x
printfn "%A" (3 |> iter >>= dbl)

let rec powerset lst = 
    match lst with 
        | [] -> [[]]
        | x::xs -> xs |> powerset >>= (fun ys -> [ys; x::ys])
printfn "%A" [1;2;3]