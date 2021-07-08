#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Payments.Events.Consumer.API/Payments.Events.Consumer.API.csproj", "Payments.Events.Consumer.API/"]
COPY ["Payments.Events.Consumer/Payments.Events.Consumer.csproj", "Payments.Events.Consumer/"]
COPY ["Payment.Charges.Domain/Payments.Charges.Domain.csproj", "Payment.Charges.Domain/"]
COPY ["Payments.Shared.Core/Payments.Shared.Core.csproj", "Payments.Shared.Core/"]
RUN dotnet restore "Payments.Events.Consumer.API/Payments.Events.Consumer.API.csproj"
COPY . .
WORKDIR "/src/Payments.Events.Consumer.API"
RUN dotnet build "Payments.Events.Consumer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payments.Events.Consumer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payments.Events.Consumer.API.dll"]
