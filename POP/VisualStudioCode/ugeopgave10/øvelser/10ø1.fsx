type student(ID:string) =
    let mutable name = ID
    member this.setValue (newValue : string) : unit =  
        name <- newValue
    member this.getValue () : string = 
        name


let student1 = student ("Mikkel")
printfn "%s" (student1.getValue ())

let student2 = student ("Magnus")
printfn "%s" (student2.getValue ())

let student3 = student ("Mathilde")
printfn "%s" (student3.getValue ())
student3.setValue ("edlihtaM")
printfn "%s" (student3.getValue ())