open ImgUtil

type point = int * int       // a point (x,y) in the plane
type Color = color

let red = fromRgb (255, 0, 0)
let blue = fromRgb (0, 0, 255)

type figure =
  | Circle of point * int * Color
  // defined by center, radius, and color
  | Rectangle of point * point * Color
  // defined by corners top -left, bottom -right, and color
  | Mix of figure * figure
  // combine figures with mixed color at overlap

///<summary>This creates a figure called "figTest" which is used in the other files.</summary>
///<remark>This is not a function and it does not draw or do anything, it simply defines the figure.</remark>
///<returns>figTest returns a figure as a Mix of the two other figues Circle and Rectangle.</returns>
let figTest:figure = Mix(Circle((50,50), 45, red),Rectangle((40,40),(90,110), blue))
printfn "\n8i0.exe\nfigTest looks as following: %A\n" figTest








