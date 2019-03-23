del .\IoT.Display.UWP.*.nupkg
nuget pack IoT.Display.UWP\IoT.Display.UWP.csproj -Properties Configuration=Release -Build
nuget push .\IoT.Display.UWP.*.nupkg -Source https://api.nuget.org/v3/index.json