dotnet publish "./src/Phoenix.Api.Client/Phoenix.Api.Client.csproj" -o "./dist/arm/Phoenix.Api.Client" -c Release -r linux-arm64
dotnet publish "./src/Phoenix.Api.Web/Phoenix.Api.Web.csproj" -o "./dist/arm/Phoenix.Api.Web" -c Release -r linux-arm64
dotnet publish "./src/Phoenix.Client/Phoenix.Client.csproj" -o "./dist/arm/Phoenix.Client" -c Release -r linux-arm64

Set-Location "./src/Phoenix.Web"
yarn install
yarn build
Set-Location "../../"
