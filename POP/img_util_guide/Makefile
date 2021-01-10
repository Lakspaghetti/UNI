FSC=fsharpc --nologo
#macOS:
INCL=-I /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0
#Linux:
#INCL=-I /usr/lib/cli/gtk-sharp-2.0 -I /usr/lib/cli/gdk-sharp-2.0 -I /usr/lib/cli/glib-sharp-2.0 -I /usr/lib/cli/gtk-dotnet-2.0 -I /usr/lib/cli/atk-sharp-2.0
GTKDLLS= -r gdk-sharp.dll -r gtk-sharp.dll

.PHONY: all
all: img_util.dll w7.exe w8.exe 7g.exe

.PHONY: examples
examples:
	$(MAKE) -C examples all

.PHONY: clean
clean:
	rm -rf *~ *.exe *.png *.dll
	$(MAKE) -C img-util-fs clean

img_util.dll: img-util-fs/img_util.fsi img-util-fs/img_util.fs
	$(FSC) $(INCL) $(GTKDLLS) -a $^

%.exe: img_util.dll %.fsx
	$(FSC) $(INCL) $(GTKDLLS) -r $^
