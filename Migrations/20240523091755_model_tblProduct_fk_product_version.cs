using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class model_tblProduct_fk_product_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductVersionID",
                table: "product",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductVersionID",
                table: "product",
                column: "ProductVersionID");

            migrationBuilder.AddForeignKey(
                name: "fk_product_version",
                table: "product",
                column: "ProductVersionID",
                principalTable: "product",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_version",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductVersionID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ProductVersionID",
                table: "product");
        }
    }
}
