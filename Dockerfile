#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

RUN echo OK
ARG ASPNETCORE_ENVIRONMENT="Production"
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tech-pet-bff/", "tech-pet-bff"]
RUN dotnet restore "tech-pet-bff/tech-pet-bff.sln"
COPY . .

RUN dotnet build "tech-pet-bff/tech-pet-bff.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tech-pet-bff/tech-pet-bff.sln" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

# RUN useradd -m myappuser

COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "TechPet.API.dll" ]

# COPY ./ScrumPoker_Server/data_base.db ./
# COPY ./tech-pet-ui/dist/ ./wwwroot

# RUN chmod 777 ./data_base.db
# RUN chown -R myappuser:myappuser ./

# USER myappuser

# CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ScrumPoker.API.dll