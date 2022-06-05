#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DaLazyDog/DaLazyDog.csproj", "DaLazyDog/"]
COPY ["Lazydog.Model/Lazydog.Model.csproj", "Lazydog.Model/"]
COPY ["Lazydog.mysql/Lazydog.mysql.csproj", "Lazydog.mysql/"]
RUN dotnet restore "DaLazyDog/DaLazyDog.csproj"
COPY . .
WORKDIR "/src/DaLazyDog"
RUN dotnet build "DaLazyDog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaLazyDog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaLazyDog.dll"]