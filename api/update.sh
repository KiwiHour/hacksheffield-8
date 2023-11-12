#!/bin/sh

value=$(cat ../../openai.txt)

res="public class GetKey{public static string getKey(){return \"$value\";}}"

echo $res

echo $res >> /home/helloworld/hacksheffield-8-main/api/Models/GetKey.cs
echo $value > /home/helloworld/hacksheffield-8-main/api/openai.txt

cd /home/helloworld/hacksheffield-8-main
killall dotnet
git fetch --all
git reset --hard origin/main
curl localhost:2019/load -H "Content-Type: application/json" -d @caddy_config.json
chmod a+rwx /home/helloworld/hacksheffield-8-main/api/data.db
cd api
dotnet publish --configuration Release HackSheffield.csproj 
dotnet /home/helloworld/hacksheffield-8-main/api/bin/Release/net7.0/HackSheffield.dll &

cd ..
cd frontend
sudo npm install
sudo npm run build