// a)
/// <summary> Create a table of integers on row and columns. The top row and left column is multiplied and written in their intersection. </summary>
/// <remarks> String slicing expression is not exactly obvious. It might be relevant to change it appropriately. The function has a hardcoded string, which is sliced into smaller strings </remarks>
let mulTable (n : int) : string =
    let str = "        1     2     3     4     5     6     7     8     9    10\n  1     1     2     3     4     5     6     7     8     9    10\n  2     2     4     6     8    10    12    14    16    18    20\n  3     3     6     9    12    15    18    21    24    27    30\n  4     4     8    12    16    20    24    28    32    36    40\n  5     5    10    15    20    25    30    35    40    45    50\n  6     6    12    18    24    30    36    42    48    54    60\n  7     7    14    21    28    35    42    49    56    63    70\n  8     8    16    24    32    40    48    56    64    72    80\n  9     9    18    27    36    45    54    63    72    81    90\n 10    10    20    30    40    50    60    70    80    90   100"
    str.[..((n+1)*65-(3+n))] // Slice string at the right places. This took time to figure out because the two functions weren't the same.
printfn "This is the mulTable function for n = 1\n%s\n" (mulTable 1)
printfn "This is the mulTable function for n = 2\n%s\n" (mulTable 2)
printfn "This is the mulTable function for n = 3\n%s\n" (mulTable 3)
printfn "This is the mulTable function for n = 10\n%s\n" (mulTable 10)





// b)
/// <summary> Create a multiplication table as above, but use 2 nested for-loops and the sprintf-function </summary>
let loopMulTable (n : int) : string =
    let mutable s = "   "
    if n <= 0 || n > 10 then // We only deal with 0<n<=10
        s <- s
    else
        for i in 1..(n+1) do
            for j in 1..10 do // The nested for-loops are used to insert integers into the string s
                if i > 1 then
                    let str = sprintf "%6i" (j*(i-1)) // remember the padding in front of the values, so the table looks nice
                    s <- s + str
                else
                    let str = sprintf "%6i" j
                    s <- s + str
            if i < (n+1) then
                let str = sprintf "\n%3i" i // newlines are inserted
                s <- s + str
    s
printfn "This is the loopMulTable function for n = 1\n%s\n" (loopMulTable 1)
printfn "This is the loopMulTable function for n = 2\n%s\n" (loopMulTable 2)
printfn "This is the loopMulTable function for n = 3\n%s\n" (loopMulTable 3)
printfn "This is the loopMulTable function for n = 10\n%s\n" (loopMulTable 10)



// c)
/// <summary> The goal is to check if the two functions return the same strings. We then print a table of two columns and display True og False
let isEqual (n : int) : string =
    if n > 10 then // we only deal with same n as in the functions
        "Too big n, try 10 or below"
    else
        let mutable equalityString = ""
        for i in 1..n do
            if i < n then
                let str = sprintf "%2i%8b\n" (i) (mulTable i = loopMulTable i) // append what we need to the string.
                equalityString <- equalityString + str
            else
                let str = sprintf "%2i%8b" (i) (mulTable i = loopMulTable i) // newline is not added to the string in the last row, hence the if else statements
                equalityString <- equalityString + str
        equalityString

printfn "This is the program that compares the two functions\n%s\n" (isEqual 10)




// d)
/// <summary> Check the differece between %A and %s in printf function. </summary>
printfn "This is the string printet with %%A\n %A\n This is the string printet with %%s\n%s" (mulTable 5) (mulTable 5)
// We see that the difference between %A and %s is that %A prints the quotationmark, while the %s doesn't.