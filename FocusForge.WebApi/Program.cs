using FocusForge.Application;
using FocusForge.Application.Commands;
using FocusForge.Infrastructure;
using FocusForge.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication(typeof(CreateTaskCommand).Assembly)
    .AddInfrastructure()
    .AddWebApi();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
