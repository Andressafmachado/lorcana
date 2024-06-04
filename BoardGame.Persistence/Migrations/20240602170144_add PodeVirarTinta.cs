using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boardGame1._1.Migrations
{
    /// <inheritdoc />
    public partial class addPodeVirarTinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PodeVirarTinta",
                table: "Cartas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PodeVirarTinta",
                table: "Cartas");
        }
    }
}
