FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab2.Tests/Lab2.Tests.csproj", "Lab2.Tests/"]
RUN dotnet restore "Lab2.Tests/Lab2.Tests.csproj"
COPY . .
WORKDIR "/src/Lab2.Tests"
RUN dotnet build "Lab2.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab2.Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab2.Tests.dll"]
