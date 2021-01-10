module Chess
/// The possible colors of chess pieces
type Color = White | Black

/// A superset of positions on a board
type Position = int * int

/// <summary> An abstract chess piece. </summary>
/// <param name = "col"> The color black or white </param>
[<AbstractClass>]
type chessPiece(color : Color) =
  let mutable _position : Position option = None

  /// The type of the chess piece as a string, e.g., "king" or "rook".
  abstract member nameOfType : string

  /// The color either White or Black
  member this.color = color

  /// The position as a Position option, e.g., None, Some (0,0), Some
  /// (3,4).
  member this.position
    with get() = _position
    and set(pos) = _position <- pos

  /// Return the first letter of the piece's type usint capital case
  /// for white pieces and lower case for black pieces. E.g., "K" and
  /// "k" for white and a black king respectively.
  override this.ToString () =
    match color with
      | White -> (string this.nameOfType.[0]).ToUpper ()
      | Black -> (string this.nameOfType.[0]).ToLower ()

  /// A maximum list of relative runs, a piece may make regardless of
  /// its position and the other pieces on the board. For example, a
  /// rook can move up, down, left, and right, so its list must
  /// contain 4 runs, and the "up" run must contain 7 positions
  /// [(-1,0); (-2,0)]...[-7,0]]. Runs must be ordered such that the
  /// first in a list is closest to the piece at hand.
  abstract member candiateRelativeMoves : Position list list

