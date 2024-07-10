#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore \
    "TodoList.Api.sln"

RUN dotnet build \ 
    "./TodoList.Api/TodoList.Api.csproj" \ 
    --no-restore \ 
    -c Release \ 
    -o /app/build

RUN dotnet test \
    --logger="trx" \
    --collect:"XPlat Code Coverage" \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=cobertura \
    --no-restore \
    -c Release \
    --results-directory \
    ./TestResults

FROM build AS publish
RUN dotnet publish "./TodoList.Api/TodoList.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoList.Api.dll"]