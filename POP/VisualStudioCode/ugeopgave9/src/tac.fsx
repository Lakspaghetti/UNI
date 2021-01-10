open ReadNWrite

///<summary>takes an array of filenames as command-line arguments and returns 1 in case of error 0 otherwise</summary>
///<param name = "args">a list of filenames as command-line arguments</param> 
///<returns>1 in case of error 0 otherwise</returns>
/// 
[<EntryPoint>]
let main (args: string array): int =
  try
    match (tac (args |> Array.toList)) with
      | Some x -> printfn "%s" x; 0
      | None -> 1
  with
    | _ -> 1
