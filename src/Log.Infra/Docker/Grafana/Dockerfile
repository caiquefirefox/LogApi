#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base Image
FROM grafana/grafana

# Volumes (Host/Container)
VOLUME grafana_data /var/lib/grafana

WORKDIR /app
EXPOSE 3000

ENV GF_SECURITY_ADMIN_USER admin
ENV GF_SECURITY_ADMIN_PASSWORD admin

#docker build -t caiquedev94/grafana:1.0 -f Log.Infra/Docker/Grafana/Dockerfile .
#docker run --link influxdb --net=log-compose-network -p 3000:3000 -d --name grafana caiquedev94/grafana