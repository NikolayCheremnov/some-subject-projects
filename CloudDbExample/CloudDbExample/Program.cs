using CloudDbExample;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/api", () => new {Message = "server is running"});
app.MapGet("/api/ping", () => new {Message = "pong"});

// API CRUDS

app.MapGet(
    "/api/copybook", 
    async (ApplicationDbContext db) => await db.Copybooks.ToListAsync()
);

app.MapGet(
    "/api/copybook/{id:int}", 
    async (int id, ApplicationDbContext db) => await db.Copybooks.FirstOrDefaultAsync(cb => cb.Id == id)
);

app.MapPost("/api/copybook", async (Copybook copybook, ApplicationDbContext db) =>
{
    await db.Copybooks.AddAsync(copybook);
    await db.SaveChangesAsync();
    return Results.Created();
});

app.MapDelete("/api/copybook/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Copybook? deleted = db.Copybooks.FirstOrDefault(cb => cb.Id == id);
    if (deleted != null)
    {
        db.Copybooks.Remove(deleted);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});

app.MapPatch("/api/copybook", async (Copybook copybook, ApplicationDbContext db) =>
{
    Copybook? updated = db.Copybooks.FirstOrDefault(cb => cb.Id == copybook.Id);
    if (updated != null)
    {
        updated.Description = copybook.Description;
        updated.Price = copybook.Price;
        updated.PageCount = copybook.PageCount;
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});

app.Run();
