module ReadNWrite

open System.IO

///<summary>takes a filename and returns the contents of the text file as a string option</summary>
///<param name = "filename">the contents of a given text file as a string</param> 
///<returns>a string option value</returns>
/// 
let readFile (filename: string): string option =
  try
    let reader = File.OpenText filename
    let text = reader.ReadToEnd ()
    Some text
  with
    | _ -> None

///<summary>merges the content of several files into a single string option</summary>
///<param name = "filenames">A list of strings. Each string contains the contents of a given text file</param> 
///<returns>a string option value</returns>
/// 
let cat (filenames: string list): string option =
  let options = filenames |> List.map readFile
  if List.exists (fun elem -> elem = None) options || List.isEmpty filenames then None
  else
    let rec concat (list: string option list): string option =
      match list with
        | [Some x] -> Some x
        | Some x :: tail -> Some (x + "\n" + (Option.get (concat tail)))
        | _ -> None
    concat options

///<summary>reverse the order of several files for each file, each line and each character. Merges the content into a single string option</summary>
///<param name = "filenames">A list of strings. Each string contains the contents of a given text file</param> 
///<returns>a string option value</returns>
/// 
let tac (filenames: string list): string option =
  let options = filenames |> List.map readFile
  if List.exists (fun elem -> elem = None) options || List.isEmpty filenames then None
  else
    Some (Option.get(cat filenames) |> Seq.rev |> System.String.Concat)