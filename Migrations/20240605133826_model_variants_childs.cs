using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class model_variants_childs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariantRootID",
                table: "variant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_variant_VariantRootID",
                table: "variant",
                column: "VariantRootID");

            migrationBuilder.AddForeignKey(
                name: "fk_variant_children",
                table: "variant",
                column: "VariantRootID",
                principalTable: "variant",
                principalColumn: "variant_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_variant_children",
                table: "variant");

            migrationBuilder.DropIndex(
                name: "IX_variant_VariantRootID",
                table: "variant");

            migrationBuilder.DropColumn(
                name: "VariantRootID",
                table: "variant");
        }
    }
}
