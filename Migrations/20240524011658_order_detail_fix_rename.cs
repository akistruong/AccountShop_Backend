using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_fix_rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orderdetail");

            migrationBuilder.RenameIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail",
                newName: "IDX_Ordt_variant");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                column: "VariantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.RenameIndex(
                name: "IDX_Ordt_variant",
                table: "orderdetail",
                newName: "IX_orderdetail_VariantID");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orderdetail",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                columns: new[] { "product_id", "VariantID" });

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail",
                column: "product_id",
                principalTable: "tbl_order",
                principalColumn: "order_id");
        }
    }
}
