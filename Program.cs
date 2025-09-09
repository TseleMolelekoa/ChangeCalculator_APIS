using Microsoft.AspNetCore.Mvc;           // Needed for BadRequestObjectResult
using Microsoft.OpenApi.Models;
using ChangeCalculator.Models;
using ChangeCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

// Optional: configure Kestrel with explicit HTTP/HTTPS ports to avoid HTTPS redirection warnings
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // HTTP
    options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
});

// Add services to the container
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Global model validation response using ErrorResponse
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .SelectMany(e => e.Value!.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var errorResponse = new ErrorResponse
            {
                Message = "Invalid request",
                Errors = errors.ToArray() // convert List<string> -> string[]
            };

            return new BadRequestObjectResult(errorResponse);
        };
    });

// Swagger + minimal API explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Change Calculator API",
        Version = "v1",
        Description = "API for calculating the minimum number of South African banknotes and coins for a given amount"
    });
});

// Register your custom services
builder.Services.AddScoped<IChangeCalculatorService, ChangeCalculatorService>();

var app = builder.Build();

// ✅ Swagger is always enabled
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Change Calculator API v1");
    c.RoutePrefix = "swagger"; // available at /swagger
});

// Redirect root / to Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
