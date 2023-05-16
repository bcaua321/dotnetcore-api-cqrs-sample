FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiCQRS.Api/ApiCQRS.Api.csproj", "ApiCQRS.Api/"]
COPY ["ApiCQRS.Application/ApiCQRS.Application.csproj", "ApiCQRS.Application/"]
COPY ["ApiCQRS.Core/ApiCQRS.Core.csproj", "ApiCQRS.Core/"]
COPY ["ApiCQRS.Infrastructure/ApiCQRS.Infrastructure.csproj", "ApiCQRS.Infrastructure/"]
RUN dotnet restore "ApiCQRS.Api/ApiCQRS.Api.csproj"
COPY . .
WORKDIR "/src/ApiCQRS.Api/"
RUN dotnet build "ApiCQRS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiCQRS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiCQRS.Api.dll"]