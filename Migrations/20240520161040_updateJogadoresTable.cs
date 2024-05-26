using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boardGame1._1.Migrations
{
    /// <inheritdoc />
    public partial class updateJogadoresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JogoId",
                table: "Turnos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JogoId1",
                table: "Jogadores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TurnoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.JogoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_JogoId",
                table: "Turnos",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_JogoId",
                table: "Jogadores",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_JogoId1",
                table: "Jogadores",
                column: "JogoId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Jogos_JogoId",
                table: "Jogadores",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "JogoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Jogos_JogoId1",
                table: "Jogadores",
                column: "JogoId1",
                principalTable: "Jogos",
                principalColumn: "JogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Jogos_JogoId",
                table: "Turnos",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "JogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Jogos_JogoId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Jogos_JogoId1",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Jogos_JogoId",
                table: "Turnos");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_JogoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_JogoId",
                table: "Jogadores");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_JogoId1",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "JogoId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "JogoId1",
                table: "Jogadores");
        }
    }
}
