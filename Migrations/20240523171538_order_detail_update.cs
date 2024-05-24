using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.AddColumn<string>(
                name: "ProductRootProductId",
                table: "product",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootID",
                table: "product",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "VariantID",
                table: "orderdetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                columns: new[] { "product_id", "VariantID" });

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductRootProductId",
                table: "product",
                column: "ProductRootProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail",
                column: "VariantID");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail",
                column: "VariantID",
                principalTable: "variant",
                principalColumn: "variant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_ProductRootProductId",
                table: "product",
                column: "ProductRootProductId",
                principalTable: "product",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_ProductRootProductId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductRootProductId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.DropIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "ProductRootProductId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "RootID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "VariantID",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                column: "product_id");
        }
    }
}
