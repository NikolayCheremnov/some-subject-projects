FROM postgres:latest

ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres
ENV POSTGRES_DB=users_db

COPY init.sql /docker-entrypoint-initdb.d/
