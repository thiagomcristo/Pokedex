#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Pokedex.PokedexApi/Pokedex.PokedexApi.csproj", "Pokedex.PokedexApi/"]
RUN dotnet restore "Pokedex.PokedexApi/Pokedex.PokedexApi.csproj"
COPY . .
WORKDIR "/src/Pokedex.PokedexApi"
RUN dotnet build "Pokedex.PokedexApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokedex.PokedexApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pokedex.PokedexApi.dll"]