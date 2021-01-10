let x = 2
let y = 3
let a = 4
let gx = fun (x) -> x*2
let fx = fun (x) -> x+1

printfn "%A" ( 2+4+5 |> gx)
printfn "%A" ( gx <| 5+5 )

printfn "%A" (((fx) << (gx)) 5)
printfn "%A" (((fx) >> (gx)) 5)
