open System.IO

let readFile (filename : string) : string option =
    try
        let reader = File.OpenText filename
        let line = reader.ReadToEnd ()
        Some line
    with
        | _ -> None

printfn "%A\n\n" (readFile "File.txt")
printfn "%A\n\n" (readFile "Files.txt")

let rec cat (filenames: string list) : string option =
    let options = filenames |> List.map readFile
    if List.exists (fun elem -> elem = None) options || (List.isEmpty filenames) then None
    else
        match filenames with
            | [x] -> Some x
            | x :: tail -> Some(x + " " + Option.get (cat tail))
            | _ -> None
    
printfn "%A" (cat [])
            
    