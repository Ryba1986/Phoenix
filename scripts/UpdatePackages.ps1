dotnet outdated -u -t -pre Always

Set-Location "./src/Phoenix.Web"
ncu -u
yarn install
Set-Location "../../"
