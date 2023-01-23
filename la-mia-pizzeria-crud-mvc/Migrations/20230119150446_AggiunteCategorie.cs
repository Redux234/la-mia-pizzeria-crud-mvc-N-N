using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriacrudmvc.Migrations
{
    /// <inheritdoc />
    public partial class AggiunteCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CategoriaId",
                table: "Pizza",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_CategoriaId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pizza");
        }
    }
}
