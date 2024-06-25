using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoardGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "Efeitos",
                columns: table => new
                {
                    EfeitoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PontosDeAtaque = table.Column<int>(type: "integer", nullable: true),
                    PontosDeDefesa = table.Column<int>(type: "integer", nullable: true),
                    Descrição = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efeitos", x => x.EfeitoId);
                });

            migrationBuilder.CreateTable(
                name: "Cartas",
                columns: table => new
                {
                    CartaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Custo = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Raridade = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cor = table.Column<int>(type: "integer", nullable: false),
                    Descrição = table.Column<string>(type: "text", nullable: true),
                    EfeitoId = table.Column<int>(type: "integer", nullable: true),
                    DeckId = table.Column<int>(type: "integer", nullable: false),
                    Número = table.Column<int>(type: "integer", nullable: false),
                    PodeVirarTinta = table.Column<bool>(type: "boolean", nullable: false),
                    JogadorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.CartaId);
                    table.ForeignKey(
                        name: "FK_Cartas_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartas_Efeitos_EfeitoId",
                        column: x => x.EfeitoId,
                        principalTable: "Efeitos",
                        principalColumn: "EfeitoId");
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    JogadorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DeckId = table.Column<int>(type: "integer", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.JogadorId);
                    table.ForeignKey(
                        name: "FK_Jogadores_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TurnoId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    JogadorNaVezJogadorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.JogoId);
                    table.ForeignKey(
                        name: "FK_Jogos_Jogadores_JogadorNaVezJogadorId",
                        column: x => x.JogadorNaVezJogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "JogadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JogoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                    table.ForeignKey(
                        name: "FK_Turnos_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "JogoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_DeckId",
                table: "Cartas",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_EfeitoId",
                table: "Cartas",
                column: "EfeitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_JogadorId",
                table: "Cartas",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_DeckId",
                table: "Jogadores",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_JogoId",
                table: "Jogadores",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_JogadorNaVezJogadorId",
                table: "Jogos",
                column: "JogadorNaVezJogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_JogoId",
                table: "Turnos",
                column: "JogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_Jogadores_JogadorId",
                table: "Cartas",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "JogadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Jogos_JogoId",
                table: "Jogadores",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "JogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Decks_DeckId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Jogadores_JogadorNaVezJogadorId",
                table: "Jogos");

            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Efeitos");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
