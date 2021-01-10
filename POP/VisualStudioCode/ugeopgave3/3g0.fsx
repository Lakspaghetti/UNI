// a)
/// <summary> Find the sum of all positive integers up to and including n </summary>
/// <remarks> Uses a counter in a loop, not a general expression. All inputs and outputs are integers </remarks>
/// <example>
///   The following code:
///   <code>
///       let n = 5
///       printfn "%A" (sum n)
///   </code>
///   prints 16
/// </example>
/// <param name="n">Upper limit to the sum.</param>
/// <returns>The sum of all positive integers up to and including n </returns>
let sum (n : int) : int =
    let mutable s = 0
    let mutable counter = 0
    if n < 1 then // We only deal with n >= 1
        s
    else
        while counter < n do // Loops through every integer and adds them together in s
            counter <- counter + 1
            s <- s + counter
        s // Returns s




// b)
/// <summary> Find the sum of all positive integers up to and including n </summary>
/// <remarks> Uses a general expression </remarks>
/// <example>
///   The following code:
///   <code>
///       let n = 5
///       printfn "%A" (simpleSum n)
///   </code>
///   prints 16
/// </example>
/// <param name="n">Upper limit to the sum.</param>
/// <returns>The sum of all positive integers up to and including n </returns>
let simpleSum (n : int) : int =
    if n < 0 then // We only use positive n
        0
    else
        (n/2)*(n+1) // This is the general expression. We divide by 2 before multiplying, since we only have 32 bits to use




// c)
/// <summary> Make the two previous functions interactive, by having the user input n in the terminal </summary>
/// <returns> The same as the two functions above </returns>
printfn "Welcome to the integer sum program. This program sums all integer numbers up to a limit of your choice."
printf "Enter the upper limit of the sum: " // Print two strings, introducing the user to the program.
let n = int (System.Console.ReadLine())
let sum1 = sum n in let sum2 = simpleSum n in do
printfn "The sum using counter summation is: %A
The sum using the derived expression is: %A" sum1 sum2 //print the results




// d)
printfn "n sum simpleSum"
for i in 1..10 do
    printfn "%d %d %d" i (sum i) (simpleSum i) // Prints the sums for each integer up to and including n, in a table like structure




// e)
// The largest value of n is 65535, anything above will compute the wrong value.
// We could modify the functions by setting the input and output type to int64,
// so we have more bytes to work with. int is 32 bit integers.