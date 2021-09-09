let IllegalMovesK (p:chessPiece) (vacantList:Position list) : Position list =
      let mutable illMoves : Position list = []
      for i in vacantList do
        //
        let sndConvertNWrap = // kan dette bruges til at checke for kongen candiatemoves?
          (relativeToAbsolute i) >> getVacantNOccupied
        //
        let instertedPVacant = List.map sndConvertNWrap p.candiateRelativeMoves
        //
        let unknownDangerousPs = List.choose snd instertedPVacant
        //
        let rooksVacantPieceLists = List.map sndConvertNWrap candiateRMRook
        //
        let unknownDangerousR = List.choose snd rooksVacantPieceLists
        //
        if p.color = White then
          for m in unknownDangerousR do
            if m.nameOfType = "rook" && m.color = Black then
              illMoves <- illMoves @ [i]
            else
              ()

          for k in unknownDangerousPs do
            if k.nameOfType = "king" && k.color = Black then
              illMoves <- illMoves @ [i]
            elif k.nameOfType = "rook" && k.color = Black then
              let unknownPiecePos = Option.get(k.position) 
              if (fst unknownPiecePos + 1, snd unknownPiecePos) = i || (fst unknownPiecePos, snd unknownPiecePos + 1) = i || (fst unknownPiecePos - 1, snd unknownPiecePos) = i || (fst unknownPiecePos, snd unknownPiecePos - 1) = i then
                illMoves <- illMoves @ [i]
              else
                ()
            else
              ()
              
        else
          for n in unknownDangerousR do
            if n.nameOfType = "rook" && n.color = White then
              illMoves <- illMoves @ [i]
            else
              ()

          for l in unknownDangerousPs do
            if l.nameOfType = "king" && l.color = White then
              illMoves <- illMoves @ [i]
            elif l.nameOfType = "rook" && l.color = White then
              let unknownPiecePos = Option.get(l.position) 
              if (fst unknownPiecePos + 1, snd unknownPiecePos) = i || (fst unknownPiecePos, snd unknownPiecePos + 1) = i || (fst unknownPiecePos - 1, snd unknownPiecePos) = i || (fst unknownPiecePos, snd unknownPiecePos - 1) = i then
                illMoves <- illMoves @ [i]
              else
                ()
            else
              ()
      illMoves





  override this.NextMove (s:string, playingBoard: board) : string =
    if s = "quit" then
      "quit"
    elif s.Length = 4 then 
      "This is not a valid input. Valid inputs are 'quit' or a move like 'a1 a2' respectively to the size of the board and the position of your pieces" 
    else
      //if a part of the input was outside of the board
      if (s.[0] |> int) < 97 || (s.[0] |> int) > 104 then
        "The first letter was not a valid input. Valid letters are a,b,c,d,e,f,g & h"
      elif (s.[3] |> int) < 97 || (s.[3] |> int) > 104 then
        "The second letter was not a valid input. Valid letters are a,b,c,d,e,f,g & h"
      elif (s.[1] |> int) < 49 || (s.[1] |> int) > 56 then
        "The first number was not a valid input. Valid numbers are 1,2,3,4,5,6,7 & 8"
      elif(s.[4] |> int) < 49 || (s.[4] |> int) > 56  then
        "The first number was not a valid input. Valid numbers are 1,2,3,4,5,6,7 & 8"
      else
        let pos1 = ((s.[1] |> int) - 49, (s.[0] |> int) - 97)
        let pos2 = ((s.[4] |> int) - 49, (s.[3] |> int) - 97)
        let allAvailableMoves : Position list = []
        if playingBoard.[(fst pos1),(snd pos1)].IsSome then
          let currentPiece = (Option.get (playingBoard.[(fst pos1),(snd pos1)]))
          if currentPiece.color <> playerColor then //(Option.get (playingBoard.[(fst pos1),(snd pos1)]))
            "This piece belongs to the opponent"
          else
            let mutable result = " "
            allAvailableMoves <- allAvailableMoves @ (fst (playingBoard.availableMoves currentPiece))
            if List.contains pos2 allAvailableMoves then
              result <- s
            else
              result <- "Invalid move"
            System.Console.Clear()
            result
        else
          "This is an empty field"
  


          let mutable neighboursPos = []
          for i in (snd (this.availableMoves piece)) do  
            neighboursPos <- neighboursPos @ [(Option.get i.position)]
          let vacantNNeighbours = vacant @ neighboursPos


          if piece.nameOfType = "king" then // checks if the inserted piece is a king
          let mutable kingsLVacant : Position list = [] // a new list to return instead of vacant
          for p in vacant do
            // updating kingsLVacant to contain moves from vacant that can't be found in IllegalMovesK
            if List.contains p (IllegalMovesK piece vacant) then
              ()
            else
              kingsLVacant <- kingsLVacant @ [p]
          for take in neighbours do
            // Adds the opponents pieces to kingsLVacant if the king is allowed to kill them
            // The king can't kill another king nor kill a protected rook
            if List.contains (Option.get (take.position)) (IllegalMovesK piece vacant) then
              ()
            else
              if piece.color = take.color then  
                ()
              else
                kingsLVacant <- kingsLVacant @ [(Option.get (take.position))]
          (kingsLVacant, neighbours)
        else
          (vacant, neighbours) //If the piece is a rook this can simply be returned

          for i in neighbours do
            if i.color = piece.color then
              ()
            else 
              tempVac <- tempVac @ [Option.get i.position] // Updating the list to contain the correct neighbour pieces
          tempVac
        //

        let mutable tempVac = List.collect fst vacantPieceLists // The old definition of vacant
          List.map (fun (x:chessPiece) -> if x.color = piece.color then () else tempVac <- tempVac @ [Option.get x.position]) neighbours
          tempVac


          let getPosition (pp:chessPiece) = Option.get(pp.position) 
          let mutable kingsLVacant : Position list = [] // a new list to return instead of vacant
          kingsLVacant <- kingsLVacant @ (List.except (Seq.ofList (IllegalMovesK piece vacant)) (vacant))//if elm isn't in illegal, then add
          let neighPos = List.map (fun (x:chessPiece) -> getPosition x) neighbours //neighbours as positions
          kingsLVacant <- kingsLVacant @ (List.except (Seq.ofList (IllegalMovesK piece vacant)) (neighPos))
          (kingsLVacant, neighbours)

