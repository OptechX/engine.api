#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api.engine-v2.csproj", "."]
RUN dotnet restore "./api.engine-v2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api.engine-v2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.engine-v2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.engine-v2.dll"]
