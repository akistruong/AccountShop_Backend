using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_addKeyOrderID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "orderdetail",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                columns: new[] { "VariantID", "order_id" });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_order_id",
                table: "orderdetail",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_order",
                table: "orderdetail",
                column: "order_id",
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
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.DropIndex(
                name: "IX_orderdetail_order_id",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                column: "VariantID");
        }
    }
}
