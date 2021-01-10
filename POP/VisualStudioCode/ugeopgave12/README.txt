To run the code direct your terminal to the folder containing the 3 files chess.fs, pieces.fs and chessApp.fsx

then type "fsharpc chess.fs pieces.fs chessApp.fsx"

this would create a few new files and one of them should be called "chessApp.exe"

now type "mono chessApp.exe" and it will print a board with 6 pieces in total to be played on. 

to see that the code works follow these inputs:

d1 d2

h8 h2

this should align the white king with a black rook

d2 e2

d2 c2 

this should print some messages telling that these are not valid moves

g1 g2

b8 b3

this should move a white rook in front of the black rook threatining the white king and move a black rook a bit down

d2 e2

d8 d7

e2 f2

d7 d6

f2 g2 will show that a king can't kill an allied piece

f2 e2

d6 d5

e2 d2

d5 d4

a1 a8

d4 d3 will show that a king can't move near another king

b3 g3

a8 a1

g3 g2 will show rooks can kill other rooks

d2 c2

d2 e2 to again show that the king can't towards or away from enemy rooks

a1 a8

g2 e2

d2 e2 to show that the king can't kill a protected rook

a8 d8

h2 h3

d2 e2 to show that a king can kill a rook

h3 h1

d8 d3 to show that a rook can't jump

d8 d4 to show that a rook can kill a king