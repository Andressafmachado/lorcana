using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boardGame1._1.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "Efeitos",
                columns: table => new
                {
                    EfeitoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PontosDeAtaque = table.Column<int>(type: "INTEGER", nullable: true),
                    PontosDeDefesa = table.Column<int>(type: "INTEGER", nullable: true),
                    Descrição = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efeitos", x => x.EfeitoId);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    JogadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    JogoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Cartas",
                columns: table => new
                {
                    CartaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Custo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Raridade = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cor = table.Column<int>(type: "INTEGER", nullable: false),
                    Descrição = table.Column<string>(type: "TEXT", nullable: true),
                    EfeitoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false),
                    Número = table.Column<int>(type: "INTEGER", nullable: false),
                    JogadorId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        principalColumn: "EfeitoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartas_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "JogadorId");
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Efeitos");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
