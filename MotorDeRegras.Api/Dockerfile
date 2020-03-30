FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MotorDeRegras.Api/MotorDeRegras.Api.csproj", "MotorDeRegras.Api/"]
RUN dotnet restore "MotorDeRegras.Api/MotorDeRegras.Api.csproj"
COPY . .
WORKDIR "/src/MotorDeRegras.Api"
RUN dotnet build "MotorDeRegras.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MotorDeRegras.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MotorDeRegras.Api.dll"]