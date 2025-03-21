var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api", () => new {Message = "server is running"});
app.MapGet("/api/ping", () => new {Message = "pong"});
app.MapGet("/api/os", () => Environment.OSVersion);

app.Run();
