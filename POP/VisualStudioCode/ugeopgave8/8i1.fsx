open ImgUtil

type Point = int * int       // a point (x,y) in the plane
type Color = color

type Figure =
  | Circle of Point * int * Color
  // defined by center, radius, and color
  | Rectangle of Point * Point * Color
  // defined by corners top -left, bottom -right, and color
  | Mix of Figure * Figure
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

///<summary>The function makePicture creates a .png file using the 4 different parameters it demands.</summary>
///<param name ="filnavn">This is the name that the .png file will be called.</param>
///<remarks>So the result will be "filnavn.png".</remarks> 
///<param name ="figur">This is the figure that will be drawn in the .png file.</param>
///<param name ="b">This is the width of the canvas.</param>
///<param name ="h">This is the height of the canvas.</param>
///<returns>makePicture returns filnavn.png as a .png file that contains the drawn figure in a canvas. It also prints out the name of the .png file.</returns>
let makePicture filnavn figur b h =
  let C = mk b h
  for i=0 to b do
    for j=0 to h do
      let c = match colorAt (i,j) figur with
                    | None -> (fromRgb(128,128,128))
                    | Some c -> c
      in setPixel c (i,j) C
  let pngFile = filnavn + ".png"    
  do toPngFile pngFile C
  do printfn "Created the png: %s" pngFile

printfn "\n8i1.exe\nThis file does nothing, but the code in this file is used in 8i2.exe\n"