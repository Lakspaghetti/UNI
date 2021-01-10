To run the white-box test: 
    - First ensure that you are directed to the right path
    - Secondly write "fsharpc -a simulate.fs" in your terminal
    - Thirdly write "fsharpc -r simulate.dll testSimulate.fsx" in your terminal
    - lastly write "mono testSimulate.exe" in your terminal

This will print the full white-box test of all the functions in both of the classes "Drone" and "Airspace".

If it is desired to see the white-box test of only 1 function at a time, then go into the file "testSimulaate.fsx", scroll down
to the bottom and comment out all of the "wbt.Wbtfunctionname" and "printfn" statements for all but the desired function. 

In case the desire is to see the white-box test of more than 1 function, then the same goes. Leave the ones in interest be and 
comment out the ones out of interest.

Through the white-box test of all the functions, then it is concluded that they work as intended, since all functions printed out 
what they was expected to print.

Wordmat & pen and paper has been used to figure out the right answer for the functions that included any type of math.