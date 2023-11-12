#!/bin/sh

value=$(cat ../../openai.txt)

res="public class GetKey{public static string getKey(){return \"$value\";}}"

# echo "hello" > qwe.txt
echo $res


cd /home/helloworld/hacksheffield-8-main
killall dotnet
git fetch --all
git reset --hard origin/main

rm -rf Models/GetKey.cs
rm -rf openai.txt
echo $res > Models/GetKey.cs
echo $value > openai.txt


curl localhost:2019/load -H "Content-Type: application/json" -d @caddy_config.json
chmod a+rwx /home/helloworld/hacksheffield-8-main/api/data.db
cd api
dotnet publish --configuration Release HackSheffield.csproj 
dotnet /home/helloworld/hacksheffield-8-main/api/bin/Release/net7.0/HackSheffield.dll &


rm -rf Models/GetKey.cs
rm -rf openai.txt
echo $res > Models/GetKey.cs
echo $value > openai.txt



cd ..
cd frontend
sudo npm install
sudo npm run build