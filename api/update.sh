#!/bin/sh

cd /home/helloworld/hacksheffield-8-main
killall dotnet
git fetch --all
git reset --hard origin/main
curl localhost:2019/load -H "Content-Type: application/json" -d @caddy_config.json
chmod a+rwx /home/helloworld/hacksheffield-8-main/api/data.db
cd api
dotnet publish --configuration Release HackSheffield.csproj 
dotnet /home/helloworld/api/hacksheffield-8-main/bin/Release/net7.0/HackSheffield.dll &

cd ..
cd frontent
npm run build