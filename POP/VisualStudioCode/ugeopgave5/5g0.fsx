/// <summary> Checks if the input list of lists is a valid table </summary>
/// <param name="llst"> A list of lists </param>
/// <returns> true if the input is a valid table, false if not </returns>

let isTable (llst:'a list list) =
    if llst.IsEmpty || llst.[0].IsEmpty then // First check if llst is empty
        false
    else
        let llstLen = llst.Length // Find the length of llst
        let subLen = llst.[0].Length // A reference length, to compare other sublists to
        let newlist = List.init (llstLen) (fun i -> llst.[i].Length) // Create new list with elements being the length of the corresponding sublist
        List.forall (fun x -> x = subLen) newlist // See if the sublist length matches the reference length

// White box test isTable

printfn " "
printfn "White box test isTable:"
printfn " "
printfn "%5b: Branch 1a test: returns false when table is empty" (isTable [[];[]] = false)
printfn "%5b: Branch 2a test: returns true when table consists of lists of equal length " (isTable [[1;2;3];[4;5;6]] = true)
printfn "%5b: Branch 2b test: returns false when table consists of lists of unequal length" (isTable [[1;2];[3;4;5]] = false)

//  Unit        Branch  Condition                               Input type          Exp. output     Comment
//  isTable     1       receives input type (llst:'a list list)
//              1a      true                                    [[];[]] / []        false           Returns false when table is empty 
//              1b      false                                                                       -> branch 2
//              2       Input is a list of a list/lists      
//              2a      newlist = sublength                     [[1;2;];[4;5;]]     true            List.forall returns true if all elements in lst are true when f is applied to them
//              2b      newlist != sublength                    [[1;2;];[3;4;5]]    false           List.forall returns false if not all elements in lst are true when f is applied to them


/// <summary> Isolate the first column in a list of lists </summary>
/// <param name = "llst"> A list of lists </param>
/// <returns> A list of lists of the first element of each sublist of the tabular input </returns>/// <remarks> This function checks if the input is valid, this could've been done easier with isTable function </remarks>


let firstColumn (llst:'a list list) : 'a list =
    if isTable llst then // Check if input is a table
        List.map (fun x -> List.head x) llst // Return only the heads of each sublists
    else
        [] // If llst is not a table, return an empty list

// White box test firstColumn

printfn " "
printfn "White box test firstColumn:"
printfn " "
printfn "%5b: Branch 1a test: returns first elements of inner lists when given a table according to isTable" (firstColumn [[1;2;3];[4;5;6]] = [1;4])
printfn "%5b: Branch 2a test: returns [] when when not given a table according to isTable " (firstColumn [[];[]] = [])

//  Unit        Branch  Condition                               Input type          Exp. output     Comment
//  firstColumn 1       receives input type (llst:'a list list)
//              1a      true                                    [[1;2;];[4;5;]]     [1;4;]          Returns the head of each sublist              
//              1b      false                                                                       -> branch 2
//              2       Input is an empty table      
//              2a      Input is an empty table                 [[];[]]             []              Returns an empty list                    


/// <summary> Isolate all but the first column of the tabular input </summary>
/// <param name = "llst"> A list of lists </param>
/// <returns> A list of lists of all but the first element in each sublist of the input </returns>

let dropFirstColumn (llst:'a list list) : 'a list list =
    if isTable llst then // Check if input is a table
        List.map (fun x -> List.tail x) llst // return all but the head of all sublists, as sublists in a list
    else
        [] // If llst is not a table, return an empty list

// White box test dropfirstColumn

printfn " "
printfn "White box test dropFirstColumn:"
printfn " "
printfn "%5b: Branch 1a test: returns all but the first elements of inner lists when given a table according to isTable" (dropFirstColumn [[1;2;3];[4;5;6]] = [[2;3];[5;6]])
printfn "%5b: Branch 2a test: returns [] when not given a table according to isTable" (dropFirstColumn [[];[]] = [])

//  Unit        Branch  Condition                               Input type          Exp. output     Comment
//  dropFirstColumn     
//              1       receives input type (llst:'a list list)
//              1a      true                                    [[1;2;3];[4;5;6]]   [[2;3];[5;6]]   Returns all but the first elements of inner lists when a table is given
//              1b      false                                                                       -> branch 2
//              2       Input is an empty table      
//              2a      Input is an empty table                 [[];[]]             []              Returns an empty list                    


/// <summary> Transposes the input list of lists </summary>
/// <param name="llst"> A list of lists </param>
/// <returns> A new list of lists, where the input columns are the output rows and the input rows are the output columns </returns>

let rec transposeLstLst (llst:'a list list) : 'a list list =
    if isTable llst then // Check if input is a table
        firstColumn llst :: transposeLstLst (dropFirstColumn llst) // Take the first column as a list, concatenate with the second column as a list, and so on.
    else
        [] // If llst is not a table, return an empty list

// White box test transposeLstLst 

printfn " "
printfn "White box test transposeLstLst n:"
printfn " "
printfn "%5b: Branch 1a test: returns the transposed list" (transposeLstLst [[1;2;3];[4;5;6]] = [[1;4];[2;5];[3;6]])
printfn "%5b: Branch 1b test: returns [] when when not given a table according to isTable" (transposeLstLst [[];[]] = [])
printfn " "

//  Unit        Branch  Condition                               Input type          Exp. output             Comment
//  transposeLstLst 
//              1       receives input type (llst:'a list list)
//              1a      true                                    [[1;2;3];[4;5;6]]   [[1;4];[2;5];[3;6]]     [[1;4];[2;5];[3;6]]
//              1b      false                                                                               -> branch 2
//              2       Input is not a table      
//              2a      Input is not a table                    [[];[]]             []                      Returns an empty list     
