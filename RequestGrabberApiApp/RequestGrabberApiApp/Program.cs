using Microsoft.EntityFrameworkCore;
using RequestGrabberApiApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/api", () => new {Message = "server is running"});
app.MapGet("/api/ping", () => new {Message = "pong"});

app.MapGet("/api/request", async (ApplicationDbContext db) => await db.Requests.ToListAsync());
app.MapDelete("/api/request", async (ApplicationDbContext db) =>
{
    db.Requests.RemoveRange(db.Requests);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Request request = new Request()
    {
        ReceivedAt = DateTime.UtcNow,
        HttpMethod = context.Request.Method,
        Url = context.Request.Path,
    };
    await next(context);
    request.StatusCode = context.Response.StatusCode;
    ApplicationDbContext db = context.RequestServices.GetRequiredService<ApplicationDbContext>();
    await db.Requests.AddAsync(request);
    await db.SaveChangesAsync();
});

app.Run();
