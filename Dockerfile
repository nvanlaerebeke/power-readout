FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
ARG ARCH=linux-arm

WORKDIR /app

COPY ./src ./

RUN dotnet restore
RUN dotnet publish -c Release -o /build -r "${ARCH}" \
    --self-contained true \
    -p:DebugSymbols=false \
    -p:DebugType=None \
    "PowerReadOut/PowerReadOut.csproj"

# Build runtime image
# .NET 10 defaults to Ubuntu-based tags; use arm32v7 explicitly to match your original intent.
FROM mcr.microsoft.com/dotnet/runtime-deps:10.0-noble-arm32v7
WORKDIR /app

COPY --from=build-env /build .
ENTRYPOINT ["/app/PowerReadOut"]
