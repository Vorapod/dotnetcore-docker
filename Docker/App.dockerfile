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
# COPY ./publish . --> ลบออก เปลี่ยนไปใช้ step ด้านล่าง

# Create a container to copy dlls to appbuild
## 1. docker volume create appbuild - สร้างตัว volume
## 2. docker create --name webapp.builder -v appbuild:/app/out webapp:Build - สร้าง container สำหรับ mount volume
## 3. docker run --name webapp.test -v appbuild:/app -p 5000:7909 -d webapp:0.1 - สร้าง app โดน mount ไปที่ appbuild
## Ref. https://medium.com/@Likhitd/asp-net-core-and-mysql-with-docker-part-2-ee7fba1fc508

ENTRYPOINT [ "dotnet", "dotnetcore_ef_mysql_docker.dll" ]