if piece.nameOfType = "king" then // checks if the inserted piece is a king
          let mutable kingsLVacant : Position list = [] // a new list to return instead of vacant
          for p in vacant do
            // updating kingsLVacant to contain moves from vacant that can't be found in IllegalMovesK
            if List.contains p (this.IllegalMovesK piece vacant) then
              ()
            else
              kingsLVacant <- kingsLVacant @ [p]
          for take in neighbours do
            // Adds the opponents pieces to kingsLVacant if the king is allowed to kill them
            // The king can't kill another king nor kill a protected rook
            if List.contains (Option.get (take.position)) (this.IllegalMovesK piece vacant) then
              ()
            else
              if piece.color = take.color then  
                ()
              else
                kingsLVacant <- kingsLVacant @ [(Option.get (take.position))]
          (kingsLVacant, neighbours)
        else
          (vacant, neighbours) //If the piece is a rook this can simply be returned

/// <summary>Finds the illegal moves compared to the color of the piece</summary>
  /// <param name = "p">chesspiece used in availableMoves</param>
  /// <param name = "vacantList">position list of vacant squares</param>
  /// <returns>A list of illegal moves compared to the color of the piece</returns>
  member this.IllegalMovesK (p:chessPiece) (vacantList:Position list) : Position list =
      let mutable illMoves : Position list = []
      for i in vacantList do
        if p.color = White then
          illMoves <- illMoves @ this.helper p Black i      
        else
          illMoves <- illMoves @ this.helper p White i
      illMoves


      let neighPos = List.map (fun (x:chessPiece) -> getPosition x) neighbours