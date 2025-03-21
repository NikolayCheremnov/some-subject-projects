FROM mysql:8.4.4

ENV MYSQL_DATABASE=users_db
ENV MYSQL_ROOT_PASSWORD=root

# инструкция выполняющая инициализацию БД (специфично для каждого сервиса)
ADD init.sql /docker-entrypoint-initdb.d

EXPOSE 3306
