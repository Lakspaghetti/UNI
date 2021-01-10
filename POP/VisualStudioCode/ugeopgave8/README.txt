First type in the following command:
"fsharpc --nologo -I /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0 -r gdk-sharp.dll -r gtk-sharp.dll -a img_util.fsi img_util.fs"
This will create the library img_util.dll

Now type in the following: 
"fsharpc -r img_util.dll 8i0.fsx && fsharpc -r img_util.dll 8i1.fsx && fsharpc -r img_util.dll 8i2.fsx && fsharpc -r img_util.dll 8i3.fsx && fsharpc -r img_util.dll 8i4.fsx && fsharpc -r img_util.dll 8i5.fsx"
This will create 6 files: 8i0.exe, 8i1.exe, 8i2.exe, 8i3.exe, 8i4.exe and 8i5.exe

Now to run the files type in the following:
"mono 8i0.exe && mono 8i1.exe && mono 8i2.exe && mono 8i3.exe && mono 8i4.exe && mono 8i5.exe"

You can also run each file.exe separately by typing:
"mono file.exe"