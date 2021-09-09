open Chess
open Pieces

/// Print various information about a piece
let printPiece (board : board) (p : chessPiece) : unit =
  printfn "%A: %A %A" p p.position (board.availableMoves p)

let testPiece = king (White) :> chessPiece

// Create a game
let board = board () // Create a board
// Pieces are kept in an array for easy testing
let pieces = [|
  rook (Black) :> chessPiece;
  rook (White) :> chessPiece; 
  king (Black) :> chessPiece;
  king (White) :> chessPiece; 
  rook (White) :> chessPiece;
  rook (Black) :> chessPiece |]
// Place pieces on the board
board.[7,1] <- Some pieces.[0]
board.[0,0] <- Some pieces.[1]
board.[7,3] <- Some pieces.[2]
board.[0,3] <- Some pieces.[3]
board.[0,6] <- Some pieces.[4]
board.[7,7] <- Some pieces.[5]
printfn "%A" board
//printfn "%A" (board.availableMoves(Option.get board.[2,7]))
// two players
let pOne = Human(White)
let pTwo = Human(Black)
//creating and starting a game
let testGame = Game(pOne, pTwo, board)
//System.Console.Clear()
testGame.Run ()
