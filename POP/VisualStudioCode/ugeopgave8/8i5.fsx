open ImgUtil

type Point = int * int       // a point (x,y) in the plane
type Color = color

type figure =
  | Circle of Point * int * Color
  // defined by center, radius, and color
  | Rectangle of Point * Point * Color
  // defined by corners top -left, bottom -right, and color
  | Mix of figure * figure
  // combine figures with mixed color at overlap

///<summary>The function boundingBox finds the top-left cornor and bottom-right cornor of a minimal sized axed rectangle that contains the whole figure inserted into the function.</summary>
///<param name ="f">f is the figure inserted into the function.</param>
///<returns>The function boundingBox returns a tuble of tubles. I.e it returns a tuble of two points, the first point being the top-left cornor and the second point being the bottom right cornor.</returns>
let rec boundingBox (f:figure) : (Point * Point) =
    match f with
        | Circle ((cx,yx), r, _) -> ((cx-r,yx-r),(cx+r,yx+r)) 
        | Rectangle ((x1,y1), (x2,y2), _) -> ((x1,y1), (x2,y2))
        | Mix(f1,f2) -> match boundingBox f1, boundingBox f2 with
                        | ((f1x1,f1y1),(f1x2,f1y2)), ((f2x1,f2y1),(f2x2,f2y2)) -> ((min f1x1 f2x1, min f1y1 f2y1), (max f1x2 f2x2, max f1y2 f2y2))

///<remark>This figure has already been documented in the file "8i0.fsx" </remark>
let figTest:figure = Mix(Circle((50,50), 45, red), Rectangle((40,40),(90,110), blue))

printfn "\n8i5.exe\nwhen boundingBox is used on figTest it returns: %A\n" (boundingBox figTest)