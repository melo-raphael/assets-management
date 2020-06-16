FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["projeto.tcc.order.managament.api.v1/projeto.tcc.order.managament.api.v1.csproj", "projeto.tcc.order.managament.api.v1/"]
COPY ["projeto.tcc.order.managament.application/projeto.tcc.order.managament.application.csproj", "projeto.tcc.order.managament.application/"]
COPY ["projeto.tcc.order.managament.domain/projeto.tcc.order.managament.domain.csproj", "projeto.tcc.order.managament.domain/"]
COPY ["projeto.tcc.order.managament.crosscutting.ioc/projeto.tcc.order.managament.crosscutting.ioc.csproj", "projeto.tcc.order.managament.crosscutting.ioc/"]
COPY ["projeto.tcc.order.managament.data/projeto.tcc.order.managament.data.csproj", "projeto.tcc.order.managament.data/"]
COPY ["projeto.tcc.order.managament.proxy.wallet/projeto.tcc.order.managament.proxy.wallet.csproj", "projeto.tcc.order.managament.proxy.wallet/"]
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