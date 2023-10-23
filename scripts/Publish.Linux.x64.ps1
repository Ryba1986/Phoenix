dotnet publish "./src/Phoenix.Api.Client/Phoenix.Api.Client.csproj" -o "./dist/linux/Phoenix.Api.Client" -c Release -r linux-x64
dotnet publish "./src/Phoenix.Api.Web/Phoenix.Api.Web.csproj" -o "./dist/linux/Phoenix.Api.Web" -c Release -r linux-x64
dotnet publish "./src/Phoenix.Client/Phoenix.Client.csproj" -o "./dist/linux/Phoenix.Client" -c Release -r linux-x64

Set-Location "./src/Phoenix.Web"
yarn install
yarn build
Set-Location "../../"
