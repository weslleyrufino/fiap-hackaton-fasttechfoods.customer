# FastTechFoods.Customer.Worker/Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FastTechFoods.Customer.Worker/FastTechFoods.Customer.Worker.csproj", "FastTechFoods.Customer.Worker/"]
RUN dotnet restore "FastTechFoods.Customer.Worker/FastTechFoods.Customer.Worker.csproj"

COPY . .
WORKDIR "/src/FastTechFoods.Customer.Worker"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FastTechFoods.Customer.Worker.dll"]
