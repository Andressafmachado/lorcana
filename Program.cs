// // See https://aka.ms/new-console-template for more information


using boardGame;
using EFExemplo;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

Context contextDb = new Context();


// Console.WriteLine("Hello, World!");

// Jogo jogo = new Jogo();


// Jogador jogador1 = new Jogador();
// jogador1.Nome = "Andressa";
// jogador1.CartasNaMão = [];

// Jogador jogador2 = new Jogador();
// jogador2.Nome = "Luiz";
// jogador2.CartasNaMão = [];




// Carta carta = new Glimmer();

// Deck deckAndressa = new Deck(){};
// deckAndressa.Cartas = [];
// Deck deckLuiz = new Deck();
// deckLuiz.Cartas = [];

// deckAndressa.Cartas.Add(carta);
// deckLuiz.Cartas.Add(carta);

// jogador1.Deck = deckAndressa;
// jogador2.Deck = deckLuiz;

// List<Jogador> jogadores = new List<Jogador>(){
//     jogador1,
//     jogador2
// };

// jogo.SetUp(jogadores);
// jogo.Começar();

// Context contextDb = new Context();

// Efeito efeito = new Efeito(){
//     Descrição = "-1 de defesa no personagem escolhido"
// };



// CRIANDO DECK COM CARTAS NO BANCO DE DADOS

// Deck deck2 = new Deck(){
//     Nome = "Aventura"
// };

// contextDb.Add(deck2);

// Deck deck4 = new Deck(){
//     Nome = "Guerreiros"
// };

// contextDb.Add(deck4);
// contextDb.SaveChanges();






// Canção carta2 = new Canção(){
//     Tipo = TipoDaCarta.Canção,
//     Raridade = RaridadeDaCarta.Comum,
//     Custo = 2,
//     Nome = "Livre estou",
//     Cor = CoresDaTinta.Esmeralda,
//     Descrição = "",
//     EfeitoId = 1,
//     DeckId = 2,
//     Número = 4
// };



// Personagem personagem = new Personagem(){
//     Tipo = TipoDaCarta.Personagem,
//     Nome = "Minnie",
//     ForçaDeVontade = 3,
//     PoderDeAtaque = 3,
//     Cor = CoresDaTinta.Ambar,
//     Custo = 2,
//     Lore = 2,
//     DeckId = 1
// };



// contextDb.Cartas.Add(personagem);
// contextDb.SaveChanges();



// CRIANDO JOGO E JOGADORES
// Jogo jogo = new Jogo();
// contextDb.Add(jogo);
// contextDb.SaveChanges();

// Jogador jogador1 = new Jogador();
// jogador1.Nome = "Andressa";
// jogador1.DeckId = 1;
// jogador1.CartasNaMão = [];
// jogador1.JogoId=1;

// Jogador jogador2 = new Jogador();
// jogador2.Nome = "Luiz";
// jogador2.DeckId = 2;
// jogador2.CartasNaMão = [];
// jogador2.JogoId = 1;

// contextDb.Jogadores.AddRange(jogador1, jogador2);
// contextDb.SaveChanges();





var aventura = contextDb.Decks.Include(c => c.Cartas).FirstOrDefault(c => c.DeckId == 1);
var guerreiros = contextDb.Decks.Include(c => c.Cartas).FirstOrDefault(c => c.DeckId == 2);

var andressa = contextDb.Jogadores
.Include(c => c.Deck)
.ThenInclude(d => d.Cartas)
.ThenInclude(c => c.Efeito)
.FirstOrDefault(c => c.JogadorId == 1);
var luiz = contextDb.Jogadores.Include(c => c.Deck).FirstOrDefault(c => c.JogadorId == 2);

List<Jogador> jogadores = new List<Jogador>(){
    andressa,
    luiz
};



Jogo jogo = new Jogo();
jogo.SetUp(jogadores);

Console.WriteLine();



// HOW TO SYNTAX:


// testing
// var cartanobanco = contextDb.Cartas.Include( c => c.Efeito);
// var fork = contextDb.Efeitos.FirstOrDefault(c => c.EfeitoId == 1);
// fork.PontosDeAtaque = 1;


// REMOVER UMA RANGE DE ITENS
//  var itemsToDelete = contextDb.Efeitos
//         .OrderBy(e => e.EfeitoId)
//         .Skip(3)
//         .Take(5)
//         .ToList();

// contextDb.Efeitos.RemoveRange(itemsToDelete);
// contextDb.SaveChanges();


// REMOVE 1 ITEM
// var efeito = contextDb.Efeitos.FirstOrDefault(e => e.EfeitoId ==3);

// contextDb.Efeitos.Remove(efeito);
// contextDb.SaveChanges();


// ATUALIZAR UMA PROPRIEDADE EM TODAS AS ENTRIES DE UMA TABLE
// var entities = contextDb.Cartas.ToList();
//     foreach (var entity in entities)
//     {
//         entity.PodeVirarTinta = true;
//     }
//     contextDb.SaveChanges();
