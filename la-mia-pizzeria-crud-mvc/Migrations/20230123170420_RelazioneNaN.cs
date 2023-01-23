using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriacrudmvc.Migrations
{
    /// <inheritdoc />
    public partial class RelazioneNaN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingrediente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientiPizze",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientiPizze", x => new { x.IngredienteId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_IngredientiPizze_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientiPizze_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiPizze_PizzaId",
                table: "IngredientiPizze",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "IngredientiPizze");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizza",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Categorie_CategoriaId",
                table: "Pizza",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }
    }
}
