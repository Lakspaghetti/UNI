open System.Net
open System
open System.IO


/// <summary> Fetch a website as a string and count the amount of links on the website </summary>
/// <param name="url"> The url passed as a string </param>
/// <returns> An integer representing the amount of links on the webpage </returns>
/// <remarks> Some websites might not yield a result. The reason is unknown </remarks>
let countLinks (url:string): int =
  try
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new StreamReader(stream)
    (reader.ReadToEnd().Split "<a").Length - 1
  with
    | exn -> printfn "%s" exn.Message; 1

printfn "%i" (countLinks "http://google.dk")
printfn "%i" (countLinks "http://www.dnur.dk/")