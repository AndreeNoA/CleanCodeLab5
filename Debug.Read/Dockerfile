#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Debug.Read/Debug.Read.csproj", "Debug.Read/"]
COPY ["ClassLibrary1/Database.csproj", "ClassLibrary1/"]
RUN dotnet restore "Debug.Read/Debug.Read.csproj"
COPY . .
WORKDIR "/src/Debug.Read"
RUN dotnet build "Debug.Read.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Debug.Read.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Debug.Read.dll"]
