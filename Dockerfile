# Usar una imagen base de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Usar la imagen SDK para el build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar el archivo .csproj desde la ubicación del proyecto local
COPY ["diseno/Reciplas/Reciplas.csproj", "diseno/Reciplas/"]

# Restaurar las dependencias
RUN dotnet restore "diseno/Reciplas/Reciplas.csproj"

# Copiar el resto de los archivos del proyecto
COPY . .

# Establecer el directorio de trabajo para la publicación
WORKDIR /src/diseno/Reciplas

# Publicar el proyecto
RUN dotnet publish "Reciplas.csproj" -c Release -o /publish

# Usar la imagen base para el contenedor final
FROM base AS final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Reciplas.dll"]
