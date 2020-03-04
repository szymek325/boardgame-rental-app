Master
[![Build Status](https://szymek325.visualstudio.com/My%20First%20Project/_apis/build/status/szymek325.boardgame-rental-app?branchName=master)](https://szymek325.visualstudio.com/My%20First%20Project/_build/latest?definitionId=1&branchName=master)

Develop
[![Build Status](https://szymek325.visualstudio.com/My%20First%20Project/_apis/build/status/szymek325.boardgame-rental-app?branchName=develop)](https://szymek325.visualstudio.com/My%20First%20Project/_build/latest?definitionId=1&branchName=develop)

# Playingo rental app
Application built for management of BoardGames, Clients and Rentals in boardgame shop.

## Technologies
* .NET Core 3
* MediatR
* SqLite

## Create migration and update db
dotnet tool install --global dotnet-ef --version 3.1.1
dotnet ef migrations add InitDb --project ./src/Playingo.Infrastructure/Playingo.Infrastructure.csproj --output-dir ./Persistence/Migrations --startup-project ./src/Playingo.WebApi/Playingo.WebApi.csproj
dotnet ef database update --project ./src/Playingo.Infrastructure/Playingo.Infrastructure.csproj --startup-project ./src/Playingo.WebApi/Playingo.WebApi.csproj

