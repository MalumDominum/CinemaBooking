FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/CinemaBooking.Api/CinemaBooking.Api.csproj", "CinemaBooking.Api/"]
COPY ["src/CinemaBooking.Application/CinemaBooking.Application.csproj", "CinemaBooking.Application/"]
COPY ["src/CinemaBooking.Domain/CinemaBooking.Domain.csproj", "CinemaBooking.Domain/"]
COPY ["src/CinemaBooking.Contracts/CinemaBooking.Contracts.csproj", "CinemaBooking.Contracts/"]
COPY ["src/CinemaBooking.Infrastructure/CinemaBooking.Infrastructure.csproj", "CinemaBooking.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "CinemaBooking.Api/CinemaBooking.Api.csproj"
COPY . ../
WORKDIR /src/CinemaBooking.Api
RUN dotnet build "CinemaBooking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CinemaBooking.Api.dll"]