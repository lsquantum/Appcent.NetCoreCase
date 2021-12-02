#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Appcent.WebApi/Appcent.WebApi.csproj", "Appcent.WebApi/"]
COPY ["Appcent.Application/Appcent.Application.csproj", "Appcent.Application/"]
COPY ["Appcent.Domain/Appcent.Domain.csproj", "Appcent.Domain/"]
COPY ["Appcent.Infrastructure/Appcent.Infrastructure.csproj", "Appcent.Infrastructure/"]
RUN dotnet restore "Appcent.WebApi/Appcent.WebApi.csproj"
COPY . .
WORKDIR "/src/Appcent.WebApi"
RUN dotnet build "Appcent.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Appcent.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appcent.WebApi.dll"]