/// A chess board.
type board () =
  let _board = Collections.Array2D.create<chessPiece option> 8 8 None

  /// <summary> Wrap a position as option type. </summary>
  /// <param name = "pos"> a position </param>
  /// <returns> Some pos or None if the position is on the board or not </returns>
  let validPositionWrap (pos : Position) : Position option =
    let (rank, file) = pos // square coordinate
    if rank < 0 || rank > 7 || file < 0 || file > 7 
    then None
    else Some (rank, file)

  /// <summary> Converts relative coordinates to absolute and removes
  /// out of board coordinates. </summary>
  /// <param name = "pos"> an absolute position </param>
  /// <param name = "lst"> a list of relative positions </param>
  /// <returns> A list of absolute and valid positions </returns>
  let relativeToAbsolute (pos : Position) (lst : Position list) : Position list =
    let addPair (a : Position) (b : Position) : Position = 
      (fst a + fst b, snd a + snd b)
    // Add origin and delta positions
    List.map (addPair pos) lst
    // Choose absolute positions that are on the board
    |> List.choose validPositionWrap

  /// <summary> Find the tuple of empty squares and first neighbour if any. </summary>
  /// <param name = "run"> A run of absolute positions </param>
  /// <returns> A pair of a list of empty neighbouring positions and
  /// a possible neighbouring piece, which blocks the run. </returns>
  let getVacantNOccupied (run : Position list) : (Position list * (chessPiece option)) =
    try
      // Find index of first non-vacant square of a run
      let idx = List.findIndex (fun (i, j) -> _board.[i,j].IsSome) run
      let (i,j) = run.[idx]
      let piece = _board.[i, j] // The first non-vacant neighbour
      if idx = 0
      then ([], piece)
      else (run.[..(idx-1)], piece)
    with
      _ -> (run, None) // outside the board

  /// <summary>Used to check illegal moves for the king. 
  /// The relative moves for a rook has been fixed to fit the function that checks illegal moves.</summary>
  /// <returns>The relative moves for a rook but without the first move in each direction.</returns>
  let candiateRMRook = 
      let mutable list = [
        fun elm -> (elm,0); // South by elm
        fun elm -> (-elm,0); // North by elm
        fun elm -> (0,elm); // West by elm
        fun elm -> (0,-elm) // East by elm
        ]
      List.map(fun e -> List.map e [2..7]) list // changed the list from [1..7] to [2..7]

  /// <summary>Finds illegal moves for a king</summary>
  /// <param name = "hPiece">Chesspiece as a king</param>
  /// <param name = "col">The Opposite col of the inserted piece</param>
  /// <param name = "nPos">Position of a new square</param>
  /// <returns>A list of illegal moves</returns>
  member this.IllegalMoves (hPiece: chessPiece) (col:Color) (nPos: Position) : Position list =
      let mutable illegalList = [] // a temp list to return
      let sndConvertNWrap = 
        (relativeToAbsolute nPos) >> getVacantNOccupied
      // Vacant squares and neighbours of nPos using the king's relative moves
      let instertedPVacant = List.map sndConvertNWrap hPiece.candiateRelativeMoves 
      // neighbours of the nPos using the king's relative moves
      let unknownDangerousPs = List.choose snd instertedPVacant
      // vacant squares and neighbours of nPos using the list candiateRMRook
      let rooksVacantPieceLists = List.map sndConvertNWrap candiateRMRook
      // neighbours of the nPos using the list candiateRMRook
      let unknownDangerousR = List.choose snd rooksVacantPieceLists
      for m in unknownDangerousR do // only rooks, using candiateRMRook
          let mPos = Option.get (m.position)
          let mAbs = 
            let mutable mCandiate = [] // gets absolute moves of m(don't know how to get them via list module)
            for a in m.candiateRelativeMoves do
              mCandiate <- mCandiate @ a
            relativeToAbsolute mPos mCandiate
          // checks if the neighbour of nPos is one of the opponent's rooks and if it can move there
          if m.nameOfType = "rook" && m.color = col && List.contains nPos mAbs then 
            let mRookProtecter = // checks if nPos contains a piece and if it is protected
              List.filter (fun (x:chessPiece) -> x.color = m.color && Option.get(x.position) = nPos) (snd(this.availableMoves m))
            if List.contains nPos (fst (this.availableMoves m)) then illegalList <- illegalList @ [nPos]
            elif List.contains hPiece (snd (this.availableMoves m)) then illegalList <- illegalList @ [nPos] // moving away from a rook
            elif not (List.isEmpty mRookProtecter) then illegalList <- illegalList @ [nPos] // trying to kill an enemy rook that is protected
            else ()
          else ()
      for k in unknownDangerousPs do // rooks and kings, using the king's candiate moves
        if k.nameOfType = "king" && k.color = col then //checks if the neighbour of nPos is one of the opponent's kings
          illegalList <- illegalList @ [nPos]
        elif k.nameOfType = "rook" && k.color = col then //checks if the rooks are diagonally placed compared to nPos
          let unknownPiecePos = Option.get(k.position) 
          //only rooks that are horizontally or vertically placed compared to nPos will be added to the list
          if (fst unknownPiecePos + 1, snd unknownPiecePos) = nPos || (fst unknownPiecePos, snd unknownPiecePos + 1) = nPos || (fst unknownPiecePos - 1, snd unknownPiecePos) = nPos || (fst unknownPiecePos, snd unknownPiecePos - 1) = nPos then
            illegalList <- illegalList @ [nPos] 
          else ()
        else ()
      illegalList

  /// Board is indexed using .[,] notation
  member this.Item
    with get(a : int, b : int) = _board.[a, b]
    and set(a : int, b : int) (p : chessPiece option) =
      if p.IsSome then p.Value.position <- Some (a,b)
      _board.[a, b] <- p

  /// Produce string of board for, e.g., the printfn function.
  override this.ToString() =
    let mutable str = ""
    for i = Array2D.length1 _board - 1 downto 0 do
      str <- str + string (i + 1)
      for j = 0 to Array2D.length2 _board - 1 do
        let p =  _board.[i,j]
        let pieceStr =
            match p with
              None -> " "; 
              | Some p -> p.ToString()
        str <- str + " " + pieceStr
      str <- str + "\n"
    str + "  a b c d e f g h"

  /// <summary> Move piece from a source to a target position. Any
  /// piece on the target position is removed. </summary>
  /// <param name = "source"> The source position </param>
  /// <param name = "target"> The target position </param>
  member this.move (source : Position) (target : Position) : unit =
    // Update piece' knowledge about it's position
    Option.iter (fun (p : chessPiece) -> p.position <- None) this.[fst target, snd target]
    Option.iter (fun (p : chessPiece) -> p.position <- Some target) this.[fst source, snd source]
    // Update board's pieces
    this.[fst target, snd target] <- this.[fst source, snd source]
    this.[fst source, snd source] <- None
 
    
  /// <summary> Find the list of available empty positions for this
  /// piece, and the list of possible own and opponent pieces, which
  /// can be protected or taken. </summary>
  /// <param name = "piece"> A chess piece </param>
  /// <returns> A pair of lists of all available moves and neighbours,
  /// e.g., ([(1,0); (2,0);...], [p1; p2]) </returns>
  member this.availableMoves (piece : chessPiece) : (Position list * chessPiece list)  =
    match piece.position with
      | None -> ([],[]) 
      | Some p ->
        let convertNWrap = 
          (relativeToAbsolute p) >> getVacantNOccupied
        let vacantPieceLists = List.map convertNWrap piece.candiateRelativeMoves
        // Extract and merge lists of first obstruction pieces and filter out own pieces
        let neighbours = List.choose snd vacantPieceLists
        // Extract and merge lists of vacant squares.
        // Updated so it also contains the position of neighbour pieces that belongs to the opponent
        let vacant =
          let mutable tempVac = List.collect fst vacantPieceLists // The old definition of vacant
          for i in neighbours do
            if i.color = piece.color then ()
            else  tempVac <- tempVac @ [Option.get i.position] // Updating the list to contain the correct neighbour pieces
          tempVac
        if piece.nameOfType = "king" then // checks if the inserted piece is a king
          let mutable illMoves : Position list = []
          let mutable neighPos = [] //list of illegal moves
          for v in vacant do
            if piece.color = White then illMoves <- illMoves @ this.IllegalMoves piece Black v
            else illMoves <- illMoves @ this.IllegalMoves piece White v
          let getPosition (pp:chessPiece) = Option.get(pp.position) 
          let mutable kingsLVacant : Position list = [] // a new list to return instead of vacant
          kingsLVacant <- kingsLVacant @ (List.except (Seq.ofList (illMoves)) (vacant))
          for take in neighbours do
              if piece.color = take.color then ()
              else
                neighPos <- neighPos @ [(getPosition take)] //neighbours as positions
          kingsLVacant <- kingsLVacant @ (List.except (Seq.ofList (illMoves)) (neighPos))
          (kingsLVacant, neighbours)
        else (vacant, neighbours) //If the piece is a rook this can simply be returned

          

