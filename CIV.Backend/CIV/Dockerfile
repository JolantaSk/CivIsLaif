FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 7130
EXPOSE 44329

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CIV/CIV.csproj CIV/
RUN dotnet restore CIV/CIV.csproj
COPY . .
WORKDIR /src/CIV
RUN dotnet build CIV.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CIV.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CIV.dll"]
