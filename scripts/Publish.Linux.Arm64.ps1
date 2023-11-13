dotnet publish "./src/Phoenix.Api.Client/Phoenix.Api.Client.csproj" -o "./dist/arm/phoenix.api.client" -c Release -r linux-arm64
dotnet publish "./src/Phoenix.Api.Web/Phoenix.Api.Web.csproj" -o "./dist/arm/phoenix.api.web" -c Release -r linux-arm64
dotnet publish "./src/Phoenix.Client/Phoenix.Client.csproj" -o "./dist/arm/phoenix.client" -c Release -r linux-arm64

Set-Location "./src/Phoenix.Web"
yarn install
yarn build
Set-Location "../../"
