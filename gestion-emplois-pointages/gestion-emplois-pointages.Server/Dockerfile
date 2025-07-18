# Consultez https://aka.ms/customizecontainer pour savoir comment personnaliser votre conteneur de débogage et comment Visual Studio utilise ce Dockerfile pour générer vos images afin d’accélérer le débogage.

# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS with-node
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_20.x | bash
RUN apt-get -y install nodejs
RUN npm install -g @angular/cli

FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gestion-emplois-pointages/gestion-emplois-pointages.Server/gestion-emplois-pointages.Server.csproj", "gestion-emplois-pointages/gestion-emplois-pointages.Server/"]
COPY ["gestion-emplois-pointages.client/gestion-emplois-pointages.client.esproj", "gestion-emplois-pointages.client/"]
RUN dotnet restore "./gestion-emplois-pointages/gestion-emplois-pointages.Server/gestion-emplois-pointages.Server.csproj"
COPY . .
WORKDIR "/src/gestion-emplois-pointages/gestion-emplois-pointages.Server"
RUN dotnet build "./gestion-emplois-pointages.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette étape permet de publier le projet de service à copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./gestion-emplois-pointages.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestion-emplois-pointages.Server.dll"]
