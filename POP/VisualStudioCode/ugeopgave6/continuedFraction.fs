module ContinuedFraction
///<summary> Recalling the module ident from the signature file </summary>

///<summary> Takes a continued fraction and finds the decimal number for it</summary>
/// <param name = "lst"> The list that the functions is used on </param>
/// <returns> The decimal number of the continued fraction as a float </returns>
let rec cfrac2float (lst : int list) : float =
        match lst with // matching lst with the following statements
        | [] -> 0.0
        | [a] -> float(a)
        | a :: _ ->  float(a) + (1.0 / cfrac2float(lst.Tail))

///<summary> Takes a decimal number and finds the continued fraction for it</summary>
/// <param name = "x"> The deicmal number that the functions is used on </param>
/// <returns> The continued fraction of the decimal number as an integer list </returns>
let rec float2cfrac (x : float) : (int list) =
    let q = (floor(x+0.001)) // Defining the variable q. Adding 0.001 to x because of the way floats are defined - For example will floor(4) give 3, because 4 is defined as 3.9999999999...
    let r = x - q // Defining the variable r
    if r < 0.001 then // checks if r is less than 0.001 instead of if r is equal to 0.0 due to the way floats are defined
        [int(q)] 
    else
        int(q)::(float2cfrac (1.0/r))
