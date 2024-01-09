FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["lab1/Lab1Tests/Lab1Tests.csproj", "lab1/Lab1Tests/"]
RUN dotnet restore "lab1/Lab1Tests/Lab1Tests.csproj"
COPY . .
WORKDIR "/src/lab1/Lab1Tests"
RUN dotnet build "Lab1Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab1Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab1Tests.dll"]
