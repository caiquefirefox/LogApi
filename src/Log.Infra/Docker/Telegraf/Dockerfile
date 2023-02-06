#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base Image
FROM telegraf:latest

# Volumes (Host/Container)
VOLUME Log.Infra/telegraf.conf /etc/telegraf/telegraf.conf:ro

WORKDIR /app
EXPOSE 8125

#docker build -t caiquedev94/telegraf:1.0 -f Log.Infra/Docker/telegraf/Dockerfile .
#docker run --link influxdb --net=log-compose-network -p 8125:8125 -d --name telegraf caiquedev94/telegraf