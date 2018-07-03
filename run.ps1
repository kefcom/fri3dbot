Write-Output "Starting .NET core API in its own window"
Start-Process -FilePath "./Server/publish/Server.exe"
Write-Output ".NET core API running... see own window for IP and debugging log"

Write-Output "Starting the Unity bot"
Start-Process -FilePath "./Bot/buildresults.exe"
Write-Output "Bot started"

Write-Output "Starting angular webapp"
npm install http-server -g
http-server "./App"
