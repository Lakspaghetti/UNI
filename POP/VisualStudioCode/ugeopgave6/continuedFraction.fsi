/// It is recommended to read the XML-tags in the .fs file, since there is no <\param> to be seen in the .fsi file, therefor it is more fitting to have the <\param> tag in the .fs file 
/// A continued fraction library
/// Fractions are represented as integer list that can be converted to at float
module ContinuedFraction
///<summary> An integer list converted to a float</summary>
///<returns> A float as the real number of the contiued fraction represented as an integer list</returns>
val cfrac2float : (int list) -> (float)

///<summary> A float converted to an integer list</summary>
///<returns> An integer list as the contiued fraction of the real number represented as a float</returns>
val float2cfrac : (float) -> (int list)

