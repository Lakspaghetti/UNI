/// Black-box test of the library vec2d
#r vec2dsmall.dll
/// unit : "len"
/// case : vector as a dot              input : v=(0.0,0.0)         Expected output : 0.0
/// case : negative x-value             input : v=(-1.0,0.0)        Expected output : 1.0
/// case : negative y-value             input : v=(0.0,-1.0)        Expected output : 1.0
/// case : negative x- and y-value      input : v=(-4.0,-3.0)       Expected output : 5.0
/// case : positive x-value             input : v=(1.0,0.0)         Expected output : 1.0
/// case : positive y-value             input : v=(0.0,1.0)         Expected output : 1.0
/// case : positive x- and y-value      input : v=(4.0,3.0)         Expected output : 5.0
/// case : negative x and positive y    input : v=(-4.0,3.0)        Expected output : 5.0
/// case : big x- and y-value           input : v=(10.0,15.0)       Expected output : 18.028

printfn "\nBlack-box testing of vec2d.len"
printfn "%5b : v=(0.0, 0.0)" (vec2d.len(0.0, 0.0) = 0.0)
printfn "%5b : v=(-1.0, 0.0)" (vec2d.len(-1.0, 0.0) = 1.0)
printfn "%5b : v=(0.0, -1.0)" (vec2d.len(0.0, -1.0) = 1.0)
printfn "%5b : v=(-1.0, -1.0)" (vec2d.len(-4.0, -3.0) = 5.0)
printfn "%5b : v=(1.0, 0.0)" (vec2d.len(1.0, 0.0) = 1.0)
printfn "%5b : v=(0.0, 1.0)" (vec2d.len(0.0, 1.0) = 1.0)
printfn "%5b : v=(4.0, 3.0)" (vec2d.len(4.0, 3.0) = 5.0)
printfn "%5b : v=(-4.0, 3.0)" (vec2d.len(-4.0, 3.0) = 5.0)
printfn "%5b : v=(10.0, 15.0)\n" ((round (vec2d.len(10.0, 15.0)*1000.0)/1000.0) = 18.028)
/// The function "round" is used to ensure that fsharp only checks for 3 decimals. This is necessary due to the way floats are expressed in fsharp. I.e. if the function round is not used, then it wouldn't return the bool "true" because there would be to many "hidden" decimals that wouldn't match up.

/// unit : "ang"
/// case : vector with angle 0          input : v=(0.0,0.0)         Expected output : 0.0
/// case : negative x-value             input : v=(-1.0,0.0)        Expected output : 3.142
/// case : negative y-value             input : v=(0.0,-1.0)        Expected output : -1.571
/// case : negative x- and y-value      input : v=(-4.0,-3.0)       Expected output : -2.498
/// case : positive x-value             input : v=(1.0,0.0)         Expected output : 0.0
/// case : positive y-value             input : v=(0.0,1.0)         Expected output : 1.571
/// case : positive x- and y-value      input : v=(1.0,1.0)         Expected output : 0.644
/// case : negative x and positive y    input : v=(-4.0,3.0)        Expected output : 
/// case : big x- and y-value           input : v=(10.0,15.0)       Expected output : 0.983

printfn "\nBlack-box testing of vec2d.ang"
printfn "%5b : v=(0.0, 0.0)" (vec2d.ang(0.0, 0.0) = 0.0 )
printfn "%5b : v=(-1.0, 0.0)" ((round (vec2d.ang(-1.0, 0.0)*1000.0)/1000.0) = 3.142)
printfn "%5b : v=(0.0, -1.0)" ((round (vec2d.ang(0.0, -1.0)*1000.0)/1000.0) = -1.571)
printfn "%5b : v=(-4.0, -3.0)" ((round (vec2d.ang(-4.0, -3.0)*1000.0)/1000.0) = -2.498)
printfn "%5b : v=(1.0, 0.0)" (vec2d.ang(1.0, 0.0) = 0.0 )
printfn "%5b : v=(0.0, 1.0)" ((round (vec2d.ang(0.0, 1.0)*1000.0)/1000.0) = 1.571)
printfn "%5b : v=(4.0, 3.0)" ((round (vec2d.ang(4.0, 3.0)*1000.0)/1000.0) = 0.644)
printfn "%5b : v=(4.0, 3.0)" ((round (vec2d.ang(-4.0, 3.0)*1000.0)/1000.0) = 2.498)
printfn "%5b : v=(10.0, 15.0)\n" ((round (vec2d.ang(10.0, 15.0)*1000.0)/1000.0) = 0.983) 
/// The function round is used again here, due to the fact that it wouldn't be possible to get true otherwise.
/// The results that are used to check if the expression works has been found using an external calculator.

/// unit : "add"
/// case : two vectors as dots          input : v=(0.0,0.0) & w=(0.0,0.0)        Expected output : (0.0, 0.0)
/// case : negative values for v        input : v=(-1.0,-1.0) & w=(0.0,0.0)      Expected output : (-1.0, -1.0)
/// case : negative values for w        input : v=(0.0,0.0) & w=(-1.0,-1.0)      Expected output : (-1.0, -1.0)
/// case : negative values for both     input : v=(-5.0,-5.0) & w=(-5.0,-5.0)    Expected output : (-10.0, -10.0)
/// case : positive values for v        input : v=(1.0,1.0) & w=(0.0,0.0)        Expected output : (1.0, 1.0)
/// case : positive values for w        input : v=(0.0,0.0) & w=(1.0,1.0)        Expected output : (1.0, 1.0)
/// case : positive values for both     input : v=(5.0,5.0) & w=(5.0,5.0)        Expected output : (10.0, 10.0)
/// case : negative v and positive w    input : v=(5.0,5.0) & w=(5.0,5.0)        Expected output : (0.0, 0.0)
/// case : big values for both          input : v=(10.0,15.0) & w=(15.0,10.0)    Expected output : (25.0, 25.0)

printfn "\nBlack-box testing of vec2d.add"
printfn "%5b : v=(0.0, 0.0) & w=(0.0,0.0)" (vec2d.add(0.0, 0.0) (0.0, 0.0) = (0.0, 0.0) )
printfn "%5b : v=(-1.0, -1.0) & w=(0.0,0.0)"  (vec2d.add(-1.0, -1.0) (0.0, 0.0) = (-1.0, -1.0) )
printfn "%5b : v=(0.0, 0.0) & w=(-1.0,-1.0)" (vec2d.add(0.0, 0.0) (-1.0, -1.0) = (-1.0, -1.0) )
printfn "%5b : v=(-5.0,-5.0) & w=(-5.0,-5.0)" (vec2d.add(-5.0, -5.0) (-5.0, -5.0) = (-10.0, -10.0) )
printfn "%5b : v=(1.0,1.0) & w=(0.0,0.0)" (vec2d.add(1.0, 1.0) (0.0, 0.0) = (1.0, 1.0) )
printfn "%5b : v=(0.0,0.0) & w=(1.0,1.0)" (vec2d.add(0.0, 0.0) (1.0, 1.0) = (1.0, 1.0) )
printfn "%5b : =(5.0,5.0) & w=(5.0,5.0)" (vec2d.add(5.0, 5.0) (5.0, 5.0) = (10.0, 10.0) )
printfn "%5b : =(-5.0,-5.0) & w=(5.0,5.0)" (vec2d.add(-5.0, -5.0) (5.0, 5.0) = (0.0, 0.0) )
printfn "%5b : v=(10.0,15.0) & w=(15.0,10.0)\n" (vec2d.add(10.0, 15.0) (15.0, 10.0) = (25.0, 25.0) ) 


