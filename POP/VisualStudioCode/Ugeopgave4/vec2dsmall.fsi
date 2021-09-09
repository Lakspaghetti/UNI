/// A 2 dimensional vector library
/// Vectors are represented as pairs of floats
module vec2d
/// <summary> The length of a vector </summary>
val len : (float * float) -> float
/// <param name = "v"> a vector represented as a tuple where the "fst" of the tuple is x and "snd" is y</param>
/// <summary> The type definition of the function len, which calculates the length of the vector  </summary>
/// <returns> A float as the length of the vector with the two given variables x and y </returns>

/// <summary> The angle of a vector </summary>
val ang : (float * float) -> float
/// <summary> The type definition of the function ang, which calculates the angle of the vector </summary>
/// <returns> A float as the angle/the direction of the vector with two given variables x and y </returns>

/// <summary> Addition of two vectors </summary>
val add : (float * float) -> (float * float) -> (float * float)
/// <summary> The type definition of the function add, which takes two vectors and calculates the sum of those two </summary>
/// <returns> A tuple of two floats as the new vector created by the sum of two previous vectors </returns>
 
 