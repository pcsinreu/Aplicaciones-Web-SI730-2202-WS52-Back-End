FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LearningCenter.API/LearningCenter.API.csproj", "LearningCenter.API/"]
COPY ["LearningCenter.Domain/LearningCenter.Domain.csproj", "LearningCenter.Domain/"]
COPY ["LearningCenter.Infraestructure/LearningCenter.Infraestructure.csproj", "LearningCenter.Infraestructure/"]
COPY ["LearningCenter.Shared/LearningCenter.Shared.csproj", "LearningCenter.Shared/"]
RUN dotnet restore "LearningCenter.API/LearningCenter.API.csproj"
COPY . .
WORKDIR "/src/LearningCenter.API"
RUN dotnet build "LearningCenter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningCenter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningCenter.API.dll"]
