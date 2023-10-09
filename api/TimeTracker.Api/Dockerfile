#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TimeTracker.Api/TimeTracker.Api.csproj", "TimeTracker.Api/"]
RUN dotnet restore "TimeTracker.Api/TimeTracker.Api.csproj"
COPY . .
WORKDIR "/src/TimeTracker.Api"
RUN dotnet build "TimeTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTracker.Api.dll"]

#docker build -f TimeTracker.Api/Dockerfile -t TimeTracker.Api . 