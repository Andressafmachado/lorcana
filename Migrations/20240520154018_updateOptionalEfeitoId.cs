using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boardGame1._1.Migrations
{
    /// <inheritdoc />
    public partial class updateOptionalEfeitoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartas_Efeitos_EfeitoId",
                table: "Cartas");

            migrationBuilder.AlterColumn<int>(
                name: "EfeitoId",
                table: "Cartas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_Efeitos_EfeitoId",
                table: "Cartas",
                column: "EfeitoId",
                principalTable: "Efeitos",
                principalColumn: "EfeitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartas_Efeitos_EfeitoId",
                table: "Cartas");

            migrationBuilder.AlterColumn<int>(
                name: "EfeitoId",
                table: "Cartas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_Efeitos_EfeitoId",
                table: "Cartas",
                column: "EfeitoId",
                principalTable: "Efeitos",
                principalColumn: "EfeitoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
