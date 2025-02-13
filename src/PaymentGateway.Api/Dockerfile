﻿FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/PaymentGateway.Api/PaymentGateway.Api.csproj", "PaymentGateway.Api/"]
COPY ["src/PaymentGateway.Application/PaymentGateway.Application.csproj", "PaymentGateway.Application/"]
COPY ["src/PaymentGateway.Infrastructure/PaymentGateway.Infrastructure.csproj", "PaymentGateway.Infrastructure/"]
COPY ["src/PaymentGateway.Domain/PaymentGateway.Domain.csproj", "PaymentGateway.Domain/"]
COPY ["src/PaymentGateway.Interfaces/PaymentGateway.Interfaces.csproj", "PaymentGateway.Interfaces/"]
COPY ["src/PaymentGateway.Data/PaymentGateway.Data.csproj", "PaymentGateway.Data/"]
COPY ["src/PaymentGateway.Dto/PaymentGateway.Dto.csproj", "PaymentGateway.Dto/"]
COPY ["src/AcquiringBank.SDK/AcquiringBank.SDK.csproj", "AcquiringBank.SDK/"]

RUN dotnet restore "./PaymentGateway.Api/PaymentGateway.Api.csproj"
COPY src/. /src/
WORKDIR "/src/PaymentGateway.Api"
RUN dotnet build "PaymentGateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentGateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.Api.dll"]
