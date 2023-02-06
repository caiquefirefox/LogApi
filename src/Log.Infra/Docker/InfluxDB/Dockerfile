#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base Image
FROM influxdb:latest

# Volumes (Host/Container)
VOLUME influxdb_data /var/lib/influxdb

WORKDIR /app
EXPOSE 8086

ENV DOCKER_INFLUXDB_INIT_MODE setup
ENV DOCKER_INFLUXDB_INIT_USERNAME telegraf
ENV DOCKER_INFLUXDB_INIT_PASSWORD P@ssw0rd
ENV DOCKER_INFLUXDB_INIT_ORG telegraf
ENV DOCKER_INFLUXDB_INIT_BUCKET telegraf
ENV DOCKER_INFLUXDB_INIT_RETENTION 1w
ENV DOCKER_INFLUXDB_INIT_ADMIN_TOKEN 9859DAA6-3B3F-48FE-A981-AE9D31FBB334

#ENTRYPOINT ["/entrypoint.sh"]
#docker network create --driver=bridge log-compose-network
#docker build -t caiquedev94/influxdb:1.0 .
#docker run --net=log-compose-network -p 8086:8086 -d --name influxdb a318aa92f59e