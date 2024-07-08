using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP11Core.Migrations
{
    /// <inheritdoc />
    public partial class AddProduitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieProduits",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduits", x => new { x.CategorieId, x.ProduitId });
                    table.ForeignKey(
                        name: "FK_CategorieProduits_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieProduits_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProduits_ProduitId",
                table: "CategorieProduits",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SousCategories_Categories_Id",
                table: "SousCategories",
                column: "Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SousCategories_Categories_Id",
                table: "SousCategories");

            migrationBuilder.DropTable(
                name: "CategorieProduits");

            migrationBuilder.DropTable(
                name: "Produits");

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
    }
}
