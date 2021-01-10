#r "ContinuedFraction"
/// Black-box test of the library continuedFraction

/// unit : "cfrac2float"
/// Case:                           Input:                  Expected output:
/// The case in the assignment      lst = [3;4;12;4]        3.245
/// big values                      lst = [60;45;53;73]     60.022
/// for an empty list               lst = []                0.0
/// negative list                   lst = [-3;-4;-12;-4]     -3.245
/// mixed list                      lst = [-3;4;-12;4]      -2.745
/// list of only 1 element          lst = [3]               3

/// The results that are used to check if the function finds the correct answer is found using the online calculator: http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/cfCALC.html - Keep in mind that in these calculations there has been rounded to 3 decimals

printfn "\nBlack-box test of cfrac2float:\n"
printfn "%4b : Input=[3;4;12;4] : Output= %A" (round ((ContinuedFraction.cfrac2float [3;4;12;4])*1000.0)/1000.0 = 3.245) (round ((ContinuedFraction.cfrac2float [3;4;12;4])*1000.0)/1000.0)
printfn "%4b : Input=[60;45;53;73] : Output= %A" (round ((ContinuedFraction.cfrac2float [60;45;53;73])*1000.0)/1000.0 = 60.022) (round ((ContinuedFraction.cfrac2float [60;45;53;73])*1000.0)/1000.0)
printfn "%4b : Input=[] : Output= %A" (ContinuedFraction.cfrac2float [] = 0.0) (ContinuedFraction.cfrac2float [])
printfn "%4b : Input=[-3;-4;-12;-4] : Output= %A" (round ((ContinuedFraction.cfrac2float [-3;-4;-12;-4])*1000.0)/1000.0 = -3.245) (round ((ContinuedFraction.cfrac2float [-3;-4;-12;-4])*1000.0)/1000.0)
printfn "%4b : Input=[-3;4;-12;4] : Output= %A" (round ((ContinuedFraction.cfrac2float [-3;4;-12;4])*1000.0)/1000.0 = -2.745) (round ((ContinuedFraction.cfrac2float [-3;4;-12;4])*1000.0)/1000.0)
printfn "%4b : Input=[3] : Output= %A" (round ((ContinuedFraction.cfrac2float [3])*1000.0)/1000.0 = 3.0) (round ((ContinuedFraction.cfrac2float [3])*1000.0)/1000.0)
/// The function "round" is used to ensure that fsharp only checks for 3 decimals. This is necessary due to the way floats are expressed in fsharp. I.e. if the function round is not used, then it wouldn't return the bool "true" because there would be too many "hidden" decimals that wouldn't match up.
/// The function is set to round to 3 decimals, because it's relativly close enough to the actual value and because it will round the third decimal to what it is supposed to be I.e. The number 4.0 is actually written as 3.99999... Meaning that if you were to calculate a float, there would be missing decimals that would end up in an "incorrect" or inprecise result, but rounding the number will get the desired or "precise" result

/// unit : "float2cfrac"
/// Case:                           Input:                  Expected output:
/// The case in the assignment      x = 3.245               [3;4;12;4]
/// big values                      x = 60.022              [60;45;2;5]
/// for zero and a flat decimal     x = 0.0                 [0]
/// negative decimal                x = -3.245              [-4;1;3;12;4]
/// a result from the other test    x = -2.745              [-3;3;1;11;1;3]

/// The results that are used to check if the function finds the correct answer is found using the online calculator: http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/cfCALC.html

