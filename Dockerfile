################
# Build
################

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder

RUN mkdir -p /app/src/asa
WORKDIR /app/src/asa

COPY src/Asa/Asa.csproj ./
RUN dotnet restore

COPY src/Asa/* ./
RUN dotnet publish -c Release -o ../../out


################
# Run
################

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app
COPY --from=builder /app/out .

ENTRYPOINT ["dotnet", "Asa.dll"]
EXPOSE 80
EXPOSE 443
