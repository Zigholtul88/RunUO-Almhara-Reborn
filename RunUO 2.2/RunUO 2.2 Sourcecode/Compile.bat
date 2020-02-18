SET PATH=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727
csc.exe /out:.\RunUO.exe /recurse:*.cs /win32icon:runuo.ico /optimize /unsafe /reference:Ultima.dll
PAUSE