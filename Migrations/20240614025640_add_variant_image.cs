using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class add_variant_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "tbl_image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_image_VariantId",
                table: "tbl_image",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "fk_image_variant",
                table: "tbl_image",
                column: "VariantId",
                principalTable: "variant",
                principalColumn: "variant_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_image_variant",
                table: "tbl_image");

            migrationBuilder.DropIndex(
                name: "IX_tbl_image_VariantId",
                table: "tbl_image");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "tbl_image");
        }
    }
}
