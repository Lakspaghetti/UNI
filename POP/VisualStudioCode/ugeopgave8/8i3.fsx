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
  
///<summary>The function checkFigure checks if a figure is correct. For a circle then the radius has to be positive and for a rectangle the top-left corner has to be above and to the left of the bottom right cornor.</summary>
///<param name ="f">f is the figure inserted into the function</param>
///<returns>The function either returns true or false depending on the figure. If the figure is correct it returns true, but if the figure is wrong it returns false.</returns>
let rec checkFigure (f:figure) : bool =
    match f with 
        | Circle ((_,_), r, _) -> if r<=0 then false else true
        | Rectangle ((x1,y1), (x2,y2), _) -> if x1<=x2 && y1<=y2 then true else false
        | Mix(f1, f2) -> checkFigure(f1) && checkFigure(f2)

///<remark>figTest, fstCircle, sndCircle, fstRectangle and sndRectangle is the figures used in the printfn statement to shows that the function checkFigure works.</remarks>
let figTest:figure = Mix(Circle((50,50), 45, red),Rectangle((40,40),(90,110), blue))
let fstCircle:figure = Circle((50,50), 40, red)
let sndCircle:figure = Circle((50,50), -40, red)
let fstRectangle:figure = Rectangle((40,40),(90,110), blue)
let sndRectangle:figure = Rectangle((90,110),(40,40), blue)

printfn "\n8i3.exe\n Mix returns \"%A\" and looks like \"Mix(Circle((50,50), 45, red), Rectangle((40,40),(90,110), blue))\"
\n Circle returns \"%A\" and looks like \"Circle((50,50), 40, red)\"
\n Circle2 returns \"%A\" and looks like \"Circle((50,50), -40, red)\"
\n Rectangle returns \"%A\" and looks like \"Rectangle((40,40),(90,110), blue)\"
\n Rectangle2 returns \"%A\" and looks like \"Rectangle((90,110),(40,40), blue)\"" (checkFigure figTest) (checkFigure fstCircle) (checkFigure sndCircle) (checkFigure fstRectangle) (checkFigure sndRectangle)
