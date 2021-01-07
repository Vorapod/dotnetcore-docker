FROM mcr.microsoft.com/dotnet/sdk:5.0
ARG BUILD_CONFIG=Debug
ARG BUILDER_VERSION=0.0.1
LABEL maintainer=vorapod.e@gmail.com \
    Name=webapp-${BUILD_CONFIG} \
    Version=0.0.1
## Will be the path mapped to the external volume.
ARG BUILD_LOCATION=/app/out
ENV NUGET_XMLDOC_MODE skip
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . /app
RUN dotnet publish --output ${BUILD_LOCATION} --configuration ${BUILD_CONFIG}
