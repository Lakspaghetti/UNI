
Koden i readNWrite.fs, cat.fsx og tac.fsx oversættes og køres med fsharp c og mono som følger:
- fsharpc -a readNwrite.fs som giver filen readNwrite.dll
- fsharpc -r readNwrite.dll cat.fsx / tac.fsx som giver filen cat.exe / tac.exe
- mono cat.exe / tac.exe + commandolinje-argumenter som printer printstatements af cat.exe / tac.exe

Koden i countLinks.fsx køres med fsharpi

Eksempel på kørsel af cat.exe
cat.fsx med det tilhørende bibliotek køres ved at køre mono cat.exe med en række argumenter f.eks.:
cat.exe "cat.fsx" "tac.fsx"
Her printes hele tekstindholdet af cat.fsx efterfulgt af hele tekstindholdet af tac.fsx. 

Eksempel på kørsel af tac.exe
tac.fsx med det tilhørende bibliotek køres ved at køre mono tac.exe med en række argumenter f.eks.:
tac.exe "cat.fsx" "tac.fsx"
Her printes hvor rækkefølgen af filer er omvendt, rækkefølgen af linjer er omvendt
og rækkefølgen af alle karakterer på hver linje er omvendt. Det ser således ud:

1 >- _ |
htiw
1 >- enoN |
0 ;x "s%" nftnirp >- x emoS |
htiw ))tsiLot.yarrA >| sgra( tac( hctam
yrt
= tni :)yarra gnirts :sgra( niam tel
]>tnioPyrtnE<[
 ///
>skramer/< gninnur nehw>skramer<///
>snruter/<esiwrehto 0 rorre fo esac ni 1>snruter<///
 >marap/<stnemugra enil-dnammoc sa semanelif fo yarra na>"sgra" = eman marap<///
>yrammus/<esiwrehto 0 rorre fo esac ni 1 snruter dna stnemugra enil-dnammoc sa semanelif fo yarra na sekat>yrammus<///

etirWNdaeR nepo

1 >- _ |
htiw
1 >- enoN |
0 ;x "s%" nftnirp >- x emoS |
htiw ))tsiLot.yarrA >| sgra( cat( hctam
yrt
= tni :)yarra gnirts :sgra( niam tel
]>tnioPyrtnE<[
 ///
>snruter/<esiwrehto 0 rorre fo esac ni 1>snruter<///
 >marap/<stnemugra enil-dnammoc sa semanelif fo tsil a>"sgra" = eman marap<///
>yrammus/<esiwrehto 0 rorre fo esac ni 1 snruter dna stnemugra enil-dnammoc sa semanelif fo yarra na sekat>yrammus<///

etirWNdaeR nepo


Eksempel på kørsel af countLinks.fsx
I fsharpi skrives countLinks.fsx ;; Herefter returnes 30 som svar på hvor mange links der er på google.dk's hovedside
Vil man teste en anden hjemmeside skal det ændres i fsx-filen.


