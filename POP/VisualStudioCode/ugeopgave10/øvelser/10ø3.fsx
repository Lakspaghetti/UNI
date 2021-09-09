type Car(eco:float) =
    let mutable currentFuel = 0.0
    let mutable carEco = eco
    member this.addGas (newGas:float) : unit =
        currentFuel <- currentFuel + newGas
    member this.gasLeft () : float =
        currentFuel
    member this.drive (km:float) : unit =
        let checker = currentFuel - carEco * km / 100.0
        if checker < 0.0 then 
            raise (System.ArgumentException "This distance is too far, compared to the cars fuel and eco") 
        else 
            currentFuel <- currentFuel - carEco * km / 100.0 

let sport = Car (8.0)
let economy = Car (5.0)

printfn "%A" (sport.gasLeft ())
printfn "%A" (economy.gasLeft ())

sport.addGas (60.0)
economy.addGas (45.0)

printfn "%A" (sport.gasLeft ())
printfn "%A" (economy.gasLeft ())

sport.drive (100.0)
economy.drive (100.0)

printfn "%A" (sport.gasLeft ())
printfn "%A" (economy.gasLeft ()) 

sport.drive (700.0)
printfn "%A" (sport.gasLeft ())