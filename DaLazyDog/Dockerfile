#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
RUN cd /src
COPY ["DaLazyDog/DaLazyDog.csproj", "DaLazyDog/"]
COPY ["Lazydog.Model/Lazydog.Model.csproj", "Lazydog.Model/"]
COPY ["Lazydog.mysql/Lazydog.mysql.csproj", "Lazydog.mysql/"]
RUN dotnet restore "/src/DaLazyDog/DaLazyDog.csproj"
COPY . .
WORKDIR "/src/DaLazyDog"
RUN dotnet build "/src/DaLazyDog/DaLazyDog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/DaLazyDog/DaLazyDog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaLazyDog.dll"]