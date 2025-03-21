using DockerizedAppExampleWithDb;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/api", () => new { Message = "server is running" });
app.MapGet("/api/ping", () => new { Message = "pong" });

// simple customers REST API

// GET /api/customer?page=&pageSize=
app.MapGet("/api/customer", async (int? page, int? pageSize, ApplicationDbContext db) =>
{
    const int defaultPageSize = 10;
    // count - кол-во записей
    // pagesCount = count / pageSize (+ 1 если count % pageSize != 0)
    // реализация простого пейджирования
    if (pageSize == null)
    {
        pageSize = defaultPageSize;
    }
    int customersCount = await db.Customers.CountAsync();
    int pagesCount = customersCount / (int)pageSize;
    if (customersCount % pageSize != 0)
    {
        pagesCount++;
    }
    if (page == null || page < 1)
    {
        page = 1;
    }
    if (page > pagesCount)
    {
        page = pagesCount;
    }
    List<Customer> customers = await db.Customers
        .Skip((int)((page - 1) * pageSize))
        .Take((int)pageSize)
        .ToListAsync();
    return customers;
});

// GET /api/customer/{id}
app.MapGet("/api/customer/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Customer? customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customer == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(customer);
});

// POST /api/customer + { "name": "...", "phoneNumber": "...", "email": "...", "birthDate": "..." }
app.MapPost("/api/customer", async (CustomerRegistration registration, ApplicationDbContext db) =>
{
    if (registration.PhoneNumber == null && registration.Email == null)
    {
        return Results.BadRequest(new { Error = "email or phone number is required" });
    }
    // аналогично можно сделать другие проверки
    Customer customer = new Customer()
    {
        Name = registration.Name,
        Email = registration.Email,
        PhoneNumber = registration.PhoneNumber,
        BirthDate = registration.BirthDate,
        RegisteredAt = DateOnly.FromDateTime(DateTime.Now)
    };
    await db.Customers.AddRangeAsync(customer);
    await db.SaveChangesAsync();
    return Results.Created();
});

app.Run();

// API records
record CustomerRegistration(string Name, string? PhoneNumber, string? Email, DateOnly BirthDate);
