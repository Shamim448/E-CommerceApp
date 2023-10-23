#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN apt-get update && apt-get install -y nodejs

COPY ["MasterCRUD.Web/MasterCRUD.Web.csproj", "MasterCRUD.Web/"]
RUN dotnet restore "MasterCRUD.Web/MasterCRUD.Web.csproj"
COPY . .
WORKDIR "/src/MasterCRUD.Web"
RUN dotnet build "MasterCRUD.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MasterCRUD.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MasterCRUD.Web.dll"]