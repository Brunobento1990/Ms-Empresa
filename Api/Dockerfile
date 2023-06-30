#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Primeiro, copie apenas os arquivos .csproj para um diretório temporário
COPY ["Api/Api.csproj", "tmp/Api/"]
COPY ["Application/Application.csproj", "tmp/Application/"]
COPY ["Domain/Domain.csproj", "tmp/Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "tmp/Infrastructure/"]

# Em seguida, restaure as dependências
WORKDIR /src/tmp/Api
RUN dotnet restore

# Copie todos os arquivos do projeto para o diretório atual
WORKDIR /src
COPY . .

# Compile o projeto
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
