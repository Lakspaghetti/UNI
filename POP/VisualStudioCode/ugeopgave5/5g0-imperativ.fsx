/// <summary> Checks if the input list of lists is a valid table </summary>
/// <param name="llst"> A list of lists </param>
/// <returns> true if the input is a valid table, false if not </returns>

let isTable (llst:'a list list) =
    if llst.IsEmpty || llst.[0].IsEmpty then // First check if llst is empty
        false
    else
        let mutable i = 0 // define a counter
        let mutable notBreakCon = true // define a break condition for the loop
        let refLen = llst.[0].Length // reference length to compare sublists to
        while i < llst.Length && notBreakCon do // breaks if break condition is relevant
                                                // else break when we are through whole llst
            for subLst in llst do // check all sublists of llst
                if subLst.Length <> refLen then
                    notBreakCon <- false // if the length of sublists are wrong, the loop breaks
                else
                    i <- i + 1
        notBreakCon // return true or false depending on the break condition from the loop

/// <summary> Isolate the first column in a list of lists </summary>
/// <param name = "llst"> A list of lists </param>
/// <returns> A list of lists of the first element of each sublist of the tabular input </returns>
/// <remarks> This function checks if the input is valid, this could've been done easier with isTable function </remarks>

let firstColumn (llst:'a list list) : 'a list =
    let mutable endList = [] // the list we end up with
    let intList = [] // the list to be returned if input is invalid
    if llst.IsEmpty then // check if llst is empty
        intList
    else
        let mutable i = 0 // counter
        let mutable notBreakCon = true // break condition in loop
        while i < llst.Length && notBreakCon do
            for subList in llst do
                if subList.IsEmpty then
                    notBreakCon <- false // if sublist is empty, break the loop
                else
                    endList <- List.append endList [subList.[0]] // append first elements of sublists to endList
                    i <- i + 1
        if notBreakCon then
            endList // return the endList if break condition has not been found
        else
            intList

/// <summary> Isolate all but the first column of the tabular input </summary>
/// <param name = "llst"> A list of lists </param>
/// <returns> A list of lists of all but the first element in each sublist of the input </returns>
/// <remarks> This function checks if the input is valid, this could've been done easier with isTable function </remarks>


let dropFirstColumn (llst:'a list list) : 'a list list =
    let mutable endList = []
    let intList = []
    if llst.IsEmpty then
        intList
    else
        let mutable i = 0
        let mutable notBreakCon = true
        while i < llst.Length && notBreakCon do
            for subList in llst do
                if subList.IsEmpty then
                    notBreakCon <- false
                else
                    endList <- List.append endList [subList.[1..]] // The excact same function as firstColumn
                                                                   // just append all except first element
                    i <- i + 1
        if notBreakCon then
            endList
        else
            intList

/// <summary> Transposes the input list of lists </summary>
/// <param name="llst"> A list of lists </param>
/// <returns> A new list of lists, where the input columns are the output rows and the input rows are the output columns </returns>


let transposeLstLst (llst:'a list list) : 'a list list =
    if isTable llst then
        let mutable transList = [firstColumn llst] // a list of the first column of llst
        let mutable newList = dropFirstColumn llst // the rest of llst after the first column is taken
        let mutable i = 1 // counter
        let mutable breakCon = true
        while i < llst.[0].Length && breakCon do
            let appendThis = [firstColumn newList] // take the new first column
            newList <- dropFirstColumn newList // the rest of the list after the first column is taken
            transList <- List.append transList appendThis // append the resulting list to transList
            i <- i + 1 // count one
        transList
    else
        [[]] // return the transposed list



// White box test isTable

//  Unit        Branch  Condition                               Input type                      Exp. output     Comment

//  isTable     1       receives input type: (llst:'a list list)
//              1a      True                                    [[]]                            false           If the input is an empty list isTable returns false                            
//              1b      False                                   [[1;2]]                                         -> Branch 2   
//              2       Input is a list of a list/lists
//              2a      i < llst.Length && true                 [[1;2;3];[4;5;6]]                               -> Branch 3b
//              2b      i > llst.Length && true                 [[1;2;3];[4;5;6]]               true                                                                            
//              2c      i < llst.Length && false                [[1;2;3];[4;5;6;7]]             false
//              3       i < llst.Length && true
//              3a      true                                    [[1;2;3];[4;5;6;7]]                             notBreakCon <- false, runs 2c 
//              3b      false                                   [[1;2;3];[4;5;6]]                               i <- i + 1                                                      

printfn " "
printfn "White box test isTable:"
printfn " "
printfn "%5b: Branch 1a test: returns false when table is empty" (isTable [[]] = false)
printfn "%5b: Branch 2b test: returns true when table consists of lists of equal length " (isTable [[1;2;3];[4;5;6]] = true)
printfn "%5b: Branch 2c test: returns false when table consists of lists of unequal length" (isTable [[1;2;3];[4;5;6;7]] = false)


// White box test firstColumn

//  Unit        Branch  Condition                               Input                          Exp. output     Comment

//  firstColumn 1       receives input type: (llst:'a list list)    
//              1a      true                                    [[];[]]/[[];[4]]               []               Returns int list []
//              1b      false                                                                                   -> Branch 2
//              2       Input is a list of a list/lists
//              2a      i < llst.Length && true                 [[1;2];[]]/[[1;2];[3;4]]                        -> Branch 3                                                                                                                                                                 
//              2b      i > llst.Length && true                 [[1;2];[3;4]]                                   -> Branch 4a                                                                                                      
//              2c      i < llst.Length && false                [[1;2];[]]                                      -> Branch 4b
//              3       i < llst.Length && true
//              3a      true                                    [[1;2];[]]                                      notBreakCon <- false, runs 2c
//              3b      false                                   [[1;2];[3;4]]                                   Appends first elements of sublists to endList and i <- i + 1, runs 2a or 2b depending on value of i
//              4
//              4a      True                                    [[1;2];[3;4]]                   [[1;3]]         Returns endList with the first elements of the inner lists                 
//              4b      false                                   [[1;2];[]]                      []              Returns intList                                

printfn " "
printfn "White box test firstColumn:"
printfn " "
printfn "%5b: Branch 1a test: returns [] when first list is empty" (firstColumn [[];[4]] = [])
printfn "%5b: Branch 4a test: returns [1;3]/first elements of inner lists when table [[1;2];[3;4]]" (firstColumn [[1;2];[3;4]] = [1;3])
printfn "%5b: Branch 4b test: returns [] when any subsequent list is empty" (firstColumn [[1];[]]  = [])

// White box test dropFirstColumn

//  Unit        Branch  Condition                               Input                       Exp. output     Comment

//  firstColumn 1       receives input type: (llst:'a list list)
//              1a      true                                    [[];[]]/[[];[4]]            []              Returns int list []
//              1b      false                                                                               -> Branch 2
//              2       Input is a list of a list/lists
//              2a      i < llst.Length && true                 [[1;2];[]]/[[1;2;3];[4;5;6]]                -> Branch 3                                                                                                                                                                 
//              2b      i > llst.Length && true                 [[1;2;3];[4;5;6]]                           -> Branch 4a                                                                                                      
//              2c      i < llst.Length && false                [[1;2];[]]                                  -> Branch 4b
//              3       i < llst.Length && true
//              3a      true                                    [[1;2];[]]                                  notBreakCon <- false, runs 2c
//              3b      false                                   [[1;2;3];[4;5;6]]                           Appends all except first elements of sublists to endList and i <- i + 1, runs 2a or 2b depending on value of i
//              4
//              4a      True                                    [[1;2;3];[4;5;6]]           [[2;3];[5;6]]   Returns endList with all but the first elements of the inner lists                 
//              4b      false                                   [[1;2];[]]                  []              Returns intList                                

printfn " "
printfn "White box test dropFirstColumn:"
printfn " "
printfn "%5b: Branch 1a test: returns [] when first list is empty" (dropFirstColumn [[];[4]] = [])
printfn "%5b: Branch 4a test: returns [[2;3];[5;6]]/all but the first elements of inner lists when table [[1;2;3];[4;5;6]]" (dropFirstColumn [[1;2;3];[4;5;6]] = [[2;3];[5;6]])
printfn "%5b: Branch 4b test: returns [] when any subsequent list is empty" (dropFirstColumn [[1];[]]  = [])


// White box test transposeLstLst

//  Unit        Branch  Condition                               Input                       Exp. output         Comment

//  transposeLstLst
//              1       receives input type (llst:'a list list)
//              1a      true                                    [[1;2;3];[4;5;6]]                               -> Branch 2    
//              1b      false                                   [[];[]]                     [[]]                Returns an empty list                    
//              2       Input is a list of a list/lists
//              2a      i < llst.[0].Length && true             [[1;2;3];[4;5;6]]                               Runs the while loop until -> Branch 2b                                                                                                                                                                 
//              2b      i > llst.[0].Length && true             [[1;2;3];[4;5;6]]           [[1;4];[2;5];[3;6]] Returns the transposed list                                                                                                                                              

printfn " "
printfn "White box test transposeLstLst:"
printfn " "
printfn "%5b: Branch 1b test: returns [[]] when list is empty" (transposeLstLst [[];[]] = [[]])
printfn "%5b: Branch 2b test: returns the transposed list" (transposeLstLst [[1;2;3];[4;5;6]] = [[1;4];[2;5];[3;6]])
printfn " "
