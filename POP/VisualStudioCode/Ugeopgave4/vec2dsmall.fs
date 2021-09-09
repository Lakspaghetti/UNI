module vec2d
/// Recalling the module ident from the signature file

let len (v : float * float)  : float =
    (sqrt (fst v ** 2. + snd v ** 2.))
/// Defining the function len    
/// <param name = "v"> is a vector defined as a tuple </param>
/// <returns> A float as the length of the vector </returns>

let ang (v : float * float) : float =
    (atan2 (snd v) (fst v))
/// Defining the function ang
/// <returns> A float as the angle of the vector </returns>   

let add (v : float * float) (w : float * float) : (float * float) =
    ((fst v + fst w), (snd v + snd w))
/// Defining the function add
/// <param name = "w"> is a different vector from vector v </param>
/// /// <returns> A tuple as a new vector </returns>

