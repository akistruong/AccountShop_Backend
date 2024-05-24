using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_PrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail",
                columns: new[] { "VariantID", "order_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetail",
                table: "orderdetail");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "orderdetail",
                columns: new[] { "VariantID", "order_id" });
        }
    }
}
