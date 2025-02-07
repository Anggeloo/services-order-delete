# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /serviceorderdelete

EXPOSE 83
EXPOSE 5003

COPY ./*.csproj ./
RUN dotnet restore 

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 
WORKDIR /serviceorderdelete
COPY --from=build /serviceorderdelete/out .
ENTRYPOINT ["dotnet", "services-order-delete.dll"]
