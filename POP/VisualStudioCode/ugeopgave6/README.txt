The code is run by using fsharpc -a continuedFraction.fsi continuedFraction.fs
Then use fsharpc -r continuedFraction.dll continuedFractionTest.fsx
Then use mono continuedFractionTest.exe

The black-box and white-box tests is implemented in the .fsx file

The code works and finds the desired result as conclusion to the black-box and white-box tests.
The only thing worth of notice is the round function, which is necessary to use when comparing floats to eachother.