/// <summary>A player to play the game</summary>
[<AbstractClass>]
type Player ()=
  abstract member NextMove : string * board -> string
  abstract CurrentColor : Color with get, set

/// <summary>A human player</summary>
/// <param name = "pCol">Which side the player is, White or Black</param>
type Human (pCol: Color) =
  inherit Player()

  let mutable playerColor = pCol

  /// player can have the colors "White" or "Black"
  override this.CurrentColor 
    with get() = playerColor and set(col: Color) = playerColor <- col
      
  /// <summary>checks in the input string is a valid input compared to the current board</summary>
  /// <param name = "s">input string</param>
  /// <param name = " ">current board</param>
  /// <returns>A string telling wheter or not it was a valid input </returns>
  override this.NextMove (s:string, playingBoard: board) : string =
    if s = "quit" then "quit"
    elif s.Length = 4 then 
      "This is not a valid input. Valid inputs are 'quit' or a move like 'a1 a2' respectively to the size of the board and the position of your pieces" 
    else //if a part of the input was outside of the board
      if (s.[0] |> int) < 97 || (s.[0] |> int) > 104 then "The first letter was not a valid input. Valid letters are a,b,c,d,e,f,g & h"
      elif (s.[3] |> int) < 97 || (s.[3] |> int) > 104 then "The second letter was not a valid input. Valid letters are a,b,c,d,e,f,g & h"
      elif (s.[1] |> int) < 49 || (s.[1] |> int) > 56 then "The first number was not a valid input. Valid numbers are 1,2,3,4,5,6,7 & 8"
      elif(s.[4] |> int) < 49 || (s.[4] |> int) > 56  then "The second number was not a valid input. Valid numbers are 1,2,3,4,5,6,7 & 8"
      else
        let pos1 = ((s.[1] |> int) - 49, (s.[0] |> int) - 97)
        let pos2 = ((s.[4] |> int) - 49, (s.[3] |> int) - 97)
        // If there is a piece on the first position
        if playingBoard.[(fst pos1),(snd pos1)].IsSome then
          let currentPiece = (Option.get (playingBoard.[(fst pos1),(snd pos1)]))
          let allAvailableMoves : Position list = (fst (playingBoard.availableMoves currentPiece))
          if currentPiece.color <> playerColor then "This piece belongs to the opponent"
          else
            let mutable result = " "
            //if it was a valid move for the piece
            if List.contains pos2 allAvailableMoves then result <- s
            else
              result <- "This is not a valid Move. Rooks can move horizontal and vertically. A king can move one square in all directions. A king can't move to a square if the oppenent can take the king in their next move."
            System.Console.Clear()
            result
        else "This is an empty field"
  
