FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ARG ARCH=linux-arm

WORKDIR /app

COPY ./src ./

RUN dotnet restore 
RUN dotnet publish -c Release -o /build -r "${ARCH}" --self-contained true -p:PublishTrimmed=true /p:DebugSymbols=false /p:DebugType=None "PowerReadOut/PowerReadOut.csproj"

# Build runtime image
FROM  mcr.microsoft.com/dotnet/runtime-deps:6.0-bullseye-slim-arm32v7
WORKDIR /app

COPY --from=build-env /build .
ENTRYPOINT ["/app/PowerReadOut"]
