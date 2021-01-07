# Build outside container

FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV BUILD_CONFIG Debug
LABEL maintainer=vorapod.e@gmail.com \
    Name=webapp-${BUILD_CONFIG} \
    Version=0.0.1
ARG URL_PORT
WORKDIR /app
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
COPY ./publish .
ENTRYPOINT [ "dotnet", "dotnetcore_ef_mysql_docker.dll" ]