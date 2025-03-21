# Команды для локальной сборки

## Сборка образа

`docker build -t auto-deploy-challenge -f ./AutoDeployChallenge/Dockerfile .`

## Создание + запуск контейнера

`docker run --name auto-deploy-challenge -p 8080:8080 -d auto-deploy-challenge`

## Запуск/остановка контейнера

`docker start auto-deploy-challenge`

`docker stop auto-deploy-challenge`
