using EFExemplo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using boardGame;
using boardGame.Cartas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICrud, CartasService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options => 
    options.UseNpgsql("Server=localhost;Port=5432;Database=sundaydatabase;UserId=postgres;Password=postgres;Include Error Detail=true;"));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
