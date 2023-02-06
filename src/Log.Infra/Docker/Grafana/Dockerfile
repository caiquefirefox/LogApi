#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base Image
FROM grafana:latest

# Volumes (Host/Container)
VOLUME grafana_data /var/lib/grafana

WORKDIR /app
EXPOSE 3000

ENV GF_SECURITY_ADMIN_USER admin
ENV GF_SECURITY_ADMIN_PASSWORD admin
ENV GF_INSTALL_PLUGINS 