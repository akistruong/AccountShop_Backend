using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class Product_constraint_product_rootProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_ProductRootProductId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductRootProductId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ProductRootProductId",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "RootID",
                table: "product",
                type: "char(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_product_RootID",
                table: "product",
                column: "RootID");

            migrationBuilder.AddForeignKey(
                name: "fk_product_root",
                table: "product",
                column: "RootID",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_root",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_RootID",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "RootID",
                table: "product",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AddColumn<string>(
                name: "ProductRootProductId",
                table: "product",
                type: "char(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductRootProductId",
                table: "product",
                column: "ProductRootProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_ProductRootProductId",
                table: "product",
                column: "ProductRootProductId",
                principalTable: "product",
                principalColumn: "product_id");
        }
    }
}
