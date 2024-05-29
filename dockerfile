# This file ins base on this article:
# https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell
# Other editions link: https://hub.docker.com/_/microsoft-mssql-server
# Para construir la imagen se debe ejecutar el comando:
# docker build -t <name>
FROM mcr.microsoft.com/mssql/server:2022-latest

USER mssql

WORKDIR /app
#RUN mkdir /app 

COPY docs/dbProfiles.sql /app/dbProfiles.sql

#RUN ls app -al

ENV ACCEPT_EULA="Y" \
    MSSQL_SA_PASSWORD="Test#2024."

EXPOSE 1433 
