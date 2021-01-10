Run the code by using fsharpc -a vec2dsmall.fsi and vec2dsmall.fs
Then fsharpc -r vec2dsmall.dll 4i1.fsx 
Then mono 4i1.exe

The results of the black-box test shows that there is no flaws to be
seen in the code for now. The only thing there is to notice, is the 
function "round" which is used to be able to check if two floats are
equal to eachother. I.e. to check if the print statement will print 
the bool "true" or the bool "false". I have chosen to use 3 decimals 
after the comma. 
The blackbox covers both negative, positive, neutral and big values

4i3)
4i3.fsx is run by fsharpc -r vec2dsmall.dll 4i3.fsx 
then mono 4i3.exe
Any line with "lb.n", means the n'th line in the library
Any calculation is done with an external calculator. There will only be
checked for 3 decimals again.
In the last step, the line will be called TERM which is used to show what
the terminal is expected to print.
step  |  Line  |  Env. | Bindings and evaluations
0     |  -     |  E_0  | ()
1     |  1     |  E_0  | v=((1.3, -2.5),    ,())
2     |  2     |  E_0  | Output = Vector (1.3, -2.5): (?, ?)
3     |  lb.4  |  E_1  | v=(1.3, -2.5), sqrt (fst v ** 2 + snd v ** 2), ()
4     |  lb.4  |  E_1  | Return 2.817
6     |  lb.10 |  E_1  | v=(1.3, -2.5), atan2 (snd v) (fst v), ()
7     |  lb.10 |  E_1  | Return -1.091
8     |  2     |  E_0  | Output = Vector (1.3, -2.5): (2.817, -1.091)
9     |  3     |  E_0  | w=((-0.1, -0.5),    ,())
10    |  4     |  E_0  | Output = Vector (-0.1, -0.5): (?, ?)
11    |  lb.4  |  E_2  | w=(-0.1, -0.5), sqrt (fst v ** 2 + snd v ** 2) ,()
12    |  lb.4  |  E_2  | Return 0.509
13    |  lb.10 |  E_2  | w=(-0.1, -0.5), atan2 (snd v) (fst v), ()
14    |  lb.10 |  E_2  | Return -1.768
16    |  4     |  E_0  | Output = Vector (-0.1, -0.5): (0.509, -1.768)
17    |  5     |  E_0  | s=((?)),    , ())
18    |  lb.15 |  E_3  | v=(1.3, -2.5) & w=(-0.1, -0.5), ((fst v + fst w), (snd v + snd w)), ()
19    |  lb.15 |  E_3  | Return (1.2, -3.0)
20    |  5     |  E_0  | s=((1.2, -3.0),     , ())
21    |  6     |  E_0  | Output = Vector (1.2, 3.0): (?, ?)
22    |  lb.4  |  E_4  | s=(1.2, 3.0), sqrt (fst v ** 2 + snd v ** 2), (vec2d.add = s)
23    |  lb.4  |  E_4  | Return 3.231    
24    |  lb.10 |  E_4  | s=(1.2, 3.0),  atan2 (snd v) (fst v), (vec2d.add = s)
25    |  lb.10 |  E_4  | Return 1.190
26    |  6     |  E_0  | Output = Vector (1.2, 3.0): (3.231, 1.190)
27    | TERM   |  E_NIL| Output = \n Vector (1.3, -2.5): (2.817, -1.091) \n Vector (-0.1, -0.5): (0.509, -1.768) \n Vector (1.2, 3.0): (3.231, 1.190)

Tracing by hand resulted in the same as it did to run the code with fsharpc.
There was no errors to be seen by doing tracing by hand.
