FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Volo.Wish.Api/Volo.Wish.Api.csproj", "Volo.Wish.Api/"]
RUN dotnet restore "Volo.Wish.Api/Volo.Wish.Api.csproj"
COPY . .
WORKDIR "/src/Volo.Wish.Api"
RUN dotnet build "Volo.Wish.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Volo.Wish.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Volo.Wish.Api.dll"]