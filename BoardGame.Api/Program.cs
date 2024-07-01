using boardGame;
using BoardGame.Application.Abstractions;
using BoardGame.Application.Cartas;
using BoardGame.Application.Decks;
using BoardGame.Application.Decks.Commands;
using BoardGame.Application.Decks.Validators;
using BoardGame.Application.Efeitos;
using BoardGame.Application.Jogadores;
using BoardGame.Persistence;
using Infrastructure.Middleware;
using MediatR;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICrudService<Carta>, CartasService>();
builder.Services.AddTransient<ICrudService<Deck>, DeckService>();
builder.Services.AddTransient<ICrudService<Efeito>, EfeitoService>();
builder.Services.AddTransient<ICrudService<Jogador>, JogadorService>();
// builder.Services.AddTransient<List<IValidate<Deck>>>(c => new List<IValidate<Deck>> {new DeckMissingCardsValidator(), new DeckAmountCardsValidator()});
builder.Services.AddMediatR(BoardGame.Application.AssemblyReference.Assembly);

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

// app.UseMiddleware<DeckValidationMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