/// <summary>a game between two players on a board </summary>
/// <param name = "p1">The first player</param>
/// <param name = "p2">The second player</param>
/// <param name = "gameBoard">The board the two players are to play on</param>
type Game (p1:Player, p2:Player, gameBoard: board) =
  let board = gameBoard
  let mutable turnChecker : Color = White

  /// <summary>creates a position </summary>
  /// <param name = "str">the string used to create the position </param>
  /// <returns>a position </returns>
  member this.CreatePos1 (str:string) : Position = ((str.[1] |> int) - 49, (str.[0] |> int) - 97)
  
  /// <summary>creates a position </summary>
  /// <param name = "">the string used to create the position </param>
  /// <returns>a position </returns>
  member this.CreatePos2 (str:string) : Position = ((str.[4] |> int) - 49, (str.[3] |> int) - 97)

  member this.Run () : unit =
    System.Console.Clear()
    // makes sure that both players doesn't have the same color
    if p1.CurrentColor = p2.CurrentColor && p1.CurrentColor = White then p2.CurrentColor <- Black
    elif p1.CurrentColor = p2.CurrentColor && p1.CurrentColor = Black then p1.CurrentColor <- White
    else ()
    let playerOne = if p1.CurrentColor = White then p1 else p2 
    let playerTwo = if p2.CurrentColor = Black then p2 else p1

    let rec gameRunner(p:Player) : unit = 
      if turnChecker = White then printf "%A enter your move: " turnChecker
      else printf "%A enter your move: " turnChecker
      let move = System.Console.ReadLine ()
      match move.Length with // checks the length of the moves to see if it matches the length of a valid input
        | 4 ->  if p.NextMove (move, board) = move then // breaks the recursive loop and ends the game if "quit" was inputted
                  if turnChecker = White then turnChecker <- Black
                  else turnChecker <- White
                else // something of length 4 was inputted, but it was not "quit"
                  System.Console.Clear()
                  printfn "%A tried '%s' %s\n" turnChecker move (p.NextMove (move, board))
                  printfn "%A" board
                  if turnChecker = White then gameRunner(playerOne)
                  else gameRunner(playerTwo)
        | 5 ->  if p.NextMove (move, board) = move then // if the input was a valid move, then update board, print it and update turnChecker
                  System.Console.Clear ()
                  board.move (fst (this.CreatePos1 move), snd(this.CreatePos1 move)) (fst (this.CreatePos2 move), snd(this.CreatePos2 move))
                  printfn "%A made the move: %s\n" turnChecker move
                  printfn "%A" board
                  if turnChecker = White then turnChecker <- Black; gameRunner(playerTwo)
                  else turnChecker <- White; gameRunner(playerOne)
                else // something of length 5 was inputted, but it was not a valid move
                  System.Console.Clear()
                  printfn "%A tried '%s'. %s" turnChecker move (p.NextMove (move, board))
                  printfn "%A" board
                  if turnChecker = White then gameRunner(playerOne)
                  else gameRunner(playerTwo)
        | _ ->  System.Console.Clear() // the input wasn't valid at all
                printfn "%A tried '%s'. This is not a valid input. Valid inputs are 'quit' or a move like 'a1 a2' respectively to the size of the board and the position of your pieces\n" turnChecker move
                printfn "%A" board
                if turnChecker = White then gameRunner(playerOne)
                else gameRunner(playerTwo)
    printfn "If both players had the same color, then player one's color has been set to white and player two's color black. Valid inputs are 'quit' or something like 'a1 b1' \nrespectively to the size of the board and the position of your pieces" 
    printfn "%A" board             
    gameRunner(playerOne) // starting the game
    System.Console.Clear() // when someone has typed "quit", then the board is cleared and the winner is printed
    printfn "\n%A wins" turnChecker
      
 
