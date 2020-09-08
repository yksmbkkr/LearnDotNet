FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FirstDotNetProject/FirstDotNetProject.csproj", "FirstDotNetProject/"]
RUN dotnet restore "FirstDotNetProject/FirstDotNetProject.csproj"
COPY . .
WORKDIR "/src/FirstDotNetProject"
RUN dotnet build "FirstDotNetProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FirstDotNetProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstDotNetProject.dll"]
