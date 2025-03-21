var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "server is running");
app.MapGet("/ping", () => "pong");
app.MapGet("/greeting", (string name) => $"hello, {name}");

/* 
1. РЕАЛИЗОВАТЬ ВЕБ-ПРИЛОЖЕНИЕ ASP.NET С ТРЕМЯ ENPOINT-МИ

/ -> "server is running, now time is <текущее время>"

/ping -> "pong"

/info -> <информация о системе и железе, на которых работает компьютер (не менее 5 характеристик в любом виде>

2. ПРОТЕСТИРОВАТЬ ПРИЛОЖЕНИЕ ЛОКАЛЬНО (ПОСТАВИТЬ ПОРТ 8080)

3. ВЫПОЛНИТЬ ПУБЛИКАЦИЮ ПРИЛОЖЕНИЯ В ПАПКУ И ЗАЛИТЬ ПАПКУ НА ХОСТИНГ - free asp hosting (ПРЕДВАРИТЕЛЬНО ЗАРЕГАТЬСЯ)

4. СДЕЛАТЬ ВЫВОД О ТОМ, НА КАКОМ ЖЕЛЕЗЕ И КАКОЙ СИСТЕМЕ РАБОТАЕТ free asp hosting

ВАЖНЫЕ ПРИМЕЧАНИЯ:
1) Сервис https://freeasphosting.net может быть не доступен без VPN - можно включить vpn в браузере (browsec, troywell
2) При создании проекта указать .net 7 - если он у вас не установлен, то установить в инструментах Visual Studio Installer
3) При архивации файлов для отправки на сервер, архивировать содержимое папки public, а не саму папку

*/

app.Run();
