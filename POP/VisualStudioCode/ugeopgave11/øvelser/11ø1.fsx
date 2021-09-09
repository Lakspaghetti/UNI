type person (name:string, address:string, tNumber:int) =
    let PName = name
    let mutable Paddress = address
    let mutable PhoneN = tNumber

    member this.Phone = PhoneN

    member this.Name = PName

    member this.Address = Paddress


type customer (name:string, address:string, tNumber:int) =
    inherit person(name, address, tNumber)

    let mutable mailing = true

    static let mutable id = 0
    let customerID = customer.NextID()
    member this.ID = customerID
    static member NextID () =
        id <- id + 1
        id

    
    
    member this.Mailing with get () = mailing and set(x) = mailing <- x

let fstCustomer = customer ("Mikkel", "vba", 60630782)
let sndCustomer = customer ("Magnus", "gtb", 69696969)
printfn "%A" fstCustomer.Name
printfn "%A" fstCustomer.Address
printfn "%A" fstCustomer.Phone

printfn "\n%A" fstCustomer.ID
printfn "%A" fstCustomer.Mailing
fstCustomer.Mailing <- false
printfn "%A" fstCustomer.Mailing

printfn "\n%A" sndCustomer.ID




