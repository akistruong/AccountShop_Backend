using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class order_detail_setNullRootIDProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_root",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "RootID",
                table: "product",
                type: "char(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AddForeignKey(
                name: "fk_product_root",
                table: "product",
                column: "RootID",
                principalTable: "product",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_root",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "RootID",
                table: "product",
                type: "char(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_product_root",
                table: "product",
                column: "RootID",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
