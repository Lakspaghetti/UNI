type student(name:string) =
    member this.name = name

let student1 = student ("Mikkel")
let student2 = student ("Magnus")
let student3 = student ("Mathilde")

printfn "%s\n%s\n%s" student1.name student2.name student3.name