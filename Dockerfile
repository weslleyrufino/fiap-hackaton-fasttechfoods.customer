# Etapa 1 - build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas os arquivos de projeto para restaurar as dependências
COPY ["FastTechFoods.Customer.API/FastTechFoods.Customer.API.csproj", "FastTechFoods.Customer.API/"]
RUN dotnet restore "FastTechFoods.Customer.API/FastTechFoods.Customer.API.csproj"

# Copia o restante do código-fonte
COPY . .

# Publica o projeto
WORKDIR "/src/FastTechFoods.Customer.API"
RUN dotnet publish -c Release -o /app/publish

# Etapa 2 - runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FastTechFoods.Customer.API.dll"]
