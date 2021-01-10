type Counter () =
    let mutable current = 0
    member this.incr () : unit =
        current <- current + 1
    member this.get () : int =
        current

let test = Counter ()
printfn "%A" (test.get ())
test.incr ()
printfn "%A" (test.get ())
test.incr ()
printfn "%A" (test.get ())
test.incr ()
printfn "%A" (test.get ())
test.incr ()
printfn "%A" (test.get ())
