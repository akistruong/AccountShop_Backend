using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class set_delete_cascade_product_variant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_variant_product",
                table: "variant");

            migrationBuilder.AddForeignKey(
                name: "fk_variant_product",
                table: "variant",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_variant_product",
                table: "variant");

            migrationBuilder.AddForeignKey(
                name: "fk_variant_product",
                table: "variant",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id");
        }
    }
}
