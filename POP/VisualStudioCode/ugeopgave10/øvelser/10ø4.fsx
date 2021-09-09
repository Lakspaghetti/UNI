type Moth(x:float, y:float) =
    let mutable mothCoordinates = (x, y)
    member this.getPosition () : (float * float) = 
        mothCoordinates
    member this.moveToLight () : unit = 
        mothCoordinates <- ((fst mothCoordinates) - (fst mothCoordinates/2.0), (snd mothCoordinates) - (snd mothCoordinates/2.0))

let testMoth = Moth(5.0, 5.0)
let sndTestMoth = Moth(-5.0,-5.0)

printfn "%A" (testMoth.getPosition ())
printfn "%A" (sndTestMoth.getPosition ()) 

testMoth.moveToLight ()
sndTestMoth.moveToLight ()

printfn "%A" (testMoth.getPosition ())
printfn "%A" (sndTestMoth.getPosition ()) 
   