using boardGame;
using BoardGame.Application.Cartas;
using BoardGame.Application.Decks;
using BoardGame.Application.Efeitos;
using BoardGame.Application.Jogadores;
using BoardGame.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICrudService<Carta>, CartasService>();
builder.Services.AddTransient<ICrudService<Deck>, DeckService>();
builder.Services.AddTransient<ICrudService<Efeito>, EfeitoService>();
builder.Services.AddTransient<ICrudService<Jogador>, JogadorService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceCollection("Server=localhost;Port=5432;Database=sundaydatabase;UserId=postgres;Password=postgres;Include Error Detail=true;");
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
