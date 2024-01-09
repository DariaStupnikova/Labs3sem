FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab3.Tests/Lab3.Tests.csproj", "Lab3.Tests/"]
RUN dotnet restore "Lab3.Tests/Lab3.Tests.csproj"
COPY . .
WORKDIR "/src/Lab3.Tests"
RUN dotnet build "Lab3.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab3.Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab3.Tests.dll"]
