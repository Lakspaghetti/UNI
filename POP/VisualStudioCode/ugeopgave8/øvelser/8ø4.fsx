let sumsq (fl:float list) : float =
    let squares = List.map (fun x -> x*x) fl
    List.fold (+) 0.0 squares

printfn "%A" (sumsq [3.0;4.0])
