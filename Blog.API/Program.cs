
using Blog.IOC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InyectarDependencias(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InyectarDependencias(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("NuevaPolitica");


app.UseAuthorization();

app.MapControllers();

app.Run();
