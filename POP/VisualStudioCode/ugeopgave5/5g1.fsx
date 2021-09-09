///<param name = "a"> Is the array that the function is used on </param>
///<summary> Takes an array a and transposes it </summary>
///<returns> a new array which is the transposed version of the inserted array</return>
let transposeArr (a : 'a [,]) : 'a [,] = 
    let rlen = Array2D.length1 a // defines a value rlen as the length of the rows in "a"
    let clen = Array2D.length2 a // defines a value clen as the length of the columns in "a"
    let revlen = Array2D.init clen rlen (fun i j -> a.[j,i]) // initiates a new table using the values rlen and clen and the transposed set of "a" in a fun function 
    let intArr = array2D [[];[]] // creates an empty array
    if Array2D.length1 a = 0 then // checks if the array actually contains anything
        intArr
    else
        revlen 

let blabla = Array2D.init 5 5 (fun i j -> i + 10 * j)
printfn "This is the original Array:\n %A\n"  blabla
printfn "This is the transposed Array:\n %A\n" (transposeArr blabla)

(* 
    c)
The advantage of the implementation using arrays is how easy it is to understand and write. It's a 
short and simple program compared to the one using lists. In our implementation using lists we had
to define 3 other programs before defining the one that transposes the table, which makes it harder
to understand and write i.e. it's not a simple and short program, but a relatively long and advanced
program. However this does open up for easier modefication of the program.
Lastly the program using arrays will not accept if the subarrays does not have the same length, but
the program using lists will accept if the list are not the same length
*)

(*
    d)
An array has a constant size, but can the elements are mutable, so in an imperative environment, the content of the array could 
change. This can be an advantage or disadvantage, depending on the situation. In our case, if the array had an equal amount of 
rows and columns, we could simply change i and j in A[i, j], and the array would be transposed, then return the same array, but 
with modified elements. This cannot be done in lists, because the elements are immutable. Here we have to create new lists and 
put in the elements from the input list, then return that new list. So we could simply change the state of the elements of the 
input array, as imperative programming does, but with lists, we can't. Functional programming is thus the easiest way to work 
with lists, but not necessarily with arrays. It seems like arrays are just lists with more modification possibilities and they 
would be preferable to use in most situations.
*)