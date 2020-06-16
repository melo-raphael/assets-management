FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["projeto.tcc.order.managament.api.v1/projeto.tcc.order.managament.api.v1.csproj", "projeto.tcc.order.managament.api.v1/"]
RUN dotnet restore "projeto.tcc.order.managament.api.v1/projeto.tcc.order.managament.api.v1.csproj"
COPY . .
WORKDIR "/src/projeto.tcc.order.managament.api.v1"
RUN dotnet build "projeto.tcc.order.managament.api.v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "projeto.tcc.order.managament.api.v1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "projeto.tcc.order.managament.api.v1.dll"]