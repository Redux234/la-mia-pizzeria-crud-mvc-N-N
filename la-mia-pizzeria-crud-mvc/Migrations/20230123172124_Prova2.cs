using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriacrudmvc.Migrations
{
    /// <inheritdoc />
    public partial class Prova2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientiPizze_Pizza_PizzaId",
                table: "IngredientiPizze");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "IngredientiPizze",
                newName: "PizzzaId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientiPizze_PizzaId",
                table: "IngredientiPizze",
                newName: "IX_IngredientiPizze_PizzzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientiPizze_Pizza_PizzzaId",
                table: "IngredientiPizze",
                column: "PizzzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientiPizze_Pizza_PizzzaId",
                table: "IngredientiPizze");

            migrationBuilder.RenameColumn(
                name: "PizzzaId",
                table: "IngredientiPizze",
                newName: "PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientiPizze_PizzzaId",
                table: "IngredientiPizze",
                newName: "IX_IngredientiPizze_PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientiPizze_Pizza_PizzaId",
                table: "IngredientiPizze",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