printfn "\nBlack-box test of float2cfrac:\n"
printfn "%4b : Input=3.245: Expected Output=[3;4;12;4]: Output= %A" (ContinuedFraction.float2cfrac 3.245 = [3;4;12;4]) (ContinuedFraction.float2cfrac 3.245)
printfn "%4b : Input=60.022: Expected Output=[60;45;2;5]: Output= %A" (ContinuedFraction.float2cfrac 60.022 = [60;45;2;5]) (ContinuedFraction.float2cfrac 60.022)
printfn "%4b : Input=0.0: Expected Output=[0]: Output= %A" (ContinuedFraction.float2cfrac 0.0 = [0]) (ContinuedFraction.float2cfrac 0.0)
printfn "%4b : Input=-3.245: Expected Output=[-4; 1; 3; 12; 4]: Output= %A" (ContinuedFraction.float2cfrac -3.245 = [-4;1;3;12;4]) (ContinuedFraction.float2cfrac -3.245)
printfn "%4b : Input=-2.745: Expected Output=[-3; 3; 1; 11; 1; 3]: Output= %A" (ContinuedFraction.float2cfrac -2.745 = [-3;3;1;11;1;3]) (ContinuedFraction.float2cfrac -2.745)
/// The last two results are found by hand. If the reader can spare the effort of calculating the last two results by hand, thy should get the same result as the function
/// It is noticable that the results are not matching the inputs in the test of cfrac2float due to the fact that the results of cfrac2float is rounded and is therefor missing some decimals in order to recreate the same contiued fraction with float2cfrac

printfn "\nExample of the result if all the decimals of the cfrac2float function is used in the float2cfrac function "
printfn "%4b : Input=60.0222129110393 : Output= %A" (ContinuedFraction.float2cfrac 60.0222129110393 = [60;45;53;73]) (ContinuedFraction.float2cfrac 60.0222129110393)
printfn "\nExample of what cfrac2float gets from the value [-3;3;1;11;1;3]"
printfn "%A" (ContinuedFraction.cfrac2float[-3;3;1;11;1;3])


/// White-box test of the library continuedFraction

///  Unit        Branch     Condition       Input type      Exp. output     Comment
///  cfrac2float 1          lst = []                
///              1a         true            []              0.0             0.0 is used as a value for a graceful failure, since the function works with floats and therefor can not use a print statement to tell the user that the list is empty
///              1b         false                                           -> branch 2
///              2          lst = [a]                                       [a] means that the list only contains 1 element                           
///              2a         true            [5]             5.0             The last element should just be returned as a float - in case branch 3 is used before this, then it should return the last element [a] as a float in the mathematical expression
///              2b         false                                           -> branch 3
///              3          lst = a :: _                                    a :: _ is the element a constructed with a wildcard
///              3a         true            [3;4;12;4]      3,245           In this case a could be 3, while the wild card contains [4;12;4]
///              3b         false                                           If this statement has been true in an earlier call it should go to branch 2 before returning the final result

printfn "\nWhite box test cfrac2float:\n"
printfn "%4b: Branch 1a test: returns true when the list is empty and the function is set to be equal to 0.0" (ContinuedFraction.cfrac2float [] = 0.0)
printfn "%4b: Branch 2a test: returns true when the list consist of 1 element - In this case is [5] and is set to be equal to 5.0" (ContinuedFraction.cfrac2float [5] = 5.0)
printfn "%4b: Branch 3a test: returns true when the list consist of more than 1 element - In this case the elements are [3;4;12;4] and is set to be equal to 3.245" (ContinuedFraction.cfrac2float [3;4;12;4] = 3.245)

///  Unit        Branch   Condition         Input type       Exp. output     Comment
///  float2cfrac 1        r < 0.001
///              1a       true              4.0              [4]             A flat decimal will result in r being equal to 0.0 < 0.001
///              1b       false                                              -> branch 2(The else statement of the if-else statement)
///              2        r !< 0.001
///              2a       true              5.3              []              Any decimal that is not flat should result in this condition being true
///              2b       false                                              If this statement has been true in an earlier call it should go to branch 2 before returning the final result


printfn "\nWhite box test float2cfrac:\n"
printfn "%4b: Branch 1a test: returns true when the decimal is flat - In this case the decimal is 4.0 and is set to be equal to [4]" (ContinuedFraction.float2cfrac 4.0 = [4])
printfn "%4b: Branch 2a test: returns true when the decimal is not flat - In this case the decimal is 5.3 and is set to be equal to [5; 3; 3]" (ContinuedFraction.float2cfrac 5.3 = [5;3;3])

printfn "\n %A" (ContinuedFraction.cfrac2float [3;4;12;4])
printfn "%A" (ContinuedFraction.float2cfrac (1.1234567))