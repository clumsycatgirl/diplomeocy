FROM mysql/mysql-server:latest

RUN mkdir -p /docker-entrypoint-initdb.d
COPY ./Init /docker-entrypoint-initdb.d
