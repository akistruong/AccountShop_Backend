using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_removeKey_ProductID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail");

            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_product",
                table: "orderdetail");

            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail");

            migrationBuilder.DropForeignKey(
                name: "fk_product_version",
                table: "product");

            migrationBuilder.DropTable(
                name: "variantAttribute");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductVersionID",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.DropIndex(
                name: "fk_orderdt_product",
                table: "orderdetail");

            migrationBuilder.DropIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "VariantStock",
                table: "variant");

            migrationBuilder.DropColumn(
                name: "ProductVersionID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "VariantID",
                table: "orderdetail");

            migrationBuilder.AlterColumn<int>(
                name: "product_id",
                table: "orderdetail",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail",
                column: "product_id",
                principalTable: "tbl_order",
                principalColumn: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.AddColumn<int>(
                name: "VariantStock",
                table: "variant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductVersionID",
                table: "product",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "product_id",
                table: "orderdetail",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "orderdetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantID",
                table: "orderdetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                columns: new[] { "order_id", "product_id" });

            migrationBuilder.CreateTable(
                name: "variantAttribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AttributeId);
                    table.ForeignKey(
                        name: "fk_variant_attribute",
                        column: x => x.VariantId,
                        principalTable: "variant",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductVersionID",
                table: "product",
                column: "ProductVersionID");

            migrationBuilder.CreateIndex(
                name: "fk_orderdt_product",
                table: "orderdetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_variantAttribute_VariantId",
                table: "variantAttribute",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail",
                column: "order_id",
                principalTable: "tbl_order",
                principalColumn: "order_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_product",
                table: "orderdetail",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail",
                column: "VariantID",
                principalTable: "variant",
                principalColumn: "variant_id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_version",
                table: "product",
                column: "ProductVersionID",
                principalTable: "product",
                principalColumn: "product_id");
        }
    }
}
