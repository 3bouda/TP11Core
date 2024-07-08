using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP11Core.Migrations
{
    /// <inheritdoc />
    public partial class AddProduitCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_Id",
                table: "SousCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SousCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_CategorieId",
                table: "SousCategories",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_CategorieId",
                table: "SousCategories",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_CategorieId",
                table: "SousCategories");

            migrationBuilder.DropIndex(
                name: "IX_SousCategories_CategorieId",
                table: "SousCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SousCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_Id",
                table: "SousCategories",
                column: "Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
