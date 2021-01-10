let a = 2
let b = [2; 3; 4; 5; 2; 3; 2; 6; 7; 2]
let c = List.filter (fun x -> x % 2 = 0 && x >= 4) b
printfn "%A" c