using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_update_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                columns: new[] { "product_id", "VariantID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                columns: new[] { "product_id", "VariantID" });
        }
    }
}
