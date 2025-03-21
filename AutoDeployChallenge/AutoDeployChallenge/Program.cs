var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api", () => new {Message = "server is running"});
app.MapGet("/api/ping", () => new {Message = "pong"});
app.MapGet("/api/time", () => DateTime.Now);
app.MapGet("/api/os", () => Environment.OSVersion);
app.MapGet("/api/greeting", () => "Hello hello!");

app.Run();
