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

// finds color of figure at point
let rec colorAt (x,y) figure =
  match figure with
    | Circle ((cx,cy),r,col) ->
      if (x-cx)*(x-cx) + (y-cy)*(y-cy) <= r*r
      // uses Pythagoras' equation to determine
      // distance to center
      then Some col else None
    | Rectangle ((x0,y0),(x1,y1),col) ->
      if x0 <= x && x <= x1 && y0 <= y && y <= y1
      // within corners
      then Some col else None
    | Mix (f1,f2) ->
          match (colorAt (x,y) f1, colorAt (x,y) f2) with
            | (None, c) -> c // no overlap
            | (c, None) -> c // no overlap
            | (Some c1, Some c2) ->
              let (a1, r1, g1, b1) = fromColor c1
              let (a2 ,r2, g2, b2) = fromColor c2
              in Some (fromArgb ((a1+a2)/2 , (r1+r2)/2,  // calculate
                                         (g1+g2)/2 , (b1+b2)/2)) // average color

///<remark>This function has already been documented in the file "8i1.fsx".</remark>
let makePicture filnavn figur b h =
  let C = mk b h
  for x=0 to b do
    for y=0 to h do
      let c = match colorAt (x,y) figur with
                    | None -> (fromRgb(128,128,128))
                    | Some c -> c
      in setPixel c (x,y) C
  let pngFile = filnavn + ".png"    
  do toPngFile pngFile C
  do printfn "Created the png: %s\n" pngFile

///<summary>The function move moves a figure in the direction of a given vector</summary>
///<param name ="f">f is the figure inserted into the function.</param>
///<param name ="(x,y)">Is the vector's values</param>
///<returns>The function move returns the same figure as there were inserted into the function but moved along with the vector.</returns>
let rec move (f:figure) ((x,y):Point) : figure =
    match f with 
        | Circle ((cx,cy), r, c) -> Circle ((cx+x, cy+y), r, c)
        | Rectangle ((x1,y1), (x2,y2), c) -> Rectangle ((x1+x, y1+y), (x2+x, y2+y), c)
        | Mix(f1, f2) -> Mix(move f1 (x,y), move f2 (x,y))


///<remark>This figure has already been documented in the file "8i0.fsx" </remark>
let figTest:figure = Mix(Circle((50,50), 45, red), Rectangle((40,40),(90,110), blue))
printfn "\n8i4.exe"
do makePicture "moveTest" (move figTest (-20,20)) 100 150

