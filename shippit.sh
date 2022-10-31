dotnet publish ./src/IMHOS/IMHOS.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/IMHOS/IMHOS.vbproj -o ./pub-windows -c Release --sc -r win-x64
butler push pub-windows thegrumpygamedev/interstellar-murder-hobos-of-splorr:windows
butler push pub-linux thegrumpygamedev/interstellar-murder-hobos-of-splorr:linux
git add -A
git commit -m "shipped it!"