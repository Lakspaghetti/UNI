Unzip the .zip file.
In your terminal, navigate to the /src folder.
In the /src folder you will find 3 files. the 2 .fs files are identical, except for some characters used
in the visualization of the game(if roguelike.fs gives you "?", then try again with the roguelikeLetters.fs file).
Run the following commands:

$ fsharpc -a roguelike.fs

$ fsharpc -r rogulike.dll roguelike-game.fsx

$ mono roguelike-game.exe

These commands will compile the game and run it as well.