# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copie os arquivos de projeto e restaurar as dependências
COPY . .
RUN dotnet restore

# Compile a solução
RUN dotnet build -c Release --no-restore

# Publicar os projetos da solução
RUN dotnet publish -c Release --no-build --output /app

# Estágio de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copie os arquivos publicados do estágio de compilação
COPY --from=build /app .

# Defina a entrada do contêiner
ENTRYPOINT ["dotnet", "Api/Api.dll